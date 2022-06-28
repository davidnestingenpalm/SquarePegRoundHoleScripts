using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pegs : MonoBehaviour {

	private static float zpos;
	private float TouchPosInBlocksX;
	private float TouchPosInBlocksY;
	private float MousePosInBlocksX;
	private float MousePosInBlocksY;
	private Vector3 PegPos;
    
    float pixelsx, pixelsy, ratio, sizeX, sizeY;
    float yTopEdge, yHeightAdj, xRightEdge, xWidthAdj, yMid, xMid;
    //safearea screen stuff
    private float safeMinX, safeMaxX, safeMinY, safeMaxY, safeMidX, safeMidY, safeHeight, safeWidth, safeUIMinX, safeUIMaxX, 
        safeUIMinY, safeUIMaxY, safeUIMidX, safeUIMidY, safeUIHeight, safeUIWidth;

	void Start () {
		zpos = -0.00001f;
        SceneSizer();
	}

    void SceneSizer() {
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
	}

	void OnMouseDrag() {
		if (!SceneManager.GetActiveScene().name.Contains("Tutorial")) {
		    PegPos = new Vector3 (this.transform.position.x,this.transform.position.y,zpos);
		    MousePosInBlocksX = (Input.mousePosition.x/Screen.width)*12*ratio - 6f*ratio;
		    MousePosInBlocksY = (Input.mousePosition.y/Screen.height)*12f - 6f;			
		    PegPos.x = Mathf.Clamp(MousePosInBlocksX,xRightEdge - 11.625f*xWidthAdj,xRightEdge - 0.375f*xWidthAdj);
		    PegPos.y = Mathf.Clamp(MousePosInBlocksY,yTopEdge - 11.5f*yHeightAdj,yTopEdge - 0.5f*yHeightAdj);		
		    this.transform.position = PegPos;
        }
	}
	
	void OnMouseDown() {
		zpos=zpos-0.00001f;
	}
}