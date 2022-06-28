﻿using UnityEngine;
using System.Collections;

public class GameTypeScript : MonoBehaviour {

	private Vector2 Regpos;
	private Vector2 Endpos;
	private Vector2 Bckpos;
	private Vector2 Tpos;
	private Vector2 SubTpos;

    public GameObject Title, Subtitle, Back, Regular, Endurance;
    public GameObject Star, holeTriBackgroundPeg, plusBackgroundPeg, holeRedBackgroundPeg, letBBackgroundPeg, holeGreenBackgroundPeg,
        hole4BackgroundPeg, circleBackgroundPeg;
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
	}

    void SceneSizer() {
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
        float ratioAdj = -0.3f;
        float widthAdj = 0.5f;
        float heightAdj = 0.075f;
		Title.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*0.975f,safeUIHeight*0.125f);
        Subtitle.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*0.975f,safeUIHeight*0.06f);
        Regular.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*widthAdj,safeUIHeight*heightAdj*(ratio-ratioAdj));
        Endurance.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*widthAdj,safeUIHeight*heightAdj*(ratio-ratioAdj));
		Back.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*0.2f,safeUIHeight*0.1f);

        backgroundImage.GetComponent<Transform>().localScale = new Vector2(ratio*safeWidth/pixelsx, safeHeight/pixelsy);

        backgroundBlockTop.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeX*1.5f,sizeY*0.25f);
        backgroundBlockRight.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeX*0.25f,sizeY*1.5f);
        backgroundBlockLeft.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeX*0.25f,sizeY*1.5f);
        backgroundBlockBottom.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeX*1.5f,sizeY*0.25f);
	}
    
    void SceneLayout() {
        Tpos.x = safeMidX;
		Tpos.y = safeMinY + safeHeight*0.9f;
		Title.transform.position = Tpos;
		
		SubTpos.x = safeMidX;
		SubTpos.y = safeMinY + safeHeight*0.8f;
		Subtitle.transform.position = SubTpos;
			
		Regpos.x = safeMidX;
		Regpos.y = safeMinY + safeHeight*0.59f;
		Regular.transform.position = Regpos;
		
		Endpos.x = safeMidX;
		Endpos.y = safeMinY + safeHeight*0.32f;
		Endurance.transform.position = Endpos;
		
		Bckpos.x = safeMidX;
		Bckpos.y = safeMinY + safeHeight*0.075f;
		Back.transform.position = Bckpos;
        
        // background image, pegs, and colider, 
        Star.transform.position = new Vector3(12f*ratio*safeMidX/pixelsx - 2.5f*ratio,12f*safeMidY/pixelsy - 0.5f*safeHeight/pixelsy,-1f);
        holeTriBackgroundPeg.transform.position = new Vector3(12f*ratio*safeMidX/pixelsx - 3.5f*ratio,12f*safeMidY/pixelsy - 11.5f*safeHeight/pixelsy,0.5f);
        plusBackgroundPeg.transform.position = new Vector3(12f*ratio*safeMidX/pixelsx - 7.5f*ratio,12f*safeMidY/pixelsy - 0.75f*safeHeight/pixelsy,0.5f);
        holeRedBackgroundPeg.transform.position = new Vector3(12f*ratio*safeMidX/pixelsx - 9.5f*ratio,12f*safeMidY/pixelsy - 12f*safeHeight/pixelsy,1.0f);
        letBBackgroundPeg.transform.position = new Vector3(12f*ratio*safeMidX/pixelsx - 10.75f*ratio,12f*safeMidY/pixelsy - 2f*safeHeight/pixelsy,0.5f);
        holeGreenBackgroundPeg.transform.position = new Vector3(12f*ratio*safeMidX/pixelsx - 3.5f*ratio,12f*safeMidY/pixelsy - 11.5f*safeHeight/pixelsy,1.0f);
        hole4BackgroundPeg.transform.position = new Vector3(12f*ratio*safeMidX/pixelsx - 9.5f*ratio,12f*safeMidY/pixelsy - 12f*safeHeight/pixelsy,0.5f);
        circleBackgroundPeg.transform.position = new Vector3(12f*ratio*safeMidX/pixelsx - 1f*ratio,12f*safeMidY/pixelsy - 9.5f*safeHeight/pixelsy,0.5f);
        
        backgroundImage.transform.position = new Vector3(12f*ratio*safeMidX/pixelsx - 6f*ratio,12f*safeMidY/pixelsy - 6f,1.5f);

        backgroundBlockTop.transform.position = new Vector3(pixelsx*0.5f,safeMaxY);
        backgroundBlockRight.transform.position = new Vector3(safeMaxX,pixelsy*0.5f);
        backgroundBlockLeft.transform.position = new Vector3(safeMinX,pixelsy*0.5f);
        backgroundBlockBottom.transform.position = new Vector3(pixelsx*0.5f,safeMinY);

        layoutChecker.transform.position = new UnityEngine.Vector3(3f*pixelsx, 4f*pixelsy, 0f);
    }

    // Update is called once per frame
    void Update() {
        if (pixelsx != Screen.width || pixelsy != Screen.height || yLayoutChecker != layoutChecker.transform.position.y) {
            SceneSizer();
            SceneLayout();
		}
    }
}