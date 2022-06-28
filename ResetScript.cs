using UnityEngine;
using System.Collections.Generic;

public class ResetScript : MonoBehaviour {

	private Vector2 Easypos;
	private Vector2 Medpos;
	private Vector2 Hardpos;
	private Vector2 Expertpos;
	private Vector2 Insanepos;
	private Vector2 Gamepos;
	private Vector2 Bckpos;
	private Vector2 Tpos;
	private Vector2 SubTpos;
	private Vector2 Explainpos;

    public GameObject Title, Subtitle, Explain, Back, Easy, Medium, Hard, Expert, Insane, Game;
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
	
		if (GameObject.FindGameObjectWithTag("Reset") == true) {
			Destroy (GameObject.FindGameObjectWithTag("Reset"));
		}

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
        float heightAdj = 0.06f;
		Title.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*0.975f,safeUIHeight*0.125f);
        Subtitle.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*0.975f,safeUIHeight*0.06f);
        Explain.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*0.975f,safeUIHeight*0.09f);
        Easy.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*widthAdj,safeUIHeight*heightAdj*(ratio-ratioAdj));
        Medium.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*widthAdj,safeUIHeight*heightAdj*(ratio-ratioAdj));
        Hard.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*widthAdj,safeUIHeight*heightAdj*(ratio-ratioAdj));
        Expert.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*widthAdj,safeUIHeight*heightAdj*(ratio-ratioAdj));
        Insane.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*widthAdj,safeUIHeight*heightAdj*(ratio-ratioAdj));
        Game.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*widthAdj,safeUIHeight*heightAdj*(ratio-ratioAdj));
		Back.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIWidth*0.2f,safeUIHeight*0.1f);

        backgroundImage.GetComponent<Transform>().localScale = new Vector2(ratio*safeWidth/pixelsx, safeHeight/pixelsy);

        backgroundBlockTop.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeX*1.5f,sizeY*0.25f);
        backgroundBlockRight.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeX*0.25f,sizeY*1.5f);
        backgroundBlockLeft.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeX*0.25f,sizeY*1.5f);
        backgroundBlockBottom.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeX*1.5f,sizeY*0.25f);
	}
    
    void SceneLayout() {
		Easypos.x = safeMinX + safeWidth*0.25f;
		Easypos.y = safeMinY + safeHeight*0.57f;
		Easy.transform.position = Easypos;
		
		Medpos.x = safeMinX + safeWidth*0.75f;
		Medpos.y = safeMinY + safeHeight*0.57f;
		Medium.transform.position = Medpos;
		
		List<float> Expertgames = new List<float> {PlayerPrefs.GetFloat("highscoreXprt1"), PlayerPrefs.GetFloat("highscoreXprt2"), PlayerPrefs.GetFloat("highscoreXprt3"), PlayerPrefs.GetFloat("highscoreXprt4"), PlayerPrefs.GetFloat("highscoreXprt5")};
		if (PlayerPrefs.GetFloat("InsaneLevelAllow") != 1) {
			Insanepos.x = Screen.width*2f;
			Insanepos.y = Screen.height*2f;
			Gamepos.x = safeMinX + safeWidth*0.49f;
			Gamepos.y = safeMinY + safeHeight*0.40f;
			Expertpos.x = safeMinX + safeWidth*0.75f;
			Expertpos.y = safeMinY + safeHeight*0.23f;
			Hardpos.x = safeMinX + safeWidth*0.25f;
			Hardpos.y = safeMinY + safeHeight*0.23f;
		}
		if (PlayerPrefs.GetFloat("InsaneLevelAllow") == 1) {
			Insanepos.x = safeMinX + safeWidth*0.25f;
			Insanepos.y = safeMinY + safeHeight*0.23f;
			Gamepos.x = safeMinX + safeWidth*0.75f;
			Gamepos.y = safeMinY + safeHeight*0.23f;
			Expertpos.x = safeMinX + safeWidth*0.75f;
			Expertpos.y = safeMinY + safeHeight*0.40f;
			Hardpos.x = safeMinX + safeWidth*0.25f;
			Hardpos.y = safeMinY + safeHeight*0.40f;
		}
		Hard.transform.position = Hardpos;
		Expert.transform.position = Expertpos;
		Insane.transform.position = Insanepos;
		Game.transform.position = Gamepos;
		
		Bckpos.x = safeMidX;
		Bckpos.y = safeMinY + safeHeight*0.075f;
		Back.transform.position = Bckpos;
		
		SubTpos.x = safeMidX;
		SubTpos.y = safeMinY + safeHeight*0.8f;
		Subtitle.transform.position = SubTpos;
		
		Tpos.x = safeMidX;
		Tpos.y = safeMinY + safeHeight*0.9f;
		Title.transform.position = Tpos;
		
		Explainpos.x = safeMidX;
		Explainpos.y = safeMinY + safeHeight*0.72f;
		Explain.transform.position = Explainpos;
        
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