using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Medium : MonoBehaviour {

	private Pegs pickup;
	private LevelManager levelmanager;
	private ScoreCard scorer;
	private ScoreCard perfecter;
	private ScoreCard gamer;
	private List<GameObject> Pegs = new List<GameObject> ();
	private List<GameObject> Colors = new List<GameObject> ();	
	private List<int> Switcher = new List<int> {0,1,2,3};

	private	int pegcount = 12;
	private int strikecount = 2;
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
	private List<int> Answers;
	
	private int indexkey;
	
	public GameObject TopRed;
	public GameObject TopBlue;
	public GameObject TopGreen;
	public GameObject TopBlack;
	public GameObject TopYellow;
		public GameObject TopMiddleRed;
		public GameObject TopMiddleBlue;
		public GameObject TopMiddleGreen;
		public GameObject TopMiddleBlack;
		public GameObject TopMiddleYellow;
	public GameObject BotMiddleRed;
	public GameObject BotMiddleBlue;
	public GameObject BotMiddleGreen;
	public GameObject BotMiddleBlack;
	public GameObject BotMiddleYellow;
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
		public GameObject ColliderBlock4;
	public GameObject InfoScreen;
	public GameObject Arrow;
	public GameObject StartButton;
		public GameObject TopDispPeg;
		public GameObject TopMidDispPeg;
		public GameObject BotMidDispPeg;
		public GameObject BotDispPeg;
	public GameObject TopDispHole;
	public GameObject TopMidDispHole;
	public GameObject BotMidDispHole;
	public GameObject BotDispHole;
	public GameObject DispHoleHole;
		public GameObject ScriptPegs;
		public GameObject ScriptHoles;
	public GameObject TopHole;
	public GameObject TopMidHole;
	public GameObject BotMidHole;
	public GameObject BotHole;
	public GameObject Lightoff;
		public GameObject ScoreScreen;
		public GameObject CoverDisplay;

    public GameObject backgroundBlockTop, backgroundBlockLeft, backgroundBlockRight, backgroundBlockBottom, backgroundImage;
    float pixelsx, pixelsy, ratio, sizeX, sizeY;
    float yTopEdge, yHeightAdj, xRightEdge, xWidthAdj, yMid, xMid;
    //safearea screen stuff
    private float safeMinX, safeMaxX, safeMinY, safeMaxY, safeMidX, safeMidY, safeHeight, safeWidth, safeUIMinX, safeUIMaxX, 
        safeUIMinY, safeUIMaxY, safeUIMidX, safeUIMidY, safeUIHeight, safeUIWidth;

	void Start () {
		PlayerPrefs.SetInt("PegsCanMove",0);
		GameObject.FindObjectOfType <Matcher>().MediumAnswers();
        
        SceneSizer();
        SceneLayout();
	
		Pegs.Add(TopRed);
		Pegs.Add(TopBlue);
		Pegs.Add(TopGreen);
		Pegs.Add(TopBlack);
		Pegs.Add(TopYellow);
			Pegs.Add(TopMiddleRed);
			Pegs.Add(TopMiddleBlue);
			Pegs.Add(TopMiddleGreen);
			Pegs.Add(TopMiddleBlack);
			Pegs.Add(TopMiddleYellow);
		Pegs.Add(BotMiddleRed);
		Pegs.Add(BotMiddleBlue);
		Pegs.Add(BotMiddleGreen);
		Pegs.Add(BotMiddleBlack);
		Pegs.Add(BotMiddleYellow);
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
		
		Instantiate (TopHole,new Vector2(xRightEdge - 1.2f,yTopEdge - 1.7f*yHeightAdj), Quaternion.identity);
		Instantiate (TopMidHole,new Vector2(xRightEdge - 1.2f,yTopEdge - 4.55f*yHeightAdj), Quaternion.identity);
		Instantiate (BotMidHole,new Vector2(xRightEdge - 1.2f,yTopEdge - 7.4f*yHeightAdj), Quaternion.identity);
		Instantiate (BotHole,new Vector2(xRightEdge - 1.2f,yTopEdge - 10.25f*yHeightAdj), Quaternion.identity);
		
		Instantiate (Lightoff,new Vector2(xRightEdge,yTopEdge - 1.7f*yHeightAdj), Quaternion.identity);
		Instantiate (Lightoff,new Vector2(xRightEdge,yTopEdge - 4.55f*yHeightAdj), Quaternion.identity);
		Instantiate (Lightoff,new Vector2(xRightEdge,yTopEdge - 7.4f*yHeightAdj), Quaternion.identity);
		Instantiate (Lightoff,new Vector2(xRightEdge,yTopEdge - 10.25f*yHeightAdj), Quaternion.identity);
		
		if (indexkey !=2) {
			Instantiate (Colors[Random.Range (0,5)],new Vector3(xRightEdge - 1.2f,yTopEdge - 1.7f*yHeightAdj,0.5f), Quaternion.identity);
			Instantiate (Colors[Random.Range (0,5)],new Vector3(xRightEdge - 1.2f,yTopEdge - 4.55f*yHeightAdj,0.5f), Quaternion.identity);
			Instantiate (Colors[Random.Range (0,5)],new Vector3(xRightEdge - 1.2f,yTopEdge - 7.4f*yHeightAdj,0.5f), Quaternion.identity);
			Instantiate (Colors[Random.Range (0,5)],new Vector3(xRightEdge - 1.2f,yTopEdge - 10.25f*yHeightAdj,0.5f), Quaternion.identity);
		} else {
			Instantiate (Colors[0],new Vector3(xRightEdge - 1.2f,yTopEdge - 1.7f*yHeightAdj,0.5f), Quaternion.identity);
			Instantiate (Colors[1],new Vector3(xRightEdge - 1.2f,yTopEdge - 4.55f*yHeightAdj,0.5f), Quaternion.identity);
			Instantiate (Colors[2],new Vector3(xRightEdge - 1.2f,yTopEdge - 7.4f*yHeightAdj,0.5f), Quaternion.identity);
			Instantiate (Colors[3],new Vector3(xRightEdge - 1.2f,yTopEdge - 10.25f*yHeightAdj,0.5f), Quaternion.identity);
		}
		
		Instantiate (ColliderBlock1,new Vector2(xRightEdge-0.2f,yTopEdge - (12 - (10.3f-(2.85f*Answers.IndexOf (1))))*yHeightAdj), Quaternion.identity);
		Instantiate (ColliderBlock2,new Vector2(xRightEdge-0.2f,yTopEdge - (12 - (10.3f-(2.85f*Answers.IndexOf (2))))*yHeightAdj), Quaternion.identity);
		Instantiate (ColliderBlock3,new Vector2(xRightEdge-0.2f,yTopEdge - (12 - (10.3f-(2.85f*Answers.IndexOf (3))))*yHeightAdj), Quaternion.identity);
		Instantiate (ColliderBlock4,new Vector2(xRightEdge-0.2f,yTopEdge - (12 - (10.3f-(2.85f*Answers.IndexOf (4))))*yHeightAdj), Quaternion.identity);
		
		Instantiate (InfoScreen,new Vector3(xMid,yMid,-2f), Quaternion.identity);
		Instantiate (StartButton,new Vector3(xRightEdge - 3f*xWidthAdj,yMid,-2.5f), Quaternion.identity);
		Instantiate (CoverDisplay,new Vector3(xMid,yMid,-1.5f), Quaternion.identity);
		Instantiate (ScriptPegs,new Vector3(xRightEdge - 9f*xWidthAdj - 2f,yTopEdge - 1.2f*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (ScriptHoles,new Vector3(xRightEdge - 9f*xWidthAdj + 2f,yTopEdge - 1.2f*yHeightAdj,-2.5f), Quaternion.identity);
		
		Instantiate (Arrow,new Vector3(xRightEdge - 9f*xWidthAdj,yTopEdge - 3f*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (Arrow,new Vector3(xRightEdge - 9f*xWidthAdj,yTopEdge - 5.45f*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (Arrow,new Vector3(xRightEdge - 9f*xWidthAdj,yTopEdge - 7.9f*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (Arrow,new Vector3(xRightEdge - 9f*xWidthAdj,yTopEdge - 10.35f*yHeightAdj,-2.5f), Quaternion.identity);
		
		int aa1 = Random.Range (0,Switcher.Count);
		int aa = Switcher[aa1];
		Switcher.RemoveAt (aa1);
		int bb1 = Random.Range (0,Switcher.Count);
		int bb = Switcher[bb1];
		Switcher.RemoveAt (bb1);
		int cc1 = Random.Range (0,Switcher.Count);
		int cc = Switcher[cc1];
		Switcher.RemoveAt (cc1);
		int dd1 = Random.Range (0,Switcher.Count);
		int dd = Switcher[dd1];
		
		Instantiate (TopDispPeg,new Vector3(xRightEdge - 9f*xWidthAdj - 2f,yTopEdge - (12f - (1.65f+2.45f*aa))*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (TopMidDispPeg,new Vector3(xRightEdge - 9f*xWidthAdj - 2f,yTopEdge - (12f - (1.65f+2.45f*bb))*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (BotMidDispPeg,new Vector3(xRightEdge - 9f*xWidthAdj - 2f,yTopEdge - (12f - (1.65f+2.45f*cc))*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (BotDispPeg,new Vector3(xRightEdge - 9f*xWidthAdj - 2f,yTopEdge - (12f - (1.65f+2.45f*dd))*yHeightAdj,-2.5f), Quaternion.identity);
		
		List<float> Pegspots = new List<float> {aa,bb,cc,dd};
		Instantiate (TopDispHole,new Vector3(xRightEdge - 9f*xWidthAdj + 2f,yTopEdge - (12f - (1.65f+(2.45f*Pegspots[Answers[0]-1])))*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (TopMidDispHole,new Vector3(xRightEdge - 9f*xWidthAdj + 2f,yTopEdge - (12f - (1.65f+(2.45f*Pegspots[Answers[1]-1])))*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (BotMidDispHole,new Vector3(xRightEdge - 9f*xWidthAdj + 2f,yTopEdge - (12f - (1.65f+(2.45f*Pegspots[Answers[2]-1])))*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (BotDispHole,new Vector3(xRightEdge - 9f*xWidthAdj + 2f,yTopEdge - (12f - (1.65f+(2.45f*Pegspots[Answers[3]-1])))*yHeightAdj,-2.5f), Quaternion.identity);
	
		if (SceneManager.GetActiveScene().name.Contains("Color")) {
		    Instantiate (DispHoleHole,new Vector3(xRightEdge - 9f*xWidthAdj + 2f,yTopEdge - (12f - (1.65f+(2.45f*Pegspots[Answers[0]-1])))*yHeightAdj,-3.5f), Quaternion.identity);
		    Instantiate (DispHoleHole,new Vector3(xRightEdge - 9f*xWidthAdj + 2f,yTopEdge - (12f - (1.65f+(2.45f*Pegspots[Answers[1]-1])))*yHeightAdj,-3.5f), Quaternion.identity);
		    Instantiate (DispHoleHole,new Vector3(xRightEdge - 9f*xWidthAdj + 2f,yTopEdge - (12f - (1.65f+(2.45f*Pegspots[Answers[2]-1])))*yHeightAdj,-3.5f), Quaternion.identity);
		    Instantiate (DispHoleHole,new Vector3(xRightEdge - 9f*xWidthAdj + 2f,yTopEdge - (12f - (1.65f+(2.45f*Pegspots[Answers[3]-1])))*yHeightAdj,-3.5f), Quaternion.identity); 
        }

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
		int x1 = Random.Range (0,5);
			int x2 = Random.Range (0,5);
			int x3 = Random.Range (0,5);
		int y1 = 5+Random.Range (0,5);
			int y2 = 5+Random.Range (0,5);
			int y3 = 5+Random.Range (0,5);
		int z1 = 10+Random.Range (0,5);
			int z2 = 10+Random.Range (0,5);
			int z3 = 10+Random.Range (0,5);
		int w1 = 15+Random.Range (0,5);
			int w2 = 15+Random.Range (0,5);
			int w3 = 15+Random.Range (0,5);
		
		indexkey = PlayerPrefs.GetInt("indexkey");//GameObject.Find("Matchbox").GetComponent<Matcher>().indexkey;
		Answers = new List<int> {PlayerPrefs.GetInt("Answers00"),PlayerPrefs.GetInt("Answers01"),PlayerPrefs.GetInt("Answers02"),PlayerPrefs.GetInt("Answers03")};
		List<int> Order = new List<int>{x1,x2,x3,y1,y2,y3,z1,z2,z3,w1,w2,w3};
		
		int a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 10.125f*xWidthAdj,yTopEdge - 9f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 7.875f*xWidthAdj,yTopEdge - 9f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 5.625f*xWidthAdj,yTopEdge - 9f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 3.375f*xWidthAdj,yTopEdge - 9f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 10.125f*xWidthAdj,yTopEdge - 6f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 7.875f*xWidthAdj,yTopEdge - 6f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 5.625f*xWidthAdj,yTopEdge - 6f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 3.375f*xWidthAdj,yTopEdge - 6f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 10.125f*xWidthAdj,yTopEdge - 3f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 7.875f*xWidthAdj,yTopEdge - 3f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 5.625f*xWidthAdj,yTopEdge - 3f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 3.375f*xWidthAdj,yTopEdge - 3f*yHeightAdj), Quaternion.identity);
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
			if (strikecount <= 0) {
				levelmanager = GameObject.FindObjectOfType <LevelManager>();
				levelmanager.LoadLevel("Lose Med");
			}
			scorer = GameObject.FindObjectOfType <ScoreCard>();
			scorer.ScoreKeeper();
		}
		if (strikecount <= 0) {
			levelmanager = GameObject.FindObjectOfType <LevelManager>();
			levelmanager.LoadLevel("Lose Med");
		}
	}
	
	void OnGUI () {
        // GUI.Label - x range starts at left hand side and is positive to the right, y range starts at top of screen and is positive downward
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
				
				GameObject Continue = GameObject.Find("Continue");
				Contpos.x = safeMidX;
				Contpos.y = safeMinY + safeHeight*0.1f;
				Continue.transform.position = Contpos;
			}
		}
	}
}