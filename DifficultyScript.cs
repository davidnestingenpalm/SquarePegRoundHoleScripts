using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class DifficultyScript : MonoBehaviour {
	
	private Vector2 Easypos;
	private Vector2 Medpos;
	private Vector2 Hardpos;
	private Vector2 Exppos;
	private Vector2 Insanepos;
	private Vector2 Bckpos;
	private Vector2 Tpos;
	private Vector2 SubTpos;
	private Vector2 gameTypepos;
	private ScoreCard zeroer;
    public GameObject Esy, Med, MedOff, Hrd, HrdOff, Exprt, ExprtOff, Insane, gameType;

    public GameObject Title, Subtitle, Back;
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
		zeroer = GameObject.FindObjectOfType<ScoreCard>();
		zeroer.EraseScores();		
		List<float> Easygames = new List<float> {PlayerPrefs.GetFloat("highscoreGamesEasy1"), PlayerPrefs.GetFloat("highscoreGamesEasy2"), PlayerPrefs.GetFloat("highscoreGamesEasy3"), PlayerPrefs.GetFloat("highscoreGamesEasy4"), PlayerPrefs.GetFloat("highscoreGamesEasy5")};
		List<float> Medgames = new List<float> {PlayerPrefs.GetFloat("highscoreGamesMed1"), PlayerPrefs.GetFloat("highscoreGamesMed2"), PlayerPrefs.GetFloat("highscoreGamesMed3"), PlayerPrefs.GetFloat("highscoreGamesMed4"), PlayerPrefs.GetFloat("highscoreGamesMed5")};	
		List<float> Hardgames = new List<float> {PlayerPrefs.GetFloat("highscoreGamesHard1"), PlayerPrefs.GetFloat("highscoreGamesHard2"), PlayerPrefs.GetFloat("highscoreGamesHard3"), PlayerPrefs.GetFloat("highscoreGamesHard4"), PlayerPrefs.GetFloat("highscoreGamesHard5")};
		List<float> Expertgames = new List<float> {PlayerPrefs.GetFloat("highscoreXprt1"), PlayerPrefs.GetFloat("highscoreXprt2"), PlayerPrefs.GetFloat("highscoreXprt3"), PlayerPrefs.GetFloat("highscoreXprt4"), PlayerPrefs.GetFloat("highscoreXprt5")};	
		float maxeasygame = Mathf.Max(Easygames.ToArray());
		if (maxeasygame >= 5) {
			PlayerPrefs.SetFloat("MedLevelAllow2",1);
		}
		float maxmedgame = Mathf.Max(Medgames.ToArray());
		if (maxmedgame >= 5) {
			PlayerPrefs.SetFloat("HardLevelAllow2",1);
		}
		float maxhardgame = Mathf.Max(Hardgames.ToArray());
		if (maxhardgame >= 5) {
			PlayerPrefs.SetFloat("ExpertLevelAllow2",1);
		}
		float maxxprtgame = Mathf.Max(Expertgames.ToArray());
		if (maxxprtgame >= 60000) {
			PlayerPrefs.SetFloat("InsaneLevelAllow",1);
		}
        
        SceneSizer();
        SceneLayout();
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
        Subtitle.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*0.975f,safeUIHeight*0.06f);
		Back.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*0.2f,safeUIHeight*0.1f);

        float ratioAdj = -0.3f;
        float widthAdj = 0.5f;
        float heightAdj = 0.075f;
        gameType.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*0.975f, safeUIHeight*0.125f);
        Esy.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*widthAdj, safeUIHeight*heightAdj*(ratio-ratioAdj));
        Med.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*widthAdj, safeUIHeight*heightAdj*(ratio-ratioAdj));
        MedOff.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*widthAdj, safeUIHeight*heightAdj*(ratio-ratioAdj));
        Hrd.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*widthAdj, safeUIHeight*heightAdj*(ratio-ratioAdj));
        HrdOff.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*widthAdj, safeUIHeight*heightAdj*(ratio-ratioAdj));
        Exprt.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*widthAdj, safeUIHeight*heightAdj*(ratio-ratioAdj));
        ExprtOff.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*widthAdj, safeUIHeight*heightAdj*(ratio-ratioAdj));
        Insane.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*widthAdj, safeUIHeight*heightAdj*(ratio-ratioAdj));
    }

    void SceneLayout () {        
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
        
		Tpos.x = safeMidX;
		Tpos.y = safeMinY + safeHeight*0.9f;
		Title.transform.position = Tpos;
		
		SubTpos.x = safeMidX;
		SubTpos.y = safeMinY + safeHeight*0.8f;
		Subtitle.transform.position = SubTpos;
		
		gameTypepos.x = safeMidX;
        gameTypepos.y = safeMidY;
		gameType.transform.position = gameTypepos;
        
		Easypos.x = safeMinX + safeWidth*0.22f;
		Easypos.y = safeMinY + safeHeight*0.59f;
		Esy.transform.position = Easypos;
	
		if (PlayerPrefs.GetFloat("MedLevelAllow1") != 1f && PlayerPrefs.GetFloat("MedLevelAllow2") != 1f) {
			Medpos.x = Screen.width*2f;
			Medpos.y = Screen.height*2f;
		}
		if (PlayerPrefs.GetFloat("MedLevelAllow1") == 1f || PlayerPrefs.GetFloat("MedLevelAllow2") == 1f) {
			Medpos.x = safeMinX + safeWidth*0.78f;
			Medpos.y = safeMinY + safeHeight*0.59f;
		}
		Med.transform.position = Medpos;
		
		if (PlayerPrefs.GetFloat("MedLevelAllow1") != 1f && PlayerPrefs.GetFloat("MedLevelAllow2") != 1f) {
			Medpos.x = safeMinX + safeWidth*0.78f;
			Medpos.y = safeMinY + safeHeight*0.59f;
		}
		if (PlayerPrefs.GetFloat("MedLevelAllow1") == 1f || PlayerPrefs.GetFloat("MedLevelAllow2") == 1f) {
			Medpos.x = Screen.width*2f;
			Medpos.y = Screen.height*2f;
		}
		MedOff.transform.position = Medpos;
		
		if (PlayerPrefs.GetFloat("HardLevelAllow1") != 1f && PlayerPrefs.GetFloat("HardLevelAllow2") != 1f) {
			Hardpos.x = Screen.width*2f;
			Hardpos.y = Screen.height*2f;
		}
		if (PlayerPrefs.GetFloat("HardLevelAllow1") == 1f || PlayerPrefs.GetFloat("HardLevelAllow2") == 1f) {
			Hardpos.x = safeMinX + safeWidth*0.22f;
			Hardpos.y = safeMinY + safeHeight*0.31f;
		}
		Hrd.transform.position = Hardpos;
		
		if (PlayerPrefs.GetFloat("HardLevelAllow1") != 1f && PlayerPrefs.GetFloat("HardLevelAllow2") != 1f) {
			Hardpos.x = safeMinX + safeWidth*0.22f;
			Hardpos.y = safeMinY + safeHeight*0.31f;
		}
		if (PlayerPrefs.GetFloat("HardLevelAllow1") == 1f || PlayerPrefs.GetFloat("HardLevelAllow2") == 1f) {
			Hardpos.x = Screen.width*2f;
			Hardpos.y = Screen.height*2f;
		}
		HrdOff.transform.position = Hardpos;
		
		if (PlayerPrefs.GetFloat("ExpertLevelAllow1") != 1f && PlayerPrefs.GetFloat("ExpertLevelAllow2") != 1f) {
			Exppos.x = Screen.width*2f;
			Exppos.y = Screen.height*2f;
		}
		if (PlayerPrefs.GetFloat("ExpertLevelAllow1") == 1f || PlayerPrefs.GetFloat("ExpertLevelAllow2") == 1f) {
			Exppos.x = safeMinX + safeWidth*0.78f;
			Exppos.y = safeMinY + safeHeight*0.31f;
		}
		Exprt.transform.position = Exppos;
		
		if (PlayerPrefs.GetFloat("ExpertLevelAllow1") != 1f && PlayerPrefs.GetFloat("ExpertLevelAllow2") != 1f) {
			Exppos.x = safeMinX + safeWidth*0.78f;
			Exppos.y = safeMinY + safeHeight*0.31f;
		}
		if (PlayerPrefs.GetFloat("ExpertLevelAllow1") == 1f || PlayerPrefs.GetFloat("ExpertLevelAllow2") == 1f) {
			Exppos.x = Screen.width*2f;
			Exppos.y = Screen.height*2f;
		}
		ExprtOff.transform.position = Exppos;
		
		if (PlayerPrefs.GetFloat("InsaneLevelAllow") == 1f) {
			Insanepos.x = safeMinX + safeWidth*0.48f;
			Insanepos.y = safeMinY + safeHeight*0.45f;
		}
		if (PlayerPrefs.GetFloat("InsaneLevelAllow") != 1f) {
			Insanepos.x = Screen.width*2f;
			Insanepos.y = Screen.height*2f;
		}
		Insane.transform.position = Insanepos;
		
		Bckpos.x = safeMidX;
		Bckpos.y = safeMinY + safeHeight*0.075f;
		Back.transform.position = Bckpos;
	}
    
    // Update is called once per frame
    void Update() {
        if (pixelsx != Screen.width || pixelsy != Screen.height || yLayoutChecker != layoutChecker.transform.position.y) {
            SceneSizer();
            SceneLayout();
		}
    }
}