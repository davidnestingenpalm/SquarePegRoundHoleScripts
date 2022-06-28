using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Strikes : MonoBehaviour {

	public GameObject S1;
	public GameObject S2;
	public GameObject S3;
    
    float pixelsx, pixelsy, ratio, sizeX, sizeY;
    float yTopEdge, yHeightAdj, xRightEdge, xWidthAdj, yMid, xMid;
    //safearea screen stuff
    private float safeMinX, safeMaxX, safeMinY, safeMaxY, safeMidX, safeMidY, safeHeight, safeWidth, safeUIMinX, safeUIMaxX, 
        safeUIMinY, safeUIMaxY, safeUIMidX, safeUIMidY, safeUIHeight, safeUIWidth;

	void Start () {
        SceneSizer();
//		float anchor = -((1f*ratio-1.333f)+ratio*4.875f);
		float anchor = xRightEdge - 12f*xWidthAdj + 1.5f;
		Instantiate (S1,new Vector2(anchor+1.9f,yTopEdge - 12f*yHeightAdj + 0.45f), Quaternion.identity);
		Instantiate (S2,new Vector2(anchor+2.75f,yTopEdge - 12f*yHeightAdj + 0.45f), Quaternion.identity);	
		string name = SceneManager.GetActiveScene().name;		
		if (name.Contains ("Hard") || name.Contains ("Xprt") || name.Contains ("Insane")) {
			Instantiate (S3,new Vector2(anchor+3.6f,yTopEdge - 12f*yHeightAdj + 0.45f), Quaternion.identity);
		}
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
    }

}