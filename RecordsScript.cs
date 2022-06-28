using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class RecordsScript : MonoBehaviour {

	private Vector2 Bckpos;
	private Vector2 Resetpos;
	private Vector2 Tpos;
	private Vector2 SubTpos;
	private Vector2 Easypos;
	private Vector2 Medpos;
	private Vector2 Hardpos;
	private Vector2 Expertpos;
	private Vector2 Insanepos;
	private Vector2 Worldpushpos;
	private GUIStyle style1 = new GUIStyle();
	private GUIStyle style2 = new GUIStyle();
	public Font Myfont;
	public Button WorldButton;

    public GameObject Title, Subtitle, Back, Easy, Med, Hard, Expert, Insane, Reset;
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
			
		style1.fontSize = (int) Mathf.Floor(Screen.height*0.07f);
		style1.normal.textColor = new Color (1,1,1,1);
		style1.alignment = TextAnchor.MiddleCenter;
		style1.font = Myfont;
		
		style2.fontSize = (int) Mathf.Floor(Screen.height*0.09f);
		style2.normal.textColor = new Color (0.5f,0,0.5f,1);
		style2.alignment = TextAnchor.MiddleCenter;
		style2.font = Myfont;

		if (Social.localUser.authenticated) {
			WorldButton.interactable = true;
		} else {
			WorldButton.interactable = false;
		}
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
        float widthAdj = 0.3f;
        float heightAdj = 0.04f;
		Title.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*0.975f,safeUIHeight*0.125f);
        Subtitle.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*0.975f,safeUIHeight*0.06f);
        WorldButton.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIHeight*0.25f,safeUIHeight*0.25f);
        Easy.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*widthAdj,safeUIHeight*0.12f);
        Med.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*widthAdj,safeUIHeight*0.12f);
        Hard.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*widthAdj,safeUIHeight*0.12f);
        Expert.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*widthAdj,safeUIHeight*0.12f);
        Insane.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*widthAdj,safeUIHeight*0.12f);
        Reset.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*widthAdj,safeUIHeight*0.1f);
		Back.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*0.2f,safeUIHeight*0.1f);

        backgroundImage.GetComponent<Transform>().localScale = new Vector2(ratio*safeWidth/pixelsx, safeHeight/pixelsy);

        backgroundBlockTop.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeX*1.5f,sizeY*0.25f);
        backgroundBlockRight.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeX*0.25f,sizeY*1.5f);
        backgroundBlockLeft.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeX*0.25f,sizeY*1.5f);
        backgroundBlockBottom.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeX*1.5f,sizeY*0.25f);
	}
    
    void SceneLayout() {
		Worldpushpos.x = safeMinX + safeWidth*0.85f;
		Worldpushpos.y = safeMinY + safeHeight*0.85f;
		WorldButton.transform.position = Worldpushpos;
		
		Tpos.x = safeMidX;
		Tpos.y = safeMinY + safeHeight*0.9f;
		Title.transform.position = Tpos;
	
		SubTpos.x = safeMidX;
		SubTpos.y = safeMinY + safeHeight*0.8f;
		Subtitle.transform.position = SubTpos;
		
		Bckpos.x = safeMidX;
		Bckpos.y = safeMinY + safeHeight*0.075f;
		Back.transform.position = Bckpos;
		
		Easypos.x = safeMinX + safeWidth*0.18f;
		Easypos.y = safeMinY + safeHeight*0.675f;
		Easy.transform.position = Easypos;
		
		Medpos.x = safeMinX + safeWidth*0.18f;
		Medpos.y = safeMinY + safeHeight*0.525f;
		Med.transform.position = Medpos;
		
		Hardpos.x = safeMinX + safeWidth*0.18f;
		Hardpos.y = safeMinY + safeHeight*0.375f;
		Hard.transform.position = Hardpos;
		
		Expertpos.x = safeMinX + safeWidth*0.18f;
		Expertpos.y = safeMinY + safeHeight*0.225f;
		Expert.transform.position = Expertpos;
		
		List<float> Expertgames = new List<float> {PlayerPrefs.GetFloat("highscoreXprt1"), PlayerPrefs.GetFloat("highscoreXprt2"), PlayerPrefs.GetFloat("highscoreXprt3"), PlayerPrefs.GetFloat("highscoreXprt4"), PlayerPrefs.GetFloat("highscoreXprt5")};
		float maxxprtgame = Mathf.Max(Expertgames.ToArray());
		if (maxxprtgame >= 60000) {
			PlayerPrefs.SetFloat("InsaneLevelAllow",1);
		}
		if (PlayerPrefs.GetFloat("InsaneLevelAllow") != 1f) {
			Insanepos.x = Screen.width*2f;
			Insanepos.y = Screen.height*2f;
		}
		if (PlayerPrefs.GetFloat("InsaneLevelAllow") == 1f) {
			Insanepos.x = safeMinX + safeWidth*0.18f;
			Insanepos.y = safeMinY + safeHeight*0.075f;
		}
		Insane.transform.position = Insanepos;
		
		GameObject Reset = GameObject.Find("Reset");
		Resetpos.x = safeMinX + safeWidth*0.85f;
		Resetpos.y = safeMinY + safeHeight*0.075f;
		Reset.transform.position = Resetpos;
        
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

	public void WorldPush () {
		Social.ShowLeaderboardUI();
	}
	
	void OnGUI () {
	
		if (SceneManager.GetActiveScene().name.Contains("Easy")) {
			GUI.Label (new Rect (safeMinX + safeWidth*0.33f,(pixelsy - safeMaxY) + safeHeight*0.23f,safeWidth*0.33f,safeHeight*0.13f),"Regular", style2);
			GUI.Label (new Rect (safeMinX + safeWidth*0.33f,(pixelsy - safeMaxY) + safeHeight*0.35f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreEasy1")), style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.33f,(pixelsy - safeMaxY) + safeHeight*0.45f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreEasy2")), style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.33f,(pixelsy - safeMaxY) + safeHeight*0.55f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreEasy3")), style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.33f,(pixelsy - safeMaxY) + safeHeight*0.65f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreEasy4")), style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.33f,(pixelsy - safeMaxY) + safeHeight*0.75f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreEasy5")), style1);
			
			GUI.Label (new Rect (safeMinX + safeWidth*0.66f,(pixelsy - safeMaxY) + safeHeight*0.23f,safeWidth*0.33f,safeHeight*0.13f),"Endurance", style2);
			GUI.Label (new Rect (safeMinX + safeWidth*0.66f,(pixelsy - safeMaxY) + safeHeight*0.35f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreEndureEasy1")) + ",  " + (PlayerPrefs.GetFloat("highscoreGamesEasy1")) + "(" + (PlayerPrefs.GetFloat("highscorePerfectEasy1")) + ")", style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.66f,(pixelsy - safeMaxY) + safeHeight*0.45f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreEndureEasy2")) + ",  " + (PlayerPrefs.GetFloat("highscoreGamesEasy2")) + "(" + (PlayerPrefs.GetFloat("highscorePerfectEasy2")) + ")", style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.66f,(pixelsy - safeMaxY) + safeHeight*0.55f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreEndureEasy3")) + ",  " + (PlayerPrefs.GetFloat("highscoreGamesEasy3")) + "(" + (PlayerPrefs.GetFloat("highscorePerfectEasy3")) + ")", style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.66f,(pixelsy - safeMaxY) + safeHeight*0.65f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreEndureEasy4")) + ",  " + (PlayerPrefs.GetFloat("highscoreGamesEasy4")) + "(" + (PlayerPrefs.GetFloat("highscorePerfectEasy4")) + ")", style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.66f,(pixelsy - safeMaxY) + safeHeight*0.75f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreEndureEasy5")) + ",  " + (PlayerPrefs.GetFloat("highscoreGamesEasy5")) + "(" + (PlayerPrefs.GetFloat("highscorePerfectEasy5")) + ")", style1);
		}
		if (SceneManager.GetActiveScene().name.Contains("Med")) {
			GUI.Label (new Rect (safeMinX + safeWidth*0.33f,(pixelsy - safeMaxY) + safeHeight*0.23f,safeWidth*0.33f,safeHeight*0.13f),"Regular", style2);
			GUI.Label (new Rect (safeMinX + safeWidth*0.33f,(pixelsy - safeMaxY) + safeHeight*0.35f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreMed1")), style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.33f,(pixelsy - safeMaxY) + safeHeight*0.45f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreMed2")), style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.33f,(pixelsy - safeMaxY) + safeHeight*0.55f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreMed3")), style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.33f,(pixelsy - safeMaxY) + safeHeight*0.65f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreMed4")), style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.33f,(pixelsy - safeMaxY) + safeHeight*0.75f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreMed5")), style1);
			
			GUI.Label (new Rect (safeMinX + safeWidth*0.66f,(pixelsy - safeMaxY) + safeHeight*0.23f,safeWidth*0.33f,safeHeight*0.13f),"Endurance", style2);
			GUI.Label (new Rect (safeMinX + safeWidth*0.66f,(pixelsy - safeMaxY) + safeHeight*0.35f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreEndureMed1")) + ",  " + (PlayerPrefs.GetFloat("highscoreGamesMed1")) + "(" + (PlayerPrefs.GetFloat("highscorePerfectMed1")) + ")", style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.66f,(pixelsy - safeMaxY) + safeHeight*0.45f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreEndureMed2")) + ",  " + (PlayerPrefs.GetFloat("highscoreGamesMed2")) + "(" + (PlayerPrefs.GetFloat("highscorePerfectMed2")) + ")", style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.66f,(pixelsy - safeMaxY) + safeHeight*0.55f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreEndureMed3")) + ",  " + (PlayerPrefs.GetFloat("highscoreGamesMed3")) + "(" + (PlayerPrefs.GetFloat("highscorePerfectMed3")) + ")", style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.66f,(pixelsy - safeMaxY) + safeHeight*0.65f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreEndureMed4")) + ",  " + (PlayerPrefs.GetFloat("highscoreGamesMed4")) + "(" + (PlayerPrefs.GetFloat("highscorePerfectMed4")) + ")", style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.66f,(pixelsy - safeMaxY) + safeHeight*0.75f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreEndureMed5")) + ",  " + (PlayerPrefs.GetFloat("highscoreGamesMed5")) + "(" + (PlayerPrefs.GetFloat("highscorePerfectMed5")) + ")", style1);
		}
		if (SceneManager.GetActiveScene().name.Contains("Hard")) {
			GUI.Label (new Rect (safeMinX + safeWidth*0.33f,(pixelsy - safeMaxY) + safeHeight*0.23f,safeWidth*0.33f,safeHeight*0.13f),"Regular", style2);
			GUI.Label (new Rect (safeMinX + safeWidth*0.33f,(pixelsy - safeMaxY) + safeHeight*0.35f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreHard1")), style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.33f,(pixelsy - safeMaxY) + safeHeight*0.45f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreHard2")), style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.33f,(pixelsy - safeMaxY) + safeHeight*0.55f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreHard3")), style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.33f,(pixelsy - safeMaxY) + safeHeight*0.65f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreHard4")), style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.33f,(pixelsy - safeMaxY) + safeHeight*0.75f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreHard5")), style1);
			
			GUI.Label (new Rect (safeMinX + safeWidth*0.66f,(pixelsy - safeMaxY) + safeHeight*0.23f,safeWidth*0.33f,safeHeight*0.13f),"Endurance", style2);
			GUI.Label (new Rect (safeMinX + safeWidth*0.66f,(pixelsy - safeMaxY) + safeHeight*0.35f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreEndureHard1")) + ",  " + (PlayerPrefs.GetFloat("highscoreGamesHard1")) + "(" + (PlayerPrefs.GetFloat("highscorePerfectHard1")) + ")", style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.66f,(pixelsy - safeMaxY) + safeHeight*0.45f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreEndureHard2")) + ",  " + (PlayerPrefs.GetFloat("highscoreGamesHard2")) + "(" + (PlayerPrefs.GetFloat("highscorePerfectHard2")) + ")", style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.66f,(pixelsy - safeMaxY) + safeHeight*0.55f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreEndureHard3")) + ",  " + (PlayerPrefs.GetFloat("highscoreGamesHard3")) + "(" + (PlayerPrefs.GetFloat("highscorePerfectHard3")) + ")", style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.66f,(pixelsy - safeMaxY) + safeHeight*0.65f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreEndureHard4")) + ",  " + (PlayerPrefs.GetFloat("highscoreGamesHard4")) + "(" + (PlayerPrefs.GetFloat("highscorePerfectHard4")) + ")", style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.66f,(pixelsy - safeMaxY) + safeHeight*0.75f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreEndureHard5")) + ",  " + (PlayerPrefs.GetFloat("highscoreGamesHard5")) + "(" + (PlayerPrefs.GetFloat("highscorePerfectHard5")) + ")", style1);
		}
		if (SceneManager.GetActiveScene().name.Contains("Expert")) {
			GUI.Label (new Rect (safeMinX + safeWidth*0.33f,(pixelsy - safeMaxY) + safeHeight*0.23f,safeWidth*0.33f,safeHeight*0.13f),"Regular", style2);
			GUI.Label (new Rect (safeMinX + safeWidth*0.33f,(pixelsy - safeMaxY) + safeHeight*0.35f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreXprt1")), style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.33f,(pixelsy - safeMaxY) + safeHeight*0.45f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreXprt2")), style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.33f,(pixelsy - safeMaxY) + safeHeight*0.55f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreXprt3")), style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.33f,(pixelsy - safeMaxY) + safeHeight*0.65f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreXprt4")), style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.33f,(pixelsy - safeMaxY) + safeHeight*0.75f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreXprt5")), style1);
			
			GUI.Label (new Rect (safeMinX + safeWidth*0.66f,(pixelsy - safeMaxY) + safeHeight*0.23f,safeWidth*0.33f,safeHeight*0.13f),"Endurance", style2);
			GUI.Label (new Rect (safeMinX + safeWidth*0.66f,(pixelsy - safeMaxY) + safeHeight*0.35f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreEndureXprt1")) + ",  " + (PlayerPrefs.GetFloat("highscoreGamesXprt1")) + "(" + (PlayerPrefs.GetFloat("highscorePerfectXprt1")) + ")", style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.66f,(pixelsy - safeMaxY) + safeHeight*0.45f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreEndureXprt2")) + ",  " + (PlayerPrefs.GetFloat("highscoreGamesXprt2")) + "(" + (PlayerPrefs.GetFloat("highscorePerfectXprt2")) + ")", style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.66f,(pixelsy - safeMaxY) + safeHeight*0.55f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreEndureXprt3")) + ",  " + (PlayerPrefs.GetFloat("highscoreGamesXprt3")) + "(" + (PlayerPrefs.GetFloat("highscorePerfectXprt3")) + ")", style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.66f,(pixelsy - safeMaxY) + safeHeight*0.65f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreEndureXprt4")) + ",  " + (PlayerPrefs.GetFloat("highscoreGamesXprt4")) + "(" + (PlayerPrefs.GetFloat("highscorePerfectXprt4")) + ")", style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.66f,(pixelsy - safeMaxY) + safeHeight*0.75f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreEndureXprt5")) + ",  " + (PlayerPrefs.GetFloat("highscoreGamesXprt5")) + "(" + (PlayerPrefs.GetFloat("highscorePerfectXprt5")) + ")", style1);
		}
		if (SceneManager.GetActiveScene().name.Contains("Insane")) {
			GUI.Label (new Rect (safeMinX + safeWidth*0.33f,(pixelsy - safeMaxY) + safeHeight*0.23f,safeWidth*0.33f,safeHeight*0.13f),"Regular", style2);
			GUI.Label (new Rect (safeMinX + safeWidth*0.33f,(pixelsy - safeMaxY) + safeHeight*0.35f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreInsane1")), style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.33f,(pixelsy - safeMaxY) + safeHeight*0.45f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreInsane2")), style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.33f,(pixelsy - safeMaxY) + safeHeight*0.55f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreInsane3")), style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.33f,(pixelsy - safeMaxY) + safeHeight*0.65f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreInsane4")), style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.33f,(pixelsy - safeMaxY) + safeHeight*0.75f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreInsane5")), style1);
			
			GUI.Label (new Rect (safeMinX + safeWidth*0.66f,(pixelsy - safeMaxY) + safeHeight*0.23f,safeWidth*0.33f,safeHeight*0.13f),"Endurance", style2);
			GUI.Label (new Rect (safeMinX + safeWidth*0.66f,(pixelsy - safeMaxY) + safeHeight*0.35f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreEndureInsane1")) + ",  " + (PlayerPrefs.GetFloat("highscoreGamesInsane1")) + "(" + (PlayerPrefs.GetFloat("highscorePerfectInsane1")) + ")", style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.66f,(pixelsy - safeMaxY) + safeHeight*0.45f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreEndureInsane2")) + ",  " + (PlayerPrefs.GetFloat("highscoreGamesInsane2")) + "(" + (PlayerPrefs.GetFloat("highscorePerfectInsane2")) + ")", style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.66f,(pixelsy - safeMaxY) + safeHeight*0.55f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreEndureInsane3")) + ",  " + (PlayerPrefs.GetFloat("highscoreGamesInsane3")) + "(" + (PlayerPrefs.GetFloat("highscorePerfectInsane3")) + ")", style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.66f,(pixelsy - safeMaxY) + safeHeight*0.65f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreEndureInsane4")) + ",  " + (PlayerPrefs.GetFloat("highscoreGamesInsane4")) + "(" + (PlayerPrefs.GetFloat("highscorePerfectInsane4")) + ")", style1);
			GUI.Label (new Rect (safeMinX + safeWidth*0.66f,(pixelsy - safeMaxY) + safeHeight*0.75f,safeWidth*0.33f,safeHeight*0.10f),"" + (PlayerPrefs.GetFloat("highscoreEndureInsane5")) + ",  " + (PlayerPrefs.GetFloat("highscoreGamesInsane5")) + "(" + (PlayerPrefs.GetFloat("highscorePerfectInsane5")) + ")", style1);
		}
	}

    // Update is called once per frame
    void Update() {
        if (pixelsx != Screen.width || pixelsy != Screen.height || yLayoutChecker != layoutChecker.transform.position.y) {
            SceneSizer();
            SceneLayout();
		}
    }
}