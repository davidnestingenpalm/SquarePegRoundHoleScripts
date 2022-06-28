using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	public GameObject Song1;
	public GameObject Song2;
	public GameObject Song3;
	public GameObject Song4;
	public GameObject SongNone;
	public GameObject NoSndFX;
	public GameObject sfxCheck;
	public GameObject sfxX;
    
    float pixelsx, pixelsy, ratio, sizeX, sizeY;
    float yTopEdge, yHeightAdj, xRightEdge, xWidthAdj, yMid, xMid;
    public GameObject layoutChecker;//position set in scene layout, checked in update to keep layout correct. Replaces checking an actual game object which may need ot move
    private float yLayoutChecker;
    //safearea screen stuff
    private float safeMinX, safeMaxX, safeMinY, safeMaxY, safeMidX, safeMidY, safeHeight, safeWidth, safeUIMinX, safeUIMaxX, 
        safeUIMinY, safeUIMaxY, safeUIMidX, safeUIMidY, safeUIHeight, safeUIWidth;

	void Start () {
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
        float ratioAdj = -0.3f;
        float widthAdj = 0.5f;
        float heightAdj = 0.06f;
        sfxCheck.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIHeight*heightAdj*(ratio-ratioAdj), safeUIHeight*heightAdj*(ratio-ratioAdj));
        sfxX.GetComponent<RectTransform>().sizeDelta = new Vector2(safeUIHeight*heightAdj*(ratio-ratioAdj), safeUIHeight*heightAdj*(ratio-ratioAdj));
    }

    void SceneLayout () {
		if (GameObject.FindGameObjectWithTag("NoSFX") == true) {
            sfxCheck.transform.position = new Vector3(3f*pixelsx, 3f*pixelsy,-1.1f);
            sfxX.transform.position = new Vector3(safeMinX + safeWidth*0.75f,safeMinY + safeHeight*0.445f,-1.1f);
		} else {
            sfxCheck.transform.position = new Vector3(safeMinX + safeWidth*0.75f,safeMinY + safeHeight*0.445f,-1.1f);
            sfxX.transform.position = new Vector3(3f*pixelsx, 3f*pixelsy,-1.1f);
		}

        layoutChecker.transform.position = new UnityEngine.Vector3(3f*pixelsx, 4f*pixelsy, 0f);
	}
	
	public void Music1 () {
		if (GameObject.FindGameObjectWithTag("Music") == true) {
			Destroy (GameObject.FindGameObjectWithTag("Music"));
		}
		GameObject Music = (GameObject) Instantiate (Song1,new Vector2(0f,0f), Quaternion.identity);
		GameObject.DontDestroyOnLoad(Music);
	}
	public void Music2 () {
		if (GameObject.FindGameObjectWithTag("Music") == true) {
			Destroy (GameObject.FindGameObjectWithTag("Music"));
		}
		GameObject Music = (GameObject) Instantiate (Song2,new Vector2(0f,0f), Quaternion.identity);
		GameObject.DontDestroyOnLoad(Music);
	}
	public void Music3 () {
		if (GameObject.FindGameObjectWithTag("Music") == true) {
			Destroy (GameObject.FindGameObjectWithTag("Music"));
		}
		GameObject Music = (GameObject) Instantiate (Song3,new Vector2(0f,0f), Quaternion.identity);
		GameObject.DontDestroyOnLoad(Music);
	}
	public void Music4 () {
		if (GameObject.FindGameObjectWithTag("Music") == true) {
			Destroy (GameObject.FindGameObjectWithTag("Music"));
		}
		GameObject Music = (GameObject) Instantiate (Song4,new Vector2(0f,0f), Quaternion.identity);
		GameObject.DontDestroyOnLoad(Music);
	}
	public void NoMusic () {
		if (GameObject.FindGameObjectWithTag("Music") == true) {
			Destroy (GameObject.FindGameObjectWithTag("Music"));
		}
		GameObject Music = (GameObject) Instantiate (SongNone,new Vector2(0f,0f), Quaternion.identity);
		GameObject.DontDestroyOnLoad(Music);
	}
	public void NoSoundFX () {
		if (GameObject.FindGameObjectWithTag("NoSFX") == false) {
			GameObject NoSFX = (GameObject) Instantiate (NoSndFX,new Vector2(0f,0f), Quaternion.identity);
			GameObject.DontDestroyOnLoad(NoSFX);
            sfxCheck.transform.position = new Vector3(3f*pixelsx, 3f*pixelsy,-1.1f);
            sfxX.transform.position = new Vector3(safeMinX + safeWidth*0.75f,safeMinY + safeHeight*0.445f,-1.1f);
		} else {
			Destroy (GameObject.FindGameObjectWithTag("NoSFX"));
            sfxX.transform.position = new Vector3(3f*pixelsx, 3f*pixelsy,-1.1f);
            sfxCheck.transform.position = new Vector3(safeMinX + safeWidth*0.75f,safeMinY + safeHeight*0.445f,-1.1f);
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