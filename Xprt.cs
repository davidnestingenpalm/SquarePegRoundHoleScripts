using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Xprt : MonoBehaviour {

	private Pegs pickup;
	private LevelManager levelmanager;
	private ScoreCard scorer;
	private ScoreCard perfecter;
	private ScoreCard gamer;
	private Matcher match;
	private List<GameObject> Pegs = new List<GameObject> ();
	private List<GameObject> Colors = new List<GameObject> ();
	private List<int> Switcher = new List<int> {0,1,2};
	private List<int> Switcher1 = new List<int> {0,1,2};
	private List<int> XprtAns,Answers,Answers1;
	
	private	int pegcount = 18;
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
	
	public GameObject TopRed1;
	public GameObject TopBlue1;
	public GameObject TopGreen1;
	public GameObject TopBlack1;
	public GameObject TopYellow1;
	public GameObject MiddleRed1;
	public GameObject MiddleBlue1;
	public GameObject MiddleGreen1;
	public GameObject MiddleBlack1;
	public GameObject MiddleYellow1;
	public GameObject BottomRed1;
	public GameObject BottomBlue1;
	public GameObject BottomGreen1;
	public GameObject BottomBlack1;
	public GameObject BottomYellow1;
	
	public GameObject HoleRed;
	public GameObject HoleBlue;
	public GameObject HoleGreen;
	public GameObject HoleBlack;
	public GameObject HoleYellow;
	public GameObject ColliderBlock1;
	public GameObject ColliderBlock2;
	public GameObject ColliderBlock3;
	public GameObject ColliderBlock6;
	public GameObject ColliderBlock7;
	public GameObject ColliderBlock8;
	public GameObject InfoScreen;
	public GameObject Arrow;
	public GameObject StartButton;
	
	public GameObject TopDispPeg;
	public GameObject MidDispPeg;
	public GameObject BotDispPeg;
	public GameObject TopDispHole;
	public GameObject MidDispHole;
	public GameObject BotDispHole;
	
	public GameObject TopDispPeg1;
	public GameObject MidDispPeg1;
	public GameObject BotDispPeg1;
	public GameObject TopDispHole1;
	public GameObject MidDispHole1;
	public GameObject BotDispHole1;
	
	public GameObject TopHole;
	public GameObject MidHole;
	public GameObject BotHole;
	public GameObject TopHole1;
	public GameObject MidHole1;
	public GameObject BotHole1;
	
	public GameObject ScriptPegs;
	public GameObject ScriptHoles;
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
		GameObject.FindObjectOfType <Matcher>().XprtAnswers();
        
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
		
		Pegs.Add(TopRed1);
		Pegs.Add(TopBlue1);
		Pegs.Add(TopGreen1);
		Pegs.Add(TopBlack1);
		Pegs.Add(TopYellow1);
		Pegs.Add(MiddleRed1);
		Pegs.Add(MiddleBlue1);
		Pegs.Add(MiddleGreen1);
		Pegs.Add(MiddleBlack1);
		Pegs.Add(MiddleYellow1);
		Pegs.Add(BottomRed1);
		Pegs.Add(BottomBlue1);
		Pegs.Add(BottomGreen1);
		Pegs.Add(BottomBlack1);
		Pegs.Add(BottomYellow1);
		
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
		
		Instantiate (TopHole1,new Vector2(xRightEdge - 11.25f*xWidthAdj,yTopEdge - 1.2f), Quaternion.identity);
		Instantiate (MidHole1,new Vector2(xRightEdge - 9.15f*xWidthAdj,yTopEdge - 1.2f), Quaternion.identity);
		Instantiate (BotHole1,new Vector2(xRightEdge - 7.05f*xWidthAdj,yTopEdge - 1.2f), Quaternion.identity);
		Instantiate (TopHole,new Vector2(xRightEdge - 4.95f*xWidthAdj,yTopEdge - 1.2f), Quaternion.identity);
		Instantiate (MidHole,new Vector2(xRightEdge - 2.85f*xWidthAdj,yTopEdge - 1.2f), Quaternion.identity);
		Instantiate (BotHole,new Vector2(xRightEdge - 0.75f*xWidthAdj,yTopEdge - 1.2f), Quaternion.identity);
		
		Instantiate (Lightoff,new Vector2(xRightEdge - 11.25f*xWidthAdj,yTopEdge), Quaternion.identity);
		Instantiate (Lightoff,new Vector2(xRightEdge - 9.15f*xWidthAdj,yTopEdge), Quaternion.identity);
		Instantiate (Lightoff,new Vector2(xRightEdge - 7.05f*xWidthAdj,yTopEdge), Quaternion.identity);
		Instantiate (Lightoff,new Vector2(xRightEdge - 4.95f*xWidthAdj,yTopEdge), Quaternion.identity);
		Instantiate (Lightoff,new Vector2(xRightEdge - 2.85f*xWidthAdj,yTopEdge), Quaternion.identity);
		Instantiate (Lightoff,new Vector2(xRightEdge - 0.75f*xWidthAdj,yTopEdge), Quaternion.identity);
	
		Instantiate (Colors[Random.Range (0,5)],new Vector3(xRightEdge - 11.25f*xWidthAdj,yTopEdge - 1.2f,0.5f), Quaternion.identity);
		Instantiate (Colors[Random.Range (0,5)],new Vector3(xRightEdge - 9.15f*xWidthAdj,yTopEdge - 1.2f,0.5f), Quaternion.identity);
		Instantiate (Colors[Random.Range (0,5)],new Vector3(xRightEdge - 7.05f*xWidthAdj,yTopEdge - 1.2f,0.5f), Quaternion.identity);
		Instantiate (Colors[Random.Range (0,5)],new Vector3(xRightEdge - 4.95f*xWidthAdj,yTopEdge - 1.2f,0.5f), Quaternion.identity);
		Instantiate (Colors[Random.Range (0,5)],new Vector3(xRightEdge - 2.85f*xWidthAdj,yTopEdge - 1.2f,0.5f), Quaternion.identity);
		Instantiate (Colors[Random.Range (0,5)],new Vector3(xRightEdge - 0.75f*xWidthAdj,yTopEdge - 1.2f,0.5f), Quaternion.identity);

		Instantiate (ColliderBlock1,new Vector2(xRightEdge - (11.25f - 2.1f*Answers.IndexOf (1))*xWidthAdj,yTopEdge-0.2f), Quaternion.identity);
		Instantiate (ColliderBlock2,new Vector2(xRightEdge - (11.25f - 2.1f*Answers.IndexOf (2))*xWidthAdj,yTopEdge-0.2f), Quaternion.identity);
		Instantiate (ColliderBlock3,new Vector2(xRightEdge - (11.25f - 2.1f*Answers.IndexOf (3))*xWidthAdj,yTopEdge-0.2f), Quaternion.identity);
		Instantiate (ColliderBlock6,new Vector2(xRightEdge - (4.95f - 2.1f*Answers1.IndexOf (1))*xWidthAdj,yTopEdge-0.2f), Quaternion.identity);
		Instantiate (ColliderBlock7,new Vector2(xRightEdge - (4.95f - 2.1f*Answers1.IndexOf (2))*xWidthAdj,yTopEdge-0.2f), Quaternion.identity);
		Instantiate (ColliderBlock8,new Vector2(xRightEdge - (4.95f - 2.1f*Answers1.IndexOf (3))*xWidthAdj,yTopEdge-0.2f), Quaternion.identity);

		Instantiate (InfoScreen,new Vector3(xMid,yMid,-2f), Quaternion.identity);
		Instantiate (StartButton,new Vector3(xRightEdge - 8f*xWidthAdj,yTopEdge - 10f*yHeightAdj,-2.5f), Quaternion.identity);							
		Instantiate (CoverDisplay,new Vector3(xMid,yMid,-1.5f), Quaternion.identity);
		
		Instantiate (ScriptPegs,new Vector3(xRightEdge - 9f*xWidthAdj - 1.5f,yTopEdge - 1f*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (ScriptHoles,new Vector3(xRightEdge - 9f*xWidthAdj + 1.5f,yTopEdge - 1f*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (ScriptPegs,new Vector3(1.5f,yTopEdge - 1f*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (ScriptHoles,new Vector3(5.5f,yTopEdge - 1f*yHeightAdj,-2.5f), Quaternion.identity);

		Instantiate (Arrow,new Vector3(xRightEdge - 9f*xWidthAdj,yTopEdge - 2.6f*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (Arrow,new Vector3(xRightEdge - 9f*xWidthAdj,yTopEdge - 4.8f*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (Arrow,new Vector3(xRightEdge - 9f*xWidthAdj,yTopEdge - 7.0f*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (Arrow,new Vector3(xRightEdge - 3f*xWidthAdj,yTopEdge - 2.6f*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (Arrow,new Vector3(xRightEdge - 3f*xWidthAdj,yTopEdge - 4.8f*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (Arrow,new Vector3(xRightEdge - 3f*xWidthAdj,yTopEdge - 7.0f*yHeightAdj,-2.5f), Quaternion.identity);
		
		int aa1 = Random.Range (0,Switcher.Count);
		int aa = Switcher[aa1];
		Switcher.RemoveAt (aa1);
		int bb1 = Random.Range (0,Switcher.Count);
		int bb = Switcher[bb1];
		Switcher.RemoveAt (bb1);
		int cc1 = Random.Range (0,Switcher.Count);
		int cc = Switcher[cc1];
		
		int dd1 = Random.Range (0,Switcher1.Count);
		int dd = Switcher1[dd1];
		Switcher1.RemoveAt (dd1);
		int ee1 = Random.Range (0,Switcher1.Count);
		int ee = Switcher1[ee1];
		Switcher1.RemoveAt (ee1);
		int ff1 = Random.Range (0,Switcher1.Count);
		int ff = Switcher1[ff1];

		Instantiate (TopDispPeg,new Vector3(xRightEdge - 9f*xWidthAdj - 1.5f,yTopEdge - (12f - (5.0f+2.2f*aa))*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (MidDispPeg,new Vector3(xRightEdge - 9f*xWidthAdj - 1.5f,yTopEdge - (12f - (5.0f+2.2f*bb))*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (BotDispPeg,new Vector3(xRightEdge - 9f*xWidthAdj - 1.5f,yTopEdge - (12f - (5.0f+2.2f*cc))*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (TopDispPeg1,new Vector3(xRightEdge - 3f*xWidthAdj - 1.5f,yTopEdge - (12f - (5.0f+2.2f*dd))*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (MidDispPeg1,new Vector3(xRightEdge - 3f*xWidthAdj - 1.5f,yTopEdge - (12f - (5.0f+2.2f*ee))*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (BotDispPeg1,new Vector3(xRightEdge - 3f*xWidthAdj - 1.5f,yTopEdge - (12f - (5.0f+2.2f*ff))*yHeightAdj,-2.5f), Quaternion.identity);
		
		List<float> Pegspots = new List<float> {aa,bb,cc};
		List<float> Pegspots1 = new List<float> {dd,ee,ff};
		
		Instantiate (TopDispHole1,new Vector3(xRightEdge - 9f*xWidthAdj + 1.5f,yTopEdge - (12f - (5.0f+(2.2f*Pegspots[Answers[0]-1])))*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (MidDispHole1,new Vector3(xRightEdge - 9f*xWidthAdj + 1.5f,yTopEdge - (12f - (5.0f+(2.2f*Pegspots[Answers[1]-1])))*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (BotDispHole1,new Vector3(xRightEdge - 9f*xWidthAdj + 1.5f,yTopEdge - (12f - (5.0f+(2.2f*Pegspots[Answers[2]-1])))*yHeightAdj,-2.5f), Quaternion.identity);	
		Instantiate (TopDispHole,new Vector3(xRightEdge - 3f*xWidthAdj + 1.5f,yTopEdge - (12f - (5.0f+(2.2f*Pegspots1[Answers1[0]-1])))*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (MidDispHole,new Vector3(xRightEdge - 3f*xWidthAdj + 1.5f,yTopEdge - (12f - (5.0f+(2.2f*Pegspots1[Answers1[1]-1])))*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (BotDispHole,new Vector3(xRightEdge - 3f*xWidthAdj + 1.5f,yTopEdge - (12f - (5.0f+(2.2f*Pegspots1[Answers1[2]-1])))*yHeightAdj,-2.5f), Quaternion.identity);	

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
		int u1 = 15+Random.Range (0,5);
		int u2 = 15+Random.Range (0,5);
		int u3 = 15+Random.Range (0,5);
		int v1 = 20+Random.Range (0,5);
		int v2 = 20+Random.Range (0,5);
		int v3 = 20+Random.Range (0,5);
		int w1 = 25+Random.Range (0,5);
		int w2 = 25+Random.Range (0,5);
		int w3 = 25+Random.Range (0,5);
		
		Answers = new List<int> {PlayerPrefs.GetInt("Answers00"),PlayerPrefs.GetInt("Answers01"),PlayerPrefs.GetInt("Answers02")};
		Answers1 = new List<int> {PlayerPrefs.GetInt("Answers10"),PlayerPrefs.GetInt("Answers11"),PlayerPrefs.GetInt("Answers12")};
		List<int> Order = new List<int>{x1,x2,x3,y1,y2,y3,z1,z2,z3,u1,u2,u3,v1,v2,v3,w1,w2,w3};
        
        float yTopEdge = 12f*safeMaxY/pixelsy - 6f;
        float yHeightAdj = safeHeight/pixelsy;
        float xRightEdge = 12f*ratio*safeMaxX/pixelsx - 6f*ratio;
        float xWidthAdj = ratio*safeWidth/pixelsx;
		
		int a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 10.5f*xWidthAdj,yTopEdge - 9.4f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 8.7f*xWidthAdj,yTopEdge - 9.4f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 6.9f*xWidthAdj,yTopEdge - 9.4f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 5.1f*xWidthAdj,yTopEdge - 9.4f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 3.3f*xWidthAdj,yTopEdge - 9.4f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 1.5f*xWidthAdj,yTopEdge - 9.4f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 10.5f*xWidthAdj,yTopEdge - 6.8f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 8.7f*xWidthAdj,yTopEdge - 6.8f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 6.9f*xWidthAdj,yTopEdge - 6.8f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 5.1f*xWidthAdj,yTopEdge - 6.8f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 3.3f*xWidthAdj,yTopEdge - 6.8f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 1.5f*xWidthAdj,yTopEdge - 6.8f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 10.5f*xWidthAdj,yTopEdge - 4.2f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 8.7f*xWidthAdj,yTopEdge - 4.2f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 6.9f*xWidthAdj,yTopEdge - 4.2f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 5.1f*xWidthAdj,yTopEdge - 4.2f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 3.3f*xWidthAdj,yTopEdge - 4.2f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 1.5f*xWidthAdj,yTopEdge - 4.2f*yHeightAdj), Quaternion.identity);
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
				levelmanager.LoadLevel("Lose Xprt");
			}
			scorer = GameObject.FindObjectOfType <ScoreCard>();
			scorer.ScoreKeeper();
		}
		if (strikecount <= 0) {
			levelmanager = GameObject.FindObjectOfType <LevelManager>();
			levelmanager.LoadLevel("Lose Xprt");
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
				if (strikecount == 3f) {
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