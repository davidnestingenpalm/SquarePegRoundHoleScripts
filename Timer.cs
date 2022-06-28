using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

	private GUIStyle style1 = new GUIStyle();
	private GUIStyle style2 = new GUIStyle();
	private GUIStyle style3 = new GUIStyle();
	private LevelManager levelmanager;
	public float Timeleft;
	public float Memorizetime;
	public Font Myfont;
	public GameObject BeepNoise;
    
    float pixelsx, pixelsy, ratio, sizeX, sizeY;
    //safearea screen stuff
    private float safeMinX, safeMaxX, safeMinY, safeMaxY, safeMidX, safeMidY, safeHeight, safeWidth, safeUIMinX, safeUIMaxX, 
        safeUIMinY, safeUIMaxY, safeUIMidX, safeUIMidY, safeUIHeight, safeUIWidth;
	
	void Start () {
        SceneSizer();

		style1.fontSize = (int) Mathf.Floor(Screen.height*0.12f);
		style1.alignment = TextAnchor.MiddleCenter;
		style1.normal.textColor = Color.white;
		style1.fontStyle = FontStyle.Bold;
		style1.font = Myfont;
		
		style2.fontSize = (int) Mathf.Floor(Screen.height*0.07f);
        style2.alignment = TextAnchor.UpperLeft;
		style2.normal.textColor = Color.white;
		style2.font = Myfont;
		
		style3.fontSize = (int) Mathf.Floor(Screen.height*0.07f);
        style3.alignment = TextAnchor.UpperLeft;
		style3.normal.textColor = Color.white;
		style3.font = Myfont;
		
		if (SceneManager.GetActiveScene().name.Contains("Tutorial")) {
			Timeleft = 30.5f;
			Memorizetime= 20.0f;
		}
		if (SceneManager.GetActiveScene().name.Contains("Easy")) {
			Timeleft = 20f;
			Memorizetime= 7.0f;
		}
		if (SceneManager.GetActiveScene().name.Contains("Med")) {
			Timeleft = 25f;
			Memorizetime= 8.0f;
		}
		if (SceneManager.GetActiveScene().name.Contains("Hard")) {
			Timeleft = 30f;
			Memorizetime= 10.0f;
		}
		if (SceneManager.GetActiveScene().name.Contains("Xprt")) {
			Timeleft = 35f;
			Memorizetime= 12.0f;
		}
		if (SceneManager.GetActiveScene().name.Contains("Insane")) {
			Timeleft = 40f;
			Memorizetime= 14.0f;
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
    }

	void Update () {
		if (GameObject.Find("Start(Clone)")==true) {
			Memorizetime -= Time.deltaTime;
			if (Memorizetime <= 0f) {
				Memorizetime = 0f;
			}
		}
		if (GameObject.Find("Start(Clone)")==false) {
			if (GameObject.FindGameObjectWithTag("peg")==true) {
				Timeleft -= Time.deltaTime;			
				if (Timeleft <= 6.05f) {
					if (Timeleft >= 5.85) {
						if (GameObject.FindGameObjectWithTag("NoSFX") == false) {
							if (GameObject.FindGameObjectWithTag("Beep") == false) {
								GameObject BeepN = (GameObject)Instantiate (BeepNoise,new Vector2(0f,0f), Quaternion.identity);
								GameObject.DontDestroyOnLoad(BeepN);
							}
						}
					}
				}
				if (Timeleft <= 6f) {
					style2.normal.textColor = Color.red;
					style2.fontStyle = FontStyle.Bold;
				}
				if (Timeleft <= 0f) {
					Timeleft = 0f;
					levelmanager = GameObject.FindObjectOfType <LevelManager>();
					if (SceneManager.GetActiveScene().name.Contains ("Easy")) {
						levelmanager.LoadLevel("Lose Easy");
					}
					if (SceneManager.GetActiveScene().name.Contains ("Med")) {
						levelmanager.LoadLevel("Lose Med");
					}
					if (SceneManager.GetActiveScene().name.Contains ("Hard")) {
						levelmanager.LoadLevel("Lose Hard");
					}
					if (SceneManager.GetActiveScene().name.Contains ("Xprt")) {
						levelmanager.LoadLevel("Lose Xprt");
					}
					if (SceneManager.GetActiveScene().name.Contains ("Insane")) {
						levelmanager.LoadLevel("Lose Insane");
					}
				}
			} else {
				if (Timeleft > 6f) {	
					style2.normal.textColor =Color.Lerp(Color.white,Color.black,0.353f);
					style3.normal.textColor =Color.Lerp(Color.white,Color.black,0.353f);	
				} else {
					style2.normal.textColor =Color.Lerp(Color.red,Color.black,0.353f);
					style3.normal.textColor =Color.Lerp(Color.white,Color.black,0.353f);
				}
			}
		}
	}
	
	void OnGUI () {
        // GUI.Label - x range starts at left hand side and is positive to the right, y range starts at top of screen and is positive downward
		if (GameObject.Find("Start(Clone)")==true) {
			GUI.Label (new Rect (safeMinX + safeWidth*0.75f,(pixelsy - safeMaxY) + safeHeight*0.73f,safeMinX*0.14f,safeHeight*0.15f),"" + Memorizetime.ToString("f2"), style1);
		}
		if (GameObject.Find("Start(Clone)")==false) {
			GUI.Label (new Rect (safeMinX + safeWidth*0.01f,(pixelsy - safeMaxY) + safeHeight*0.84f,safeMinX*0.22f,safeHeight*0.1f),"Time: " + Timeleft.ToString("f2"), style2);
			GUI.Label (new Rect (safeMinX + safeWidth*0.01f,(pixelsy - safeMaxY) + safeHeight*0.92f,safeMinX*0.2f,safeHeight*0.1f),"Strikes:", style3);
		}
	}
}