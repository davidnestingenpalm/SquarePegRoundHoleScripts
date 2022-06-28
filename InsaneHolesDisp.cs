using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class InsaneHolesDisp : MonoBehaviour {

//	private Matcher match;
	private int indexkey1;
	private List<int> Switcher = new List<int> {0,1,2,3,4};
	private List<int> Answers,Answers1,Answers2;

	public GameObject OneHole;
	public GameObject TwoHole;
	public GameObject ThreeHole;
	public GameObject FourHole;
	public GameObject FiveHole;
	public GameObject AHole;
	public GameObject BHole;
	public GameObject CHole;
	public GameObject DHole;
	public GameObject EHole;
	public GameObject SquareHole;
	public GameObject CircleHole;
	public GameObject TriangleHole;
	public GameObject StarHole;
	public GameObject PlusHole;
	public GameObject CheckerHole;
	public GameObject StripeHole;
	public GameObject PolkadotHole;
	public GameObject DiagonalHole;
	public GameObject TargetHole;
	
	public GameObject OneDispHole;
	public GameObject TwoDispHole;
	public GameObject ThreeDispHole;
	public GameObject FourDispHole;
	public GameObject FiveDispHole;
	public GameObject ADispHole;
	public GameObject BDispHole;
	public GameObject CDispHole;
	public GameObject DDispHole;
	public GameObject EDispHole;
	public GameObject SquareDispHole;
	public GameObject CircleDispHole;
	public GameObject TriangleDispHole;
	public GameObject StarDispHole;
	public GameObject PlusDispHole;
	public GameObject CheckerDispHole;
	public GameObject StripeDispHole;
	public GameObject PolkadotDispHole;
	public GameObject DiagonalDispHole;
	public GameObject TargetDispHole;
	
	public GameObject OneDispPeg;
	public GameObject TwoDispPeg;
	public GameObject ThreeDispPeg;
	public GameObject FourDispPeg;
	public GameObject FiveDispPeg;
	public GameObject ADispPeg;
	public GameObject BDispPeg;
	public GameObject CDispPeg;
	public GameObject DDispPeg;
	public GameObject EDispPeg;
	public GameObject SquareDispPeg;
	public GameObject CircleDispPeg;
	public GameObject TriangleDispPeg;
	public GameObject StarDispPeg;
	public GameObject PlusDispPeg;
	public GameObject CheckerDispPeg;
	public GameObject StripeDispPeg;
	public GameObject PolkadotDispPeg;
	public GameObject DiagonalDispPeg;
	public GameObject TargetDispPeg;
		
	public GameObject HoleRed;
	public GameObject HoleBlue;
	public GameObject HoleGreen;
	public GameObject HoleBlack;
	public GameObject HoleYellow;
	public GameObject ColliderBlock11;
	public GameObject ColliderBlock12;
	public GameObject ColliderBlock13;
	public GameObject ColliderBlock14;
	public GameObject ColliderBlock15;
	public GameObject InfoScreen;
	public GameObject Arrow;
	public GameObject StartButton;
	public GameObject ScriptPegs;
	public GameObject ScriptHoles;
	public GameObject Lightoff;
	public GameObject ScoreScreen;
	public GameObject CoverDisplay;	
	private List<GameObject> Dispholes = new List<GameObject> ();
	private List<GameObject> Disppegs = new List<GameObject> ();
	private List<GameObject> Holes = new List<GameObject> ();
	private List<GameObject> Colors = new List<GameObject> ();
        
    float pixelsx, pixelsy, ratio, sizeX, sizeY;
    float yTopEdge, yHeightAdj, xRightEdge, xWidthAdj, yMid, xMid;
    //safearea screen stuff
    private float safeMinX, safeMaxX, safeMinY, safeMaxY, safeMidX, safeMidY, safeHeight, safeWidth, safeUIMinX, safeUIMaxX, 
        safeUIMinY, safeUIMaxY, safeUIMidX, safeUIMidY, safeUIHeight, safeUIWidth;

	void Start () {

		Holes.Add (OneHole);
		Holes.Add (TwoHole);
		Holes.Add (ThreeHole);
		Holes.Add (FourHole);
		Holes.Add (FiveHole);
		Holes.Add (AHole);
		Holes.Add (BHole);
		Holes.Add (CHole);
		Holes.Add (DHole);
		Holes.Add (EHole);
		Holes.Add (SquareHole);
		Holes.Add (CircleHole);
		Holes.Add (TriangleHole);
		Holes.Add (StarHole);
		Holes.Add (PlusHole);
		Holes.Add (CheckerHole);
		Holes.Add (StripeHole);
		Holes.Add (PolkadotHole);
		Holes.Add (DiagonalHole);
		Holes.Add (TargetHole);
		
		Dispholes.Add (OneDispHole);
		Dispholes.Add (TwoDispHole);
		Dispholes.Add (ThreeDispHole);
		Dispholes.Add (FourDispHole);
		Dispholes.Add (FiveDispHole);
		Dispholes.Add (ADispHole);
		Dispholes.Add (BDispHole);
		Dispholes.Add (CDispHole);
		Dispholes.Add (DDispHole);
		Dispholes.Add (EDispHole);
		Dispholes.Add (SquareDispHole);
		Dispholes.Add (CircleDispHole);
		Dispholes.Add (TriangleDispHole);
		Dispholes.Add (StarDispHole);
		Dispholes.Add (PlusDispHole);
		Dispholes.Add (CheckerDispHole);
		Dispholes.Add (StripeDispHole);
		Dispholes.Add (PolkadotDispHole);
		Dispholes.Add (DiagonalDispHole);
		Dispholes.Add (TargetDispHole);
		
		Disppegs.Add (OneDispPeg);
		Disppegs.Add (TwoDispPeg);
		Disppegs.Add (ThreeDispPeg);
		Disppegs.Add (FourDispPeg);
		Disppegs.Add (FiveDispPeg);
		Disppegs.Add (ADispPeg);
		Disppegs.Add (BDispPeg);
		Disppegs.Add (CDispPeg);
		Disppegs.Add (DDispPeg);
		Disppegs.Add (EDispPeg);
		Disppegs.Add (SquareDispPeg);
		Disppegs.Add (CircleDispPeg);
		Disppegs.Add (TriangleDispPeg);
		Disppegs.Add (StarDispPeg);
		Disppegs.Add (PlusDispPeg);
		Disppegs.Add (CheckerDispPeg);
		Disppegs.Add (StripeDispPeg);
		Disppegs.Add (PolkadotDispPeg);
		Disppegs.Add (DiagonalDispPeg);
		Disppegs.Add (TargetDispPeg);
		
		Colors.Add(HoleRed);
		Colors.Add(HoleBlue);
		Colors.Add(HoleGreen);
		Colors.Add(HoleBlack);
		Colors.Add(HoleYellow);

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
        
		indexkey1 = PlayerPrefs.GetInt("indexkey1");
		Answers = new List<int> {PlayerPrefs.GetInt("Answers00"),PlayerPrefs.GetInt("Answers01"),PlayerPrefs.GetInt("Answers02"),PlayerPrefs.GetInt("Answers03"),PlayerPrefs.GetInt("Answers04")};
		Answers1 = new List<int> {PlayerPrefs.GetInt("Answers10"),PlayerPrefs.GetInt("Answers11"),PlayerPrefs.GetInt("Answers12"),PlayerPrefs.GetInt("Answers13"),PlayerPrefs.GetInt("Answers14")};
		Answers2 = new List<int> {PlayerPrefs.GetInt("Answers20"),PlayerPrefs.GetInt("Answers21"),PlayerPrefs.GetInt("Answers22")};

		Instantiate (Holes[5*(Answers2[2]-1)],new Vector2(xRightEdge - 1.2f,yTopEdge - 1.2f*yHeightAdj), Quaternion.identity);
		Instantiate (Holes[1+5*(Answers2[2]-1)],new Vector2(xRightEdge - 1.2f,yTopEdge - 3.6f*yHeightAdj), Quaternion.identity);
		Instantiate (Holes[2+5*(Answers2[2]-1)],new Vector2(xRightEdge - 1.2f,yTopEdge - 6f*yHeightAdj), Quaternion.identity);
		Instantiate (Holes[3+5*(Answers2[2]-1)],new Vector2(xRightEdge - 1.2f,yTopEdge - 8.4f*yHeightAdj), Quaternion.identity);
		Instantiate (Holes[4+5*(Answers2[2]-1)],new Vector2(xRightEdge - 1.2f,yTopEdge - 10.8f*yHeightAdj), Quaternion.identity);
		
		Instantiate (Lightoff,new Vector2(xRightEdge,yTopEdge - 10.8f*yHeightAdj), Quaternion.identity);
		Instantiate (Lightoff,new Vector2(xRightEdge,yTopEdge - 8.4f*yHeightAdj), Quaternion.identity);
		Instantiate (Lightoff,new Vector2(xRightEdge,yTopEdge - 6f*yHeightAdj), Quaternion.identity);
		Instantiate (Lightoff,new Vector2(xRightEdge,yTopEdge - 3.6f*yHeightAdj), Quaternion.identity);
		Instantiate (Lightoff,new Vector2(xRightEdge,yTopEdge - 1.2f*yHeightAdj), Quaternion.identity);
		
		Instantiate (Colors[Random.Range (0,5)],new Vector3(xRightEdge - 1.2f,yTopEdge - 1.2f*yHeightAdj,0.5f), Quaternion.identity);
		Instantiate (Colors[Random.Range (0,5)],new Vector3(xRightEdge - 1.2f,yTopEdge - 3.6f*yHeightAdj,0.5f), Quaternion.identity);
		Instantiate (Colors[Random.Range (0,5)],new Vector3(xRightEdge - 1.2f,yTopEdge - 6f*yHeightAdj,0.5f), Quaternion.identity);
		Instantiate (Colors[Random.Range (0,5)],new Vector3(xRightEdge - 1.2f,yTopEdge - 8.4f*yHeightAdj,0.5f), Quaternion.identity);
		Instantiate (Colors[Random.Range (0,5)],new Vector3(xRightEdge - 1.2f,yTopEdge - 10.8f*yHeightAdj,0.5f), Quaternion.identity);
		
		Instantiate (ColliderBlock11,new Vector2(xRightEdge-0.2f,yTopEdge - (12f - (10.8f-(2.4f*Answers.IndexOf (1))))*yHeightAdj), Quaternion.identity);
		Instantiate (ColliderBlock12,new Vector2(xRightEdge-0.2f,yTopEdge - (12f - (10.8f-(2.4f*Answers.IndexOf (2))))*yHeightAdj), Quaternion.identity);
		Instantiate (ColliderBlock13,new Vector2(xRightEdge-0.2f,yTopEdge - (12f - (10.8f-(2.4f*Answers.IndexOf (3))))*yHeightAdj), Quaternion.identity);
		Instantiate (ColliderBlock14,new Vector2(xRightEdge-0.2f,yTopEdge - (12f - (10.8f-(2.4f*Answers.IndexOf (4))))*yHeightAdj), Quaternion.identity);
		Instantiate (ColliderBlock15,new Vector2(xRightEdge-0.2f,yTopEdge - (12f - (10.8f-(2.4f*Answers.IndexOf (5))))*yHeightAdj), Quaternion.identity);
		
		Instantiate (InfoScreen,new Vector3(xMid,yMid,-2f), Quaternion.identity);
		Instantiate (StartButton,new Vector3(xRightEdge - 3f*xWidthAdj,yMid,-2.5f), Quaternion.identity);
		Instantiate (CoverDisplay,new Vector3(xMid,yMid,-1.5f), Quaternion.identity);
		Instantiate (ScriptPegs,new Vector3(xRightEdge - 9f*xWidthAdj - 1.675f,yTopEdge - 0.8f*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (ScriptHoles,new Vector3(xRightEdge - 9f*xWidthAdj + 2.25f,yTopEdge - 0.8f*yHeightAdj,-2.5f), Quaternion.identity);
		
		Instantiate (Arrow,new Vector3(xRightEdge - 9f*xWidthAdj + 0.75f,yTopEdge - 2.4f*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (Arrow,new Vector3(xRightEdge - 9f*xWidthAdj + 0.75f,yTopEdge - 4.5f*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (Arrow,new Vector3(xRightEdge - 9f*xWidthAdj + 0.75f,yTopEdge - 6.6f*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (Arrow,new Vector3(xRightEdge - 9f*xWidthAdj + 0.75f,yTopEdge - 8.7f*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (Arrow,new Vector3(xRightEdge - 9f*xWidthAdj + 0.75f,yTopEdge - 10.8f*yHeightAdj,-2.5f), Quaternion.identity);
		
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
		Switcher.RemoveAt (dd1);
		int ee1 = Random.Range (0,Switcher.Count);
		int ee = Switcher[ee1];
		
		Instantiate (Disppegs[5*(Answers2[0]-1)],new Vector3(xRightEdge - 9f*xWidthAdj - 0.75f,yTopEdge - (12f - (1.2f+2.1f*aa))*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (Disppegs[1+5*(Answers2[0]-1)],new Vector3(xRightEdge - 9f*xWidthAdj - 0.75f,yTopEdge - (12f - (1.2f+2.1f*bb))*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (Disppegs[2+5*(Answers2[0]-1)],new Vector3(xRightEdge - 9f*xWidthAdj - 0.75f,yTopEdge - (12f - (1.2f+2.1f*cc))*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (Disppegs[3+5*(Answers2[0]-1)],new Vector3(xRightEdge - 9f*xWidthAdj - 0.75f,yTopEdge - (12f - (1.2f+2.1f*dd))*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (Disppegs[4+5*(Answers2[0]-1)],new Vector3(xRightEdge - 9f*xWidthAdj - 0.75f,yTopEdge - (12f - (1.2f+2.1f*ee))*yHeightAdj,-2.5f), Quaternion.identity);
		
		Instantiate (Disppegs[(Answers1[0]-1)+5*indexkey1],new Vector3(xRightEdge - 9f*xWidthAdj - 2.5f,yTopEdge - (12f - (1.2f+2.1f*aa))*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (Disppegs[(Answers1[1]-1)+5*indexkey1],new Vector3(xRightEdge - 9f*xWidthAdj - 2.5f,yTopEdge - (12f - (1.2f+2.1f*bb))*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (Disppegs[(Answers1[2]-1)+5*indexkey1],new Vector3(xRightEdge - 9f*xWidthAdj - 2.5f,yTopEdge - (12f - (1.2f+2.1f*cc))*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (Disppegs[(Answers1[3]-1)+5*indexkey1],new Vector3(xRightEdge - 9f*xWidthAdj - 2.5f,yTopEdge - (12f - (1.2f+2.1f*dd))*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (Disppegs[(Answers1[4]-1)+5*indexkey1],new Vector3(xRightEdge - 9f*xWidthAdj - 2.5f,yTopEdge - (12f - (1.2f+2.1f*ee))*yHeightAdj,-2.5f), Quaternion.identity);
		
		List<float> Pegspots = new List<float> {aa,bb,cc,dd,ee};
		Instantiate (Dispholes[5*(Answers2[2]-1)],new Vector3(xRightEdge - 9f*xWidthAdj + 2.25f,yTopEdge - (12f - (1.2f+(2.1f*Pegspots[Answers[0]-1])))*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (Dispholes[1+5*(Answers2[2]-1)],new Vector3(xRightEdge - 9f*xWidthAdj + 2.25f,yTopEdge - (12f - (1.2f+(2.1f*Pegspots[Answers[1]-1])))*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (Dispholes[2+5*(Answers2[2]-1)],new Vector3(xRightEdge - 9f*xWidthAdj + 2.25f,yTopEdge - (12f - (1.2f+(2.1f*Pegspots[Answers[2]-1])))*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (Dispholes[3+5*(Answers2[2]-1)],new Vector3(xRightEdge - 9f*xWidthAdj + 2.25f,yTopEdge - (12f - (1.2f+(2.1f*Pegspots[Answers[3]-1])))*yHeightAdj,-2.5f), Quaternion.identity);
		Instantiate (Dispholes[4+5*(Answers2[2]-1)],new Vector3(xRightEdge - 9f*xWidthAdj + 2.25f,yTopEdge - (12f - (1.2f+(2.1f*Pegspots[Answers[4]-1])))*yHeightAdj,-2.5f), Quaternion.identity);

	}
}