using UnityEngine;
using System.Collections.Generic;

public class Tutorial : MonoBehaviour {

	private LevelManager levelmanager;
	private ScoreCard scorer;
	private ScoreCard perfecter;
	private List<GameObject> Pegstrial = new List<GameObject> ();
	private List<GameObject> Pegs = new List<GameObject> ();
	private List<GameObject> Colors = new List<GameObject> ();
	public List<int> Answers = new List<int> ();
	public List<int> Order = new List<int> ();
	
	private	int pegcount = 9;
	private int strikecount = 2;
	private float TutorialClock;
	public int LevelScore;
	public int CurrentScore;
	private float timeremain;
	private float memtime;
	private int strikebonus;
	private int Memtimebonus;
	private int Timeleft;
	private float speed = 30f;
	private GUIStyle style1 = new GUIStyle();
	private GUIStyle style2 = new GUIStyle();
	private GUIStyle style3 = new GUIStyle();
	private GUIStyle style4 = new GUIStyle();
	private GUIStyle style5 = new GUIStyle();
	private GUIStyle style6 = new GUIStyle();
	private GUIStyle style7 = new GUIStyle();
	private GUIStyle style8 = new GUIStyle();
	public Font Myfont;
	public GameObject FinishNoise;

	private int indexkey;
	
	public GameObject TopRed;
	public GameObject TopBlue;
	public GameObject TopGreen;
	public GameObject TopBlack;
	public GameObject TopYellow;
	public GameObject MiddleRed;
	public GameObject MiddleBlue;
	public GameObject MiddleGreen;
	public GameObject MiddleBlack;
	public GameObject MiddleYellow;
	public GameObject BottomRed;
	public GameObject BottomBlue;
	public GameObject BottomGreen;
	public GameObject BottomBlack;
	public GameObject BottomYellow;
	public GameObject HoleRed;
	public GameObject HoleBlue;
	public GameObject HoleGreen;
	public GameObject HoleBlack;
	public GameObject HoleYellow;
	public GameObject ColliderBlock1;
	public GameObject ColliderBlock2;
	public GameObject ColliderBlock3;
	public GameObject InfoScreen;
	public GameObject Arrow;
	public GameObject StartButton;
	public GameObject TopDispPeg;
	public GameObject MidDispPeg;
	public GameObject BotDispPeg;
	public GameObject TopDispHole;
	public GameObject MidDispHole;
	public GameObject BotDispHole;
	public GameObject ScriptPegs;
	public GameObject ScriptHoles;
	public GameObject TopHole;
	public GameObject MidHole;
	public GameObject BotHole;
	public GameObject Lightoff;
	public GameObject ScoreScreen;
	public GameObject Cover;
	
	private int a;
	private int b;
	private int c;
	private int d;
	private int e;
	private int f;
	private int g;
	private int h;
	private int i;
	
	private ScoreCard zeroer;

    public GameObject backgroundBlockTop, backgroundBlockLeft, backgroundBlockRight, backgroundBlockBottom, backgroundImage;
    float pixelsx, pixelsy, ratio, sizeX, sizeY;
    float yTopEdge, yHeightAdj, xRightEdge, xWidthAdj, yMid, xMid;
    //safearea screen stuff
    private float safeMinX, safeMaxX, safeMinY, safeMaxY, safeMidX, safeMidY, safeHeight, safeWidth, safeUIMinX, safeUIMaxX, 
        safeUIMinY, safeUIMaxY, safeUIMidX, safeUIMidY, safeUIHeight, safeUIWidth;

	void Start () {
		zeroer = GameObject.FindObjectOfType <ScoreCard>();
		zeroer.EraseScores();
		GameObject.FindObjectOfType <Matcher>().EasyAnswers();
        
        SceneSizer();
        SceneLayout();
		
		Pegs.Add(TopRed);
		Pegs.Add(TopBlue);
		Pegs.Add(TopGreen);
		Pegs.Add(TopBlack);
		Pegs.Add(TopYellow);
		Pegs.Add(MiddleRed);
		Pegs.Add(MiddleBlue);
		Pegs.Add(MiddleGreen);
		Pegs.Add(MiddleBlack);
		Pegs.Add(MiddleYellow);
		Pegs.Add(BottomRed);
		Pegs.Add(BottomBlue);
		Pegs.Add(BottomGreen);
		Pegs.Add(BottomBlack);
		Pegs.Add(BottomYellow);
		Colors.Add(HoleRed);
		Colors.Add(HoleBlue);
		Colors.Add(HoleGreen);
		Colors.Add(HoleBlack);
		Colors.Add(HoleYellow);
            
        yTopEdge = 12f*safeMaxY/pixelsy - 6f;
        yHeightAdj = safeHeight/pixelsy;
        xRightEdge = 12f*ratio*safeMaxX/pixelsx - 6f*ratio;
        xWidthAdj = ratio*safeWidth/pixelsx;
        yMid = 12f*safeMidY/pixelsy - 6f;
        xMid = 12f*ratio*safeMidX/pixelsx - 6f*ratio;

        PegPlacement();

		Instantiate (TopHole,new Vector2(xRightEdge - 1.2f,yTopEdge - 3f*yHeightAdj), Quaternion.identity);
		Instantiate (MidHole,new Vector2(xRightEdge - 1.2f,yTopEdge - 6f*yHeightAdj), Quaternion.identity);
		Instantiate (BotHole,new Vector2(xRightEdge - 1.2f,yTopEdge - 9f*yHeightAdj), Quaternion.identity);
		
		Instantiate (Lightoff,new Vector2(xRightEdge,yTopEdge - 3f*yHeightAdj), Quaternion.identity);
		Instantiate (Lightoff,new Vector2(xRightEdge,yTopEdge - 6f*yHeightAdj), Quaternion.identity);
		Instantiate (Lightoff,new Vector2(xRightEdge,yTopEdge - 9f*yHeightAdj), Quaternion.identity);

		Instantiate (Colors[Random.Range (0,5)],new Vector3(xRightEdge - 1.2f,yTopEdge - 3f*yHeightAdj,0.5f), Quaternion.identity);
		Instantiate (Colors[Random.Range (0,5)],new Vector3(xRightEdge - 1.2f,yTopEdge - 6f*yHeightAdj,0.5f), Quaternion.identity);
		Instantiate (Colors[Random.Range (0,5)],new Vector3(xRightEdge - 1.2f,yTopEdge - 9f*yHeightAdj,0.5f), Quaternion.identity);
		
		Instantiate (ColliderBlock1,new Vector2(xRightEdge,yTopEdge - (12f - (9f-(3*Answers.IndexOf (1))))*yHeightAdj), Quaternion.identity);
		Instantiate (ColliderBlock2,new Vector2(xRightEdge,yTopEdge - (12f - (9f-(3*Answers.IndexOf (2))))*yHeightAdj), Quaternion.identity);
		Instantiate (ColliderBlock3,new Vector2(xRightEdge,yTopEdge - (12f - (9f-(3*Answers.IndexOf (3))))*yHeightAdj), Quaternion.identity);
		
		Instantiate (InfoScreen,new Vector3(xMid,yMid,-2f), Quaternion.identity);
		Instantiate (StartButton,new Vector3(xRightEdge - 3f*xWidthAdj,yMid,-2.5f), Quaternion.identity);							
		Instantiate (ScriptPegs,new Vector3(xRightEdge - 9f*xWidthAdj - 1.5f,yTopEdge - 1.8f*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (ScriptHoles,new Vector3(xRightEdge - 9f*xWidthAdj + 1.5f,yTopEdge - 1.8f*yHeightAdj,-2.5f), Quaternion.identity);
		
		Instantiate (Arrow,new Vector3(xRightEdge - 9f*xWidthAdj,yTopEdge - 3.8f*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (Arrow,new Vector3(xRightEdge - 9f*xWidthAdj,yTopEdge - 6.5f*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (Arrow,new Vector3(xRightEdge - 9f*xWidthAdj,yTopEdge - 9.2f*yHeightAdj,-2.5f), Quaternion.identity);
		
		Instantiate (TopDispPeg,new Vector3(xRightEdge - 9f*xWidthAdj - 1.5f,yTopEdge - 3.8f*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (MidDispPeg,new Vector3(xRightEdge - 9f*xWidthAdj - 1.5f,yTopEdge - 6.5f*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (BotDispPeg,new Vector3(xRightEdge - 9f*xWidthAdj - 1.5f,yTopEdge - 9.2f*yHeightAdj,-2.5f), Quaternion.identity);

		Instantiate (TopDispHole,new Vector3(xRightEdge - 9f*xWidthAdj + 1.5f,yTopEdge - (12f - (10.9f-(2.7f*Answers[0])))*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (MidDispHole,new Vector3(xRightEdge - 9f*xWidthAdj + 1.5f,yTopEdge - (12f - (10.9f-(2.7f*Answers[1])))*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (BotDispHole,new Vector3(xRightEdge - 9f*xWidthAdj + 1.5f,yTopEdge - (12f - (10.9f-(2.7f*Answers[2])))*yHeightAdj,-2.5f), Quaternion.identity);	
		
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
		
		style6.fontSize = (int) Mathf.Floor(Screen.height*0.07f);
		style6.normal.textColor = Color.yellow;
		style6.alignment = TextAnchor.MiddleCenter;
		style6.wordWrap = true;
		style6.font = Myfont;
		
		style7.fontSize = (int) Mathf.Floor(Screen.height*0.07f);
		style7.normal.textColor = Color.white;
		style7.alignment = TextAnchor.MiddleCenter;
		style7.wordWrap = true;
		style7.font = Myfont;
		
		style8.fontSize = (int) Mathf.Floor(Screen.height*0.2f);
		style8.normal.textColor = Color.blue;
		style8.alignment = TextAnchor.MiddleCenter;
		style8.wordWrap = true;
		style8.font = Myfont;
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

    void PegPlacement() {
		Answers = new List<int> {PlayerPrefs.GetInt("Answers00"),PlayerPrefs.GetInt("Answers01"),PlayerPrefs.GetInt("Answers02")};;
		Instantiate (Cover,new Vector3(-4.2f+(6f*ratio-7.5f),6f,-2.75f), Quaternion.identity);
		
		a = Random.Range (5,10);
		Instantiate (Pegs[a],new Vector2(xRightEdge - 9f*xWidthAdj,yTopEdge - 9f*yHeightAdj), Quaternion.identity);
		Pegstrial.Add (Pegs[a]);
		Pegs.RemoveAt (a);
		
		b = Random.Range (5,9);
		Instantiate (Pegs[b],new Vector2(xRightEdge - 6.75f*xWidthAdj,yTopEdge - 9f*yHeightAdj), Quaternion.identity);
		Pegstrial.Add (Pegs[b]);
		Pegs.RemoveAt (b);
		
		c = Random.Range (5,8);
		Instantiate (Pegs[c],new Vector2(xRightEdge - 4.5f*xWidthAdj,yTopEdge - 9f*yHeightAdj), Quaternion.identity);
		Pegstrial.Add (Pegs[c]);
		Pegs.RemoveAt (c);
		
		d = Random.Range (0,5);
		Instantiate (Pegs[d],new Vector2(xRightEdge - 9f*xWidthAdj,yTopEdge - 6f*yHeightAdj), Quaternion.identity);
		Pegstrial.Add (Pegs[d]);
		Pegs.RemoveAt (d);
		
		e = Random.Range (0,4);
		Instantiate (Pegs[e],new Vector2(xRightEdge - 6.75f*xWidthAdj,yTopEdge - 6f*yHeightAdj), Quaternion.identity);
		Pegstrial.Add (Pegs[e]);
		Pegs.RemoveAt (e);
		
		f = Random.Range (0,3);
		Instantiate (Pegs[f],new Vector2(xRightEdge - 4.5f*xWidthAdj,yTopEdge - 6f*yHeightAdj), Quaternion.identity);
		Pegstrial.Add (Pegs[f]);
		Pegs.RemoveAt (f);
		
		g = Random.Range (4,Pegs.Count);
		Instantiate (Pegs[g],new Vector2(xRightEdge - 9f*xWidthAdj,yTopEdge - 3f*yHeightAdj), Quaternion.identity);
		Pegstrial.Add (Pegs[g]);
		Pegs.RemoveAt (g);
		
		h = Random.Range (4,Pegs.Count);
		Instantiate (Pegs[h],new Vector2(xRightEdge - 6.75f*xWidthAdj,yTopEdge - 3f*yHeightAdj), Quaternion.identity);
		Pegstrial.Add (Pegs[h]);
		Pegs.RemoveAt (h);
		
		i = Random.Range (4,Pegs.Count);
		Instantiate (Pegs[i],new Vector2(xRightEdge - 4.5f*xWidthAdj,yTopEdge - 3f*yHeightAdj), Quaternion.identity);
		Pegstrial.Add (Pegs[i]);
    }
	
	public void StrikeDestroyed () {
		strikecount--;
	}
	
	public void PegDestroyed () {
		pegcount--;
		if (pegcount <= 0){
			if (GameObject.FindGameObjectWithTag("Beep") == true) {
				Destroy (GameObject.FindGameObjectWithTag("Beep"));
			}
			if (strikecount >= 0) {
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
			if (strikecount == 2) {	
				strikebonus = 500;		
				perfecter = GameObject.FindObjectOfType <ScoreCard>();
				perfecter.PerfectGameKeeper();
				LevelScore = Memtimebonus + Timeleft + strikecount*500 + strikebonus;
			}
			if (strikecount > 0 && strikecount < 2){
				strikebonus = 0;
				LevelScore = Memtimebonus + Timeleft + strikecount*500 + strikebonus;
			}
			scorer = GameObject.FindObjectOfType <ScoreCard>();
			scorer.ScoreKeeper();
		}
	}
	
	void OnGUI () {
        // GUI.Label - x range starts at left hand side and is positive to the right, y range starts at top of screen and is positive downward
		if (TutorialClock >= 0.5f*speed && TutorialClock <= 5.5f*speed) {
			GUI.Label (new Rect (safeMidX,(pixelsy - safeMaxY) + safeHeight*0.025f,safeWidth*0.475f,safeHeight*0.3f),"Welcome to Square Peg Round Hole!",style6);
		}
		if (TutorialClock >= 5.7f*speed && TutorialClock <= 12.7f*speed) {
			GUI.Label (new Rect (safeMidX,(pixelsy - safeMaxY) + safeHeight*0.025f,safeWidth*0.475f,safeHeight*0.3f),"Memorize which hole each peg goes into, as shown on the left.",style6);
		}
		if (TutorialClock >= 12.9f*speed && TutorialClock <= 16.9f*speed) {
			GUI.Label (new Rect (safeMidX,(pixelsy - safeMaxY) + safeHeight*0.025f,safeWidth*0.475f,safeHeight*0.3f),"The timer below is only a memory bonus timer.",style6);
		}
		if (TutorialClock >= 17.1f*speed && TutorialClock <= 21.6f*speed) {
			GUI.Label (new Rect (safeMidX,(pixelsy - safeMaxY) + safeHeight*0.025f,safeWidth*0.475f,safeHeight*0.3f),"The level will not start if this timer reaches zero.",style6);
		}
		if (TutorialClock >= 21.8f*speed && TutorialClock <= 26f*speed) {
			GUI.Label (new Rect (safeMidX,(pixelsy - safeMaxY) + safeHeight*0.025f,safeWidth*0.475f,safeHeight*0.3f),"The level starts when you touch the start button below, like this.",style6);
		}
		if (TutorialClock >= 26f*speed && TutorialClock <= 26.5f*speed) {
			if (GameObject.FindWithTag("display") != null){
				GameObject [] Displays = GameObject.FindGameObjectsWithTag("display");
				foreach (GameObject display in Displays){
					GameObject.Destroy(display);
				}
			}
		}
		if (TutorialClock >= 26.2f*speed && TutorialClock <= 30f*speed) {
			GUI.Label (new Rect (safeMinX + safeWidth*0.05f,(pixelsy - safeMaxY) + safeHeight*0.025f,safeWidth*0.9f,safeHeight*0.1f),"Drag the pegs to the correct holes.",style7);
		}
		if (TutorialClock >= 30.2f*speed && TutorialClock <= 36f*speed) {
			GUI.Label (new Rect (safeMinX + safeWidth*0.05f,(pixelsy - safeMaxY) + safeHeight*0.025f,safeWidth*0.9f,safeHeight*0.1f),"If correct, a chime will sound and the light will turn green.",style7);
		}
		if (TutorialClock >= 36.2f*speed && TutorialClock <= 42f*speed) {
			GUI.Label (new Rect (safeMinX + safeWidth*0.05f,(pixelsy - safeMaxY) + safeHeight*0.025f,safeWidth*0.9f,safeHeight*0.1f),"If wrong, you'll hear a buzz and the light will turn red.",style7);
		}
		if (TutorialClock >= 42.2f*speed && TutorialClock <= 47f*speed) {
			GUI.Label (new Rect (safeMinX + safeWidth*0.05f,(pixelsy - safeMaxY) + safeHeight*0.025f,safeWidth*0.9f,safeHeight*0.1f),"One strike will also disappear, when a peg is placed incorrectly.",style7);
		}
		if (TutorialClock >= 47.2f*speed && TutorialClock <= 52f*speed) {
			GUI.Label (new Rect (safeMinX + safeWidth*0.05f,(pixelsy - safeMaxY) + safeHeight*0.025f,safeWidth*0.9f,safeHeight*0.1f),"Run out of strikes, or run out of time, and you lose.",style7);
		}
		if (TutorialClock >= 52.2f*speed && TutorialClock <= 56f*speed) {
			GUI.Label (new Rect (safeMinX + safeWidth*0.05f,(pixelsy - safeMaxY) + safeHeight*0.025f,safeWidth*0.9f,safeHeight*0.1f),"Place the pegs correctly to win!",style7);
		}
		if (TutorialClock >= 56.2f*speed) {
			GUI.Label (new Rect (safeMinX,(pixelsy - safeMaxY) + safeHeight*0.2f,safeWidth,safeHeight*0.6f),"Good Luck!",style8);
		}
	
		if (pegcount <= 0) {
			if (strikecount > 0) {
				GUI.Label (new Rect (safeMinX,(pixelsy - safeMaxY) + safeHeight*0.05f,safeWidth,safeHeight*0.18f),"Score",style1);
				GUI.Label (new Rect (safeMinX,(pixelsy - safeMaxY) + safeHeight*0.32f,safeWidth*0.58f,safeHeight*0.1f),"Memory Bonus:  ", style2);
				GUI.Label (new Rect (safeMinX,(pixelsy - safeMaxY) + safeHeight*0.42f,safeWidth*0.58f,safeHeight*0.1f),"Time Left:  ", style2);
				GUI.Label (new Rect (safeMinX + safeWidth*0.58f,(pixelsy - safeMaxY) + safeHeight*0.32f,safeWidth*0.4f,safeHeight*0.1f),"  + " + Memtimebonus, style3);
				GUI.Label (new Rect (safeMinX + safeWidth*0.58f,(pixelsy - safeMaxY) + safeHeight*0.42f,safeWidth*0.4f,safeHeight*0.1f),"  + " + Timeleft, style3);
				if (strikecount == 2f) {
					GUI.Label (new Rect (safeMinX,(pixelsy - safeMaxY) + safeHeight*0.52f,safeWidth*0.58f,safeHeight*0.1f),"Perfect Level:  ", style2);
					GUI.Label (new Rect (safeMinX + safeWidth*0.58f,(pixelsy - safeMaxY) + safeHeight*0.52f,safeWidth*0.4f,safeHeight*0.1f),"  + " +(strikecount*500+strikebonus), style3);
				} else {
					GUI.Label (new Rect (safeMinX,(pixelsy - safeMaxY) + safeHeight*0.52f,safeWidth*0.58f,safeHeight*0.1f),"Strikes Bonus:  ", style2);
					GUI.Label (new Rect (safeMinX + safeWidth*0.58f,(pixelsy - safeMaxY) + safeHeight*0.52f,safeWidth*0.4f,safeHeight*0.1f),"  + " +(strikecount*500), style3);
				}
				GUI.Label (new Rect (safeMinX,(pixelsy - safeMaxY) + safeHeight*0.65f,safeWidth*0.58f,safeHeight*0.1f),"Total Score:  ", style4);
				GUI.Label (new Rect (safeMinX + safeWidth*0.58f,(pixelsy - safeMaxY) + safeHeight*0.65f,safeWidth*0.4f,safeHeight*0.1f),"  " + (LevelScore + CurrentScore), style5);
			}
		}
	}

	void Update () {
		TutorialClock += Time.deltaTime*speed;
		if (GameObject.Find((Pegstrial[0].transform.name)+"(Clone)") == true) {
			if (TutorialClock >= 33.0f*speed) {
				GameObject Peg2a = GameObject.Find((Pegstrial[0].transform.name)+"(Clone)");
				Peg2a.transform.position = new Vector3(xRightEdge - 9f*xWidthAdj+(TutorialClock/3-11f*speed),yTopEdge - 9f*yHeightAdj,-1f);
			}
		}
		if (GameObject.Find((Pegstrial[1].transform.name)+"(Clone)") == true) {
			if (TutorialClock >= 39.0f*speed) {
				GameObject Peg2a = GameObject.Find((Pegstrial[1].transform.name)+"(Clone)");
			Peg2a.transform.position = new Vector3(xRightEdge - 6.75f*xWidthAdj+(TutorialClock/3-13f*speed),yTopEdge - 9f*yHeightAdj+(TutorialClock/(10f-6f*((16f/9f)-ratio))-(39f/(10f-6f*((16f/9f)-ratio)))*speed),-1f);
			}
		}
		if (GameObject.Find((Pegstrial[2].transform.name)+"(Clone)") == true) {
			if (TutorialClock >= 54.2f*speed) {
				GameObject Peg2a = GameObject.Find((Pegstrial[2].transform.name)+"(Clone)");
				Peg2a.transform.position = new Vector3(xRightEdge - 4.5f*xWidthAdj+(TutorialClock-54.2f*speed),yTopEdge - 9f*yHeightAdj,-1f);
			}
		}
		if (GameObject.Find((Pegstrial[5].transform.name)+"(Clone)") == true) {
			if (TutorialClock >= 54.4f*speed) {
				GameObject Peg2a = GameObject.Find((Pegstrial[5].transform.name)+"(Clone)");
				Peg2a.transform.position = new Vector3(xRightEdge - 4.5f*xWidthAdj+(TutorialClock-54.4f*speed),yTopEdge - 6f*yHeightAdj,-1f);
			}
		}
		if (GameObject.Find((Pegstrial[4].transform.name)+"(Clone)") == true) {
			if (TutorialClock >= 54.6f*speed) {
				GameObject Peg2a = GameObject.Find((Pegstrial[4].transform.name)+"(Clone)");
				Peg2a.transform.position = new Vector3(xRightEdge - 6.75f*xWidthAdj+(TutorialClock-54.6f*speed),yTopEdge - 6f*yHeightAdj,-1f);
			}
		}
		if (GameObject.Find((Pegstrial[3].transform.name)+"(Clone)") == true) {
			if (TutorialClock >= 54.8f*speed) {
				GameObject Peg2a = GameObject.Find((Pegstrial[3].transform.name)+"(Clone)");
				Peg2a.transform.position = new Vector3(xRightEdge - 9f*xWidthAdj+(TutorialClock-54.8f*speed),yTopEdge - 6f*yHeightAdj,-1f);
			}
		}
		if (GameObject.Find((Pegstrial[8].transform.name)+"(Clone)") == true) {
			if (TutorialClock >= 55.0f*speed) {
				GameObject Peg2a = GameObject.Find((Pegstrial[8].transform.name)+"(Clone)");
				Peg2a.transform.position = new Vector3(xRightEdge - 4.5f*xWidthAdj+(TutorialClock-55.0f*speed),yTopEdge - 3f*yHeightAdj,-1f);
			}
		}
		if (GameObject.Find((Pegstrial[7].transform.name)+"(Clone)") == true) {
			if (TutorialClock >= 55.2f*speed) {
				GameObject Peg2a = GameObject.Find((Pegstrial[7].transform.name)+"(Clone)");
				Peg2a.transform.position = new Vector3(xRightEdge - 6.75f*xWidthAdj+(TutorialClock-55.2f*speed),yTopEdge - 3f*yHeightAdj,-1f);
			}
		}
		if (GameObject.Find((Pegstrial[6].transform.name)+"(Clone)") == true) {
			if (TutorialClock >= 55.4f*speed) {
				GameObject Peg2a = GameObject.Find((Pegstrial[6].transform.name)+"(Clone)");
				Peg2a.transform.position = new Vector3(xRightEdge - 9f*xWidthAdj+(TutorialClock-55.4f*speed),yTopEdge - 3f*yHeightAdj,-1f);
			}
		}
	}
}