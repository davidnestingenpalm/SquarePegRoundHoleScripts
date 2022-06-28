using UnityEngine;
using System.Collections.Generic;

public class Insane : MonoBehaviour {

	private Pegs pickup;
	private LevelManager levelmanager;
	private ScoreCard scorer;
	private ScoreCard perfecter;
	private ScoreCard gamer;	
	private Insane insane;	
	private	int pegcount = 20;
	private int strikecount = 3;
	public int LevelScore;
	public int CurrentScore;
	private float timeremain;
	private float memtime;
	private int strikebonus;
	private int Memtimebonus;
	private int Timeleft;
	private GUIStyle style1 = new GUIStyle();
	private GUIStyle style2 = new GUIStyle();
	private GUIStyle style3 = new GUIStyle();
	private GUIStyle style4 = new GUIStyle();
	private GUIStyle style5 = new GUIStyle();
	public Font Myfont;
	public GameObject FinishNoise;
	private Vector2 Contpos;
	public GameObject ScoreScreen;

    public GameObject backgroundBlockTop, backgroundBlockLeft, backgroundBlockRight, backgroundBlockBottom, backgroundImage;
    float pixelsx, pixelsy, ratio, sizeX, sizeY;
    float yTopEdge, yHeightAdj, xRightEdge, xWidthAdj, yMid, xMid;
    //safearea screen stuff
    private float safeMinX, safeMaxX, safeMinY, safeMaxY, safeMidX, safeMidY, safeHeight, safeWidth, safeUIMinX, safeUIMaxX, 
        safeUIMinY, safeUIMaxY, safeUIMidX, safeUIMidY, safeUIHeight, safeUIWidth;

	void Start () {
		PlayerPrefs.SetInt("PegsCanMove",0);
		GameObject.FindObjectOfType <Matcher>().InsaneAnswers();
        
        SceneSizer();
        SceneLayout();
	
		style1.fontSize = (int) Mathf.Floor(Screen.height*0.15f);
		style1.normal.textColor = Color.white;
		style1.alignment = TextAnchor.MiddleCenter;
		style1.font = Myfont;
		
		style2.fontSize = (int) Mathf.Floor(Screen.height*0.07f);
		style2.normal.textColor = Color.white;
		style2.alignment = TextAnchor.MiddleRight;
		style2.font = Myfont;
		
		style3.fontSize = (int) Mathf.Floor(Screen.height*0.07f);
		style3.normal.textColor = Color.white;
		style3.alignment = TextAnchor.MiddleLeft;
		style3.font = Myfont;
		
		style4.fontSize = (int) Mathf.Floor(Screen.height*0.07f);
		style4.normal.textColor = Color.yellow;
		style4.alignment = TextAnchor.MiddleRight;
		style4.font = Myfont;
		
		style5.fontSize = (int) Mathf.Floor(Screen.height*0.07f);
		style5.normal.textColor = Color.yellow;
		style5.alignment = TextAnchor.MiddleLeft;
		style5.font = Myfont;
		
		GameObject Continue = GameObject.Find("Continue");
		Contpos.x = Screen.width*0.5f;
		Contpos.y = Screen.height*-0.25f;
		Continue.transform.position = Contpos;
		Continue.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*0.2f,safeUIHeight*0.1f);
	}

    void SceneSizer () {
        // screen measurements
        pixelsx = Screen.width;
		pixelsy = Screen.height;
		ratio = pixelsx/pixelsy;
        sizeX = 1000f * ratio;
        sizeY = 1000f;
        
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
        
        yTopEdge = 12f*safeMaxY/pixelsy - 6f;
        yHeightAdj = safeHeight/pixelsy;
        xRightEdge = 12f*ratio*safeMaxX/pixelsx - 6f*ratio;
        xWidthAdj = ratio*safeWidth/pixelsx;
        yMid = 12f*safeMidY/pixelsy - 6f;
        xMid = 12f*ratio*safeMidX/pixelsx - 6f*ratio;

        // sizing of game objects
        backgroundImage.GetComponent<Transform>().localScale = new Vector2(ratio*safeWidth/pixelsx, safeHeight/pixelsy);

        backgroundBlockTop.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeX*1.5f,sizeY*0.25f);
        backgroundBlockRight.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeX*0.25f,sizeY*1.5f);
        backgroundBlockLeft.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeX*0.25f,sizeY*1.5f);
        backgroundBlockBottom.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeX*1.5f,sizeY*0.25f);
    }

    void SceneLayout () {        
        // background
        backgroundImage.transform.position = new Vector3(12f*ratio*safeMidX/pixelsx - 6f*ratio,12f*safeMidY/pixelsy - 6f,1.5f);

        backgroundBlockTop.transform.position = new Vector3(pixelsx*0.5f,safeMaxY);
        backgroundBlockRight.transform.position = new Vector3(safeMaxX,pixelsy*0.5f);
        backgroundBlockLeft.transform.position = new Vector3(safeMinX,pixelsy*0.5f);
        backgroundBlockBottom.transform.position = new Vector3(pixelsx*0.5f,safeMinY);
    }
	
	public void StrikeDestroyed () {
		strikecount--;
	}
	
	public void PegDestroyed () {
		pegcount--;
		pickup = GameObject.FindObjectOfType <Pegs>();
		if (pegcount <= 0){
			if (GameObject.FindGameObjectWithTag("Beep") == true) {
				Destroy (GameObject.FindGameObjectWithTag("Beep"));
			}
			if (strikecount >= 0) {
				gamer = GameObject.FindObjectOfType <ScoreCard>();
				gamer.NumberGameKeeper();
				if (GameObject.FindGameObjectWithTag ("NoSFX") == false) {
					GameObject FN = (GameObject) Instantiate (FinishNoise,new Vector2(0f,0f), Quaternion.identity);
					Destroy (FN,1f);
				}
			}
			CurrentScore = PlayerPrefs.GetInt("TotalScore",0);
//			CurrentScore = ScoreCard.TotalScore;
			timeremain = GameObject.Find("Main Camera").GetComponent<Timer>().Timeleft;
			memtime = GameObject.Find("Main Camera").GetComponent<Timer>().Memorizetime;
			Memtimebonus = (int) Mathf.Round(memtime*100);
			Timeleft = (int) Mathf.Round(timeremain*100);
			Instantiate (ScoreScreen,new Vector3(xMid,yMid,-3f), Quaternion.identity);
			if (strikecount == 3) {	
				strikebonus = 500;		
				perfecter = GameObject.FindObjectOfType <ScoreCard>();
				perfecter.PerfectGameKeeper();
				LevelScore = Memtimebonus + Timeleft + strikecount*500 + strikebonus;
			}
			if (strikecount > 0 && strikecount < 3){
				strikebonus = 0;
				LevelScore = Memtimebonus + Timeleft + strikecount*500 + strikebonus;
			}
			if (strikecount <= 0) {
				levelmanager = GameObject.FindObjectOfType <LevelManager>();
				levelmanager.LoadLevel("Lose Insane");
			}
			scorer = GameObject.FindObjectOfType <ScoreCard>();
			scorer.ScoreKeeper();
		}
		if (strikecount <= 0) {
			levelmanager = GameObject.FindObjectOfType <LevelManager>();
			levelmanager.LoadLevel("Lose Insane");
		}
	}
	
	void OnGUI () {
        // GUI.Label - x range starts at left hand side and is positive to the right, y range starts at top of screen and is positive downward
		if (pegcount <= 0) {
			if (strikecount > 0) {
				GUI.Label (new Rect (safeMinX,(pixelsy - safeMaxY) + safeHeight*0.05f,safeWidth,Screen.height*0.18f),"Score",style1);
				GUI.Label (new Rect (safeMinX,(pixelsy - safeMaxY) + safeHeight*0.32f,safeWidth*0.58f,Screen.height*0.1f),"Memory Bonus:  ", style2);
				GUI.Label (new Rect (safeMinX,(pixelsy - safeMaxY) + safeHeight*0.42f,safeWidth*0.58f,Screen.height*0.1f),"Time Left:  ", style2);
				GUI.Label (new Rect (safeMinX + safeWidth*0.58f,(pixelsy - safeMaxY) + safeHeight*0.32f,safeWidth*0.4f,Screen.height*0.1f),"  + " + Memtimebonus, style3);
				GUI.Label (new Rect (safeMinX + safeWidth*0.58f,(pixelsy - safeMaxY) + safeHeight*0.42f,safeWidth*0.4f,Screen.height*0.1f),"  + " + Timeleft, style3);
				if (strikecount == 3f) {
					GUI.Label (new Rect (safeMinX,(pixelsy - safeMaxY) + safeHeight*0.52f,safeWidth*0.58f,Screen.height*0.1f),"Perfect Level:  ", style2);
					GUI.Label (new Rect (safeMinX + safeWidth*0.58f,(pixelsy - safeMaxY) + safeHeight*0.52f,safeWidth*0.4f,Screen.height*0.1f),"  + " +(strikecount*500+strikebonus), style3);
				} else {
					GUI.Label (new Rect (safeMinX,(pixelsy - safeMaxY) + safeHeight*0.52f,safeWidth*0.58f,Screen.height*0.1f),"Strikes Bonus:  ", style2);
					GUI.Label (new Rect (safeMinX + safeWidth*0.58f,(pixelsy - safeMaxY) + safeHeight*0.52f,safeWidth*0.4f,Screen.height*0.1f),"  + " +(strikecount*500), style3);
				}
				GUI.Label (new Rect (safeMinX,(pixelsy - safeMaxY) + safeHeight*0.65f,safeWidth*0.58f,Screen.height*0.1f),"Total Score:  ", style4);
				GUI.Label (new Rect (safeMinX + safeWidth*0.58f,(pixelsy - safeMaxY) + safeHeight*0.65f,safeWidth*0.4f,Screen.height*0.1f),"  " + (LevelScore + CurrentScore), style5);
				
				GameObject Continue = GameObject.Find("Continue");
				Contpos.x = safeMidX;
				Contpos.y = safeMinY + safeHeight*0.1f;
				Continue.transform.position = Contpos;
			}
		}
	}
}