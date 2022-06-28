using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinLoseScript : MonoBehaviour {

	private ScoreManager scoremanager;

	private Vector2 Playpos;
	private Vector2 Startpos;
	private Vector2 Tpos;	
	private GUIStyle style1 = new GUIStyle();
	private GUIStyle style2 = new GUIStyle();
	private GUIStyle style3 = new GUIStyle();
	private GUIStyle style4 = new GUIStyle();
	public GameObject WinSong;
	public GameObject LoseSong;
	private int totalScore;
	private int perfectGame;
	private int numberGame;
//	public int perfectGame;
//	public int numberGame;
	private int PerfectBonus;
	private float DiffMulti;
	private int purrfect;
	public Font Myfont;
	
	private float Finalscore;

    public GameObject Title, PlayAgain, StartMenu;
    public GameObject backgroundBlockTop, backgroundBlockLeft, backgroundBlockRight, backgroundBlockBottom, backgroundImage;
    float pixelsx, pixelsy, ratio, sizeX, sizeY;
    public GameObject layoutChecker;//position set in scene layout, checked in update to keep layout correct. Replaces checking an actual game object which may need ot move
    private float yLayoutChecker;
    //safearea screen stuff
    private float safeMinX, safeMaxX, safeMinY, safeMaxY, safeMidX, safeMidY, safeHeight, safeWidth, safeUIMinX, safeUIMaxX, 
        safeUIMinY, safeUIMaxY, safeUIMidX, safeUIMidY, safeUIHeight, safeUIWidth;

	void Start () {
        SceneSizer();
        SceneLayout();
        
		style1.fontSize = (int) Mathf.Floor(Screen.height*0.11f);
		style1.normal.textColor = new Color (0,1,0,1);
		style1.alignment = TextAnchor.MiddleRight;
		style1.font = Myfont;
		
		style4.fontSize = (int) Mathf.Floor(Screen.height*0.11f);
		style4.normal.textColor = new Color (0,1,0,1);
		style4.alignment = TextAnchor.MiddleLeft;
		style4.font = Myfont;
		
		style2.fontSize = (int) Mathf.Floor(Screen.height*0.07f);
		style2.normal.textColor = Color.white;
		style2.alignment = TextAnchor.MiddleRight;
		style2.font = Myfont;
		
		style3.fontSize = (int) Mathf.Floor(Screen.height*0.07f);
		style3.normal.textColor = Color.white;
		style3.alignment = TextAnchor.MiddleLeft;
		style3.font = Myfont;
		
		if (SceneManager.GetActiveScene().name.Contains("Easy")) {
			PerfectBonus = 1000;
			DiffMulti = 1f;
			purrfect=5;
			if (SceneManager.GetActiveScene().name.Contains("Win")) {
				PlayerPrefs.SetFloat("MedLevelAllow1", 1f);
			}
		}
		if (SceneManager.GetActiveScene().name.Contains("Med")) {
			PerfectBonus = 2000;
			DiffMulti = 1.2f;
			purrfect=5;
			if (SceneManager.GetActiveScene().name.Contains("Win")) {
				PlayerPrefs.SetFloat("HardLevelAllow1", 1f);
			}
		}
		if (SceneManager.GetActiveScene().name.Contains("Hard")) {
			PerfectBonus = 5000;
			DiffMulti = 1.7f;
			purrfect=5;
			if (SceneManager.GetActiveScene().name.Contains("Win")) {
				PlayerPrefs.SetFloat("ExpertLevelAllow1", 1f);
			}
		}
		if (SceneManager.GetActiveScene().name.Contains("Xprt")) {
			PerfectBonus = 10000;
			DiffMulti = 2.5f;
			purrfect=6;
		}
		if (SceneManager.GetActiveScene().name.Contains("Insane")) {
			PerfectBonus = 25000;
			DiffMulti = 4f;
			purrfect=8;
		}
		
		if (GameObject.FindGameObjectWithTag("NoSFX") == false) {
			if (SceneManager.GetActiveScene().name.Contains("Win")) {
				Instantiate (WinSong,new Vector2(0f,0f), Quaternion.identity);
			} else {
				Instantiate (LoseSong,new Vector2(0f,0f), Quaternion.identity);
			}
		}	
		
		totalScore = PlayerPrefs.GetInt("TotalScore",0);
		perfectGame = PlayerPrefs.GetInt("PerfectGame",0);
		numberGame = PlayerPrefs.GetInt("NumberGame",0);
//		totalScore = ScoreCard.TotalScore;
//		perfectGame = ScoreCard.PerfectGame;
//		numberGame = ScoreCard.NumberGame;
		if (GameObject.Find("EndureObject") == false) {
			if (perfectGame == purrfect) {
				Finalscore = totalScore*DiffMulti + PerfectBonus;
				PlayerPrefs.SetFloat("FinalScore",Finalscore);
			} else {
				if (SceneManager.GetActiveScene().name.Contains("Win")) {
					PerfectBonus = 0;
					Finalscore = totalScore*DiffMulti + PerfectBonus;
					PlayerPrefs.SetFloat("FinalScore",Finalscore);
				}
				if (SceneManager.GetActiveScene().name.Contains("Lose")) {
					Finalscore = 0f;
					PlayerPrefs.SetFloat("FinalScore",Finalscore);
				}
			}


			if (SceneManager.GetActiveScene().name.Contains("Easy")) {
				Social.ReportScore((long)Finalscore,SPRHresources.leaderboard_easy_leaders,(bool success) => {});
			}
			if (SceneManager.GetActiveScene().name.Contains("Med")) {
				Social.ReportScore((long)Finalscore*10,SPRHresources.leaderboard_medium_leaders,(bool success) => {});
			}
			if (SceneManager.GetActiveScene().name.Contains("Hard")) {
				Social.ReportScore((long)Finalscore*10,SPRHresources.leaderboard_hard_leaders,(bool success) => {});
			}
			if (SceneManager.GetActiveScene().name.Contains("Xprt")) {
				Social.ReportScore((long)Finalscore*10,SPRHresources.leaderboard_expert_leaders,(bool success) => {});
			}
			if (SceneManager.GetActiveScene().name.Contains("Insane")) {
				Social.ReportScore((long)Finalscore,SPRHresources.leaderboard_insane_leaders,(bool success) => {});
			}


		} else {
			Finalscore = totalScore;
			PlayerPrefs.SetFloat("FinalScore",Finalscore);
		}
		scoremanager = GameObject.FindObjectOfType <ScoreManager>();
		scoremanager.StoreHighscore();
		
		if (GameObject.FindGameObjectWithTag("Beep") == true) {
			Destroy (GameObject.FindGameObjectWithTag("Beep"),0.1f);
		}
	}
	
    void SceneSizer () {
        // screen measurements
        pixelsx = Screen.width;
		pixelsy = Screen.height;
		ratio = pixelsx/pixelsy;
        sizeX = 1000f * ratio;
        sizeY = 1000f;
		yLayoutChecker = layoutChecker.transform.position.y;
        
        safeMinX = Screen.safeArea.xMin;
        safeMaxX = Screen.safeArea.xMax;
        safeMinY = Screen.safeArea.yMin;
        safeMaxY = Screen.safeArea.yMax;
        safeMidX = (safeMinX + safeMaxX) / 2f;
        safeMidY = (safeMinY + safeMaxY) / 2f;
        safeHeight = safeMaxY - safeMinY;
        safeWidth = safeMaxX - safeMinX;

        safeUIMinX = (safeMinX/pixelsx) * 1000f * (pixelsx/pixelsy);
        safeUIMaxX = (safeMaxX/pixelsx) * 1000f * (pixelsx/pixelsy);
        safeUIMinY = (safeMinY/pixelsy) * 1000f;
        safeUIMaxY = (safeMaxY/pixelsy) * 1000f;
        safeUIMidX = (safeUIMinX + safeUIMaxX) / 2f;
        safeUIMidY = (safeUIMinY + safeUIMaxY) / 2f;
        safeUIHeight = safeUIMaxY - safeUIMinY;
        safeUIWidth = safeUIMaxX - safeUIMinX;

        // sizing of game objects
        backgroundImage.GetComponent<Transform>().localScale = new Vector2(ratio*safeWidth/pixelsx, safeHeight/pixelsy);

        backgroundBlockTop.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeX*1.5f,sizeY*0.25f);
        backgroundBlockRight.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeX*0.25f,sizeY*1.5f);
        backgroundBlockLeft.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeX*0.25f,sizeY*1.5f);
        backgroundBlockBottom.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeX*1.5f,sizeY*0.25f);

		Title.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*0.975f,safeUIHeight*0.125f);

        float ratioAdj = -0.3f;
        float widthAdj = 0.4f;
        float heightAdj = 0.075f;
        StartMenu.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*widthAdj, safeUIHeight*heightAdj*(ratio-ratioAdj));
        PlayAgain.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*widthAdj, safeUIHeight*heightAdj*(ratio-ratioAdj));
    }

    void SceneLayout () {
        backgroundImage.transform.position = new Vector3(12f*ratio*safeMidX/pixelsx - 6f*ratio,12f*safeMidY/pixelsy - 6f,1.5f);

        backgroundBlockTop.transform.position = new Vector3(pixelsx*0.5f,safeMaxY);
        backgroundBlockRight.transform.position = new Vector3(safeMaxX,pixelsy*0.5f);
        backgroundBlockLeft.transform.position = new Vector3(safeMinX,pixelsy*0.5f);
        backgroundBlockBottom.transform.position = new Vector3(pixelsx*0.5f,safeMinY);

        layoutChecker.transform.position = new UnityEngine.Vector3(3f*pixelsx, 4f*pixelsy, 0f);
        
		Playpos.x = safeMinX + safeWidth*0.26f;
		Playpos.y = safeMinY + safeHeight*0.15f;
		PlayAgain.transform.position = Playpos;
		
		Startpos.x = safeMinX + safeWidth*0.74f;
		Startpos.y = safeMinY + safeHeight*0.15f;
		StartMenu.transform.position = Startpos;
		
		Tpos.x = safeMidX;
		Tpos.y = safeMinY + safeHeight*0.9f;
		Title.transform.position = Tpos;
    }

	void OnGUI () {
		if (SceneManager.GetActiveScene().name.Contains("Win")) {
			GUI.Label (new Rect (safeMinX,(pixelsy - safeMaxY) + safeHeight*0.32f,safeWidth*0.58f,safeHeight*0.1f),"Total Score:  ", style2);
			GUI.Label (new Rect (safeMinX,(pixelsy - safeMaxY) + safeHeight*0.41f,safeWidth*0.58f,safeHeight*0.1f),"Difficulty Multiplier:  ", style2);
			GUI.Label (new Rect (safeMinX + safeWidth*0.58f,(pixelsy - safeMaxY) + safeHeight*0.32f,safeWidth*0.4f,safeHeight*0.1f),"  " + totalScore, style3);
			GUI.Label (new Rect (safeMinX + safeWidth*0.58f,(pixelsy - safeMaxY) + safeHeight*0.41f,safeWidth*0.4f,safeHeight*0.1f),"   x " + DiffMulti.ToString("f1"), style3);
			GUI.Label (new Rect (safeMinX,(pixelsy - safeMaxY) + safeHeight*0.5f,safeWidth*0.58f,safeHeight*0.1f),"Perfect Game Bonus:  ", style2);
			if (GameObject.Find("EndureObject") == false) {
				if (perfectGame == purrfect) {
					GUI.Label (new Rect (safeMinX + safeWidth*0.58f,(pixelsy - safeMaxY) + safeHeight*0.5f,safeWidth*0.4f,safeHeight*0.1f),"  + " + PerfectBonus, style3);
				} else {
					PerfectBonus = 0;
					GUI.Label (new Rect (safeMinX + safeWidth*0.58f,(pixelsy - safeMaxY) + safeHeight*0.5f,safeWidth*0.4f,safeHeight*0.1f),"  + " + PerfectBonus, style3);
				}
			}
			GUI.Label (new Rect (safeMinX,(pixelsy - safeMaxY) + safeHeight*0.6f,safeWidth*0.58f,safeHeight*0.13f),"Final Score:", style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.58f,(pixelsy - safeMaxY) + safeHeight*0.6f,safeWidth*0.4f,safeHeight*0.13f)," " + (PlayerPrefs.GetFloat("FinalScore",0f)), style4);
		}	
		if (SceneManager.GetActiveScene().name.Contains("Lose")) {
			if (GameObject.Find("EndureObject") == true) {
				GUI.Label (new Rect (safeMinX,(pixelsy - safeMaxY) + safeHeight*0.36f,safeWidth*0.58f,safeHeight*0.1f),"Total Games:  ", style2);
				GUI.Label (new Rect (safeMinX + safeWidth*0.58f,(pixelsy - safeMaxY) + safeHeight*0.36f,safeWidth*0.4f,safeHeight*0.1f),"  " + numberGame, style3);
				GUI.Label (new Rect (safeMinX,(pixelsy - safeMaxY) + safeHeight*0.45f,safeWidth*0.58f,safeHeight*0.1f),"Perfect Games:  ", style2);
				GUI.Label (new Rect (safeMinX + safeWidth*0.58f,(pixelsy - safeMaxY) + safeHeight*0.45f,safeWidth*0.4f,safeHeight*0.1f),"  " + perfectGame, style3);
				GUI.Label (new Rect (safeMinX,(pixelsy - safeMaxY) + safeHeight*0.55f,safeWidth*0.58f,safeHeight*0.13f),"Final Score:", style1);
				GUI.Label (new Rect (safeMinX + safeWidth*0.58f,(pixelsy - safeMaxY) + safeHeight*0.55f,safeWidth*0.4f,safeHeight*0.13f)," " + (totalScore), style4);
			} else {
				GUI.Label (new Rect (safeMinX,(pixelsy - safeMaxY) + safeHeight*0.36f,safeWidth*0.58f,safeHeight*0.1f),"Total Score:", style2);
				GUI.Label (new Rect (safeMinX + safeWidth*0.58f,(pixelsy - safeMaxY) + safeHeight*0.36f,safeWidth*0.4f,safeHeight*0.1f)," " + (totalScore), style3);
				GUI.Label (new Rect (safeMinX,(pixelsy - safeMaxY) + safeHeight*0.45f,safeWidth*0.58f,safeHeight*0.1f),"Lose Multiplier:  ", style2);
				GUI.Label (new Rect (safeMinX + safeWidth*0.58f,(pixelsy - safeMaxY) + safeHeight*0.45f,safeWidth*0.4f,safeHeight*0.1f),"  x 0", style3);
				GUI.Label (new Rect (safeMinX,(pixelsy - safeMaxY) + safeHeight*0.55f,safeWidth*0.58f,safeHeight*0.13f),"Final Score:", style1);
				GUI.Label (new Rect (safeMinX + safeWidth*0.58f,(pixelsy - safeMaxY) + safeHeight*0.55f,safeWidth*0.4f,safeHeight*0.13f)," 0", style4);
			}
		}
	}
}