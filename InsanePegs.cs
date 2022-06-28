using UnityEngine;
using System.Collections.Generic;

public class InsanePegs : MonoBehaviour {

	private List<int> Answers2;	

	public GameObject OneRed;
	public GameObject OneBlue;
	public GameObject OneGreen;
	public GameObject OneBlack;
	public GameObject OneYellow;
	public GameObject TwoRed;
	public GameObject TwoBlue;
	public GameObject TwoGreen;
	public GameObject TwoBlack;
	public GameObject TwoYellow;
	public GameObject ThreeRed;
	public GameObject ThreeBlue;
	public GameObject ThreeGreen;
	public GameObject ThreeBlack;
	public GameObject ThreeYellow;
	public GameObject FourRed;
	public GameObject FourBlue;
	public GameObject FourGreen;
	public GameObject FourBlack;
	public GameObject FourYellow;
	public GameObject FiveRed;
	public GameObject FiveBlue;
	public GameObject FiveGreen;
	public GameObject FiveBlack;
	public GameObject FiveYellow;
	
	public GameObject ARed;
	public GameObject ABlue;
	public GameObject AGreen;
	public GameObject ABlack;
	public GameObject AYellow;
	public GameObject BRed;
	public GameObject BBlue;
	public GameObject BGreen;
	public GameObject BBlack;
	public GameObject BYellow;
	public GameObject CRed;
	public GameObject CBlue;
	public GameObject CGreen;
	public GameObject CBlack;
	public GameObject CYellow;
	public GameObject DRed;
	public GameObject DBlue;
	public GameObject DGreen;
	public GameObject DBlack;
	public GameObject DYellow;
	public GameObject ERed;
	public GameObject EBlue;
	public GameObject EGreen;
	public GameObject EBlack;
	public GameObject EYellow;
	
	public GameObject SquareRed;
	public GameObject SquareBlue;
	public GameObject SquareGreen;
	public GameObject SquareBlack;
	public GameObject SquareYellow;
	public GameObject CircleRed;
	public GameObject CircleBlue;
	public GameObject CircleGreen;
	public GameObject CircleBlack;
	public GameObject CircleYellow;
	public GameObject TriangleRed;
	public GameObject TriangleBlue;
	public GameObject TriangleGreen;
	public GameObject TriangleBlack;
	public GameObject TriangleYellow;
	public GameObject StarRed;
	public GameObject StarBlue;
	public GameObject StarGreen;
	public GameObject StarBlack;
	public GameObject StarYellow;
	public GameObject PlusRed;
	public GameObject PlusBlue;
	public GameObject PlusGreen;
	public GameObject PlusBlack;
	public GameObject PlusYellow;
	
	public GameObject CheckerRed;
	public GameObject CheckerBlue;
	public GameObject CheckerGreen;
	public GameObject CheckerBlack;
	public GameObject CheckerYellow;
	public GameObject StripeRed;
	public GameObject StripeBlue;
	public GameObject StripeGreen;
	public GameObject StripeBlack;
	public GameObject StripeYellow;
	public GameObject PolkadotRed;
	public GameObject PolkadotBlue;
	public GameObject PolkadotGreen;
	public GameObject PolkadotBlack;
	public GameObject PolkadotYellow;
	public GameObject DiagonalRed;
	public GameObject DiagonalBlue;
	public GameObject DiagonalGreen;
	public GameObject DiagonalBlack;
	public GameObject DiagonalYellow;
	public GameObject TargetRed;
	public GameObject TargetBlue;
	public GameObject TargetGreen;
	public GameObject TargetBlack;
	public GameObject TargetYellow;

	private List<GameObject> Pegs = new List<GameObject> ();    

    float pixelsx, pixelsy, ratio, sizeX, sizeY;
    float yTopEdge, yHeightAdj, xRightEdge, xWidthAdj;
    //safearea screen stuff
    private float safeMinX, safeMaxX, safeMinY, safeMaxY, safeMidX, safeMidY, safeHeight, safeWidth, safeUIMinX, safeUIMaxX, 
        safeUIMinY, safeUIMaxY, safeUIMidX, safeUIMidY, safeUIHeight, safeUIWidth;

	void Start () {
		Pegs.Add(OneRed);
		Pegs.Add(OneBlue);
		Pegs.Add(OneGreen);
		Pegs.Add(OneBlack);
		Pegs.Add(OneYellow);
		Pegs.Add(TwoRed);
		Pegs.Add(TwoBlue);
		Pegs.Add(TwoGreen);
		Pegs.Add(TwoBlack);
		Pegs.Add(TwoYellow);
		Pegs.Add(ThreeRed);
		Pegs.Add(ThreeBlue);
		Pegs.Add(ThreeGreen);
		Pegs.Add(ThreeBlack);
		Pegs.Add(ThreeYellow);
		Pegs.Add(FourRed);
		Pegs.Add(FourBlue);
		Pegs.Add(FourGreen);
		Pegs.Add(FourBlack);
		Pegs.Add(FourYellow);
		Pegs.Add(FiveRed);
		Pegs.Add(FiveBlue);
		Pegs.Add(FiveGreen);
		Pegs.Add(FiveBlack);
		Pegs.Add(FiveYellow);
		
		Pegs.Add(ARed);
		Pegs.Add(ABlue);
		Pegs.Add(AGreen);
		Pegs.Add(ABlack);
		Pegs.Add(AYellow);
		Pegs.Add(BRed);
		Pegs.Add(BBlue);
		Pegs.Add(BGreen);
		Pegs.Add(BBlack);
		Pegs.Add(BYellow);
		Pegs.Add(CRed);
		Pegs.Add(CBlue);
		Pegs.Add(CGreen);
		Pegs.Add(CBlack);
		Pegs.Add(CYellow);
		Pegs.Add(DRed);
		Pegs.Add(DBlue);
		Pegs.Add(DGreen);
		Pegs.Add(DBlack);
		Pegs.Add(DYellow);
		Pegs.Add(ERed);
		Pegs.Add(EBlue);
		Pegs.Add(EGreen);
		Pegs.Add(EBlack);
		Pegs.Add(EYellow);
		
		Pegs.Add(SquareRed);
		Pegs.Add(SquareBlue);
		Pegs.Add(SquareGreen);
		Pegs.Add(SquareBlack);
		Pegs.Add(SquareYellow);
		Pegs.Add(CircleRed);
		Pegs.Add(CircleBlue);
		Pegs.Add(CircleGreen);
		Pegs.Add(CircleBlack);
		Pegs.Add(CircleYellow);
		Pegs.Add(TriangleRed);
		Pegs.Add(TriangleBlue);
		Pegs.Add(TriangleGreen);
		Pegs.Add(TriangleBlack);
		Pegs.Add(TriangleYellow);
		Pegs.Add(StarRed);
		Pegs.Add(StarBlue);
		Pegs.Add(StarGreen);
		Pegs.Add(StarBlack);
		Pegs.Add(StarYellow);
		Pegs.Add(PlusRed);
		Pegs.Add(PlusBlue);
		Pegs.Add(PlusGreen);
		Pegs.Add(PlusBlack);
		Pegs.Add(PlusYellow);
		
		Pegs.Add(CheckerRed);
		Pegs.Add(CheckerBlue);
		Pegs.Add(CheckerGreen);
		Pegs.Add(CheckerBlack);
		Pegs.Add(CheckerYellow);
		Pegs.Add(StripeRed);
		Pegs.Add(StripeBlue);
		Pegs.Add(StripeGreen);
		Pegs.Add(StripeBlack);
		Pegs.Add(StripeYellow);
		Pegs.Add(PolkadotRed);
		Pegs.Add(PolkadotBlue);
		Pegs.Add(PolkadotGreen);
		Pegs.Add(PolkadotBlack);
		Pegs.Add(PolkadotYellow);
		Pegs.Add(DiagonalRed);
		Pegs.Add(DiagonalBlue);
		Pegs.Add(DiagonalGreen);
		Pegs.Add(DiagonalBlack);
		Pegs.Add(DiagonalYellow);
		Pegs.Add(TargetRed);
		Pegs.Add(TargetBlue);
		Pegs.Add(TargetGreen);
		Pegs.Add(TargetBlack);
		Pegs.Add(TargetYellow);

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
		
		PegPlacement ();		
	}
		
	void PegPlacement () {
		Answers2 = new List<int> {PlayerPrefs.GetInt("Answers20"),PlayerPrefs.GetInt("Answers21"),PlayerPrefs.GetInt("Answers22")};
		
		int xa1 = (25*(Answers2[0]-1))+Random.Range (0,5);
		int xa2 = (25*(Answers2[0]-1))+Random.Range (0,5);
		int ya1 = (25*(Answers2[0]-1))+5+Random.Range (0,5);
		int ya2 = (25*(Answers2[0]-1))+5+Random.Range (0,5);
		int za1 = (25*(Answers2[0]-1))+10+Random.Range (0,5);
		int za2 = (25*(Answers2[0]-1))+10+Random.Range (0,5);
		int wa1 = (25*(Answers2[0]-1))+15+Random.Range (0,5);
		int wa2 = (25*(Answers2[0]-1))+15+Random.Range (0,5);
		int va1 = (25*(Answers2[0]-1))+20+Random.Range (0,5);
		int va2 = (25*(Answers2[0]-1))+20+Random.Range (0,5);
		
		int xb1 = (25*(Answers2[1]-1))+Random.Range (0,5);
		int xb2 = (25*(Answers2[1]-1))+Random.Range (0,5);
		int yb1 = (25*(Answers2[1]-1))+5+Random.Range (0,5);
		int yb2 = (25*(Answers2[1]-1))+5+Random.Range (0,5);
		int zb1 = (25*(Answers2[1]-1))+10+Random.Range (0,5);
		int zb2 = (25*(Answers2[1]-1))+10+Random.Range (0,5);
		int wb1 = (25*(Answers2[1]-1))+15+Random.Range (0,5);
		int wb2 = (25*(Answers2[1]-1))+15+Random.Range (0,5);
		int vb1 = (25*(Answers2[1]-1))+20+Random.Range (0,5);
		int vb2 = (25*(Answers2[1]-1))+20+Random.Range (0,5);
		
		List<int> Order = new List<int>{xa1,xa2,xb1,xb2,ya1,ya2,yb1,yb2,za1,za2,zb1,zb2,wa1,wa2,wb1,wb2,va1,va2,vb1,vb2};
        
        float yTopEdge = 12f*safeMaxY/pixelsy - 6f;
        float yHeightAdj = safeHeight/pixelsy;
        float xRightEdge = 12f*ratio*safeMaxX/pixelsx - 6f*ratio;
        float xWidthAdj = ratio*safeWidth/pixelsx;
		
		int a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 10.5f*xWidthAdj,yTopEdge - 9f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 8.625f*xWidthAdj,yTopEdge - 9f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 6.75f*xWidthAdj,yTopEdge - 9f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 4.875f*xWidthAdj,yTopEdge - 9f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 3f*xWidthAdj,yTopEdge - 9f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 10.5f*xWidthAdj,yTopEdge - 6.75f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 8.625f*xWidthAdj,yTopEdge - 6.75f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 6.75f*xWidthAdj,yTopEdge - 6.75f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 4.875f*xWidthAdj,yTopEdge - 6.75f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 3f*xWidthAdj,yTopEdge - 6.75f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 10.5f*xWidthAdj,yTopEdge - 4.5f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 8.625f*xWidthAdj,yTopEdge - 4.5f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 6.75f*xWidthAdj,yTopEdge - 4.5f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 4.875f*xWidthAdj,yTopEdge - 4.5f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 3f*xWidthAdj,yTopEdge - 4.5f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 10.5f*xWidthAdj,yTopEdge - 2.25f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 8.625f*xWidthAdj,yTopEdge - 2.25f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 6.75f*xWidthAdj,yTopEdge - 2.25f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 4.875f*xWidthAdj,yTopEdge - 2.25f*yHeightAdj), Quaternion.identity);
		Order.RemoveAt (a);
		
		a = Random.Range (0,Order.Count);
		Instantiate (Pegs[Order[a]],new Vector2(xRightEdge - 3f*xWidthAdj,yTopEdge - 2.25f*yHeightAdj), Quaternion.identity);
	}
}