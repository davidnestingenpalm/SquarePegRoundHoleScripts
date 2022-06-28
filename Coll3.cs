using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Coll3 : MonoBehaviour {

	private List<string> ColliderBlock3 = new List<string> {"Three", "LetC", "Green", "Triangle", "Polkadot"};
	public GameObject LightGreen;
	public GameObject LightRed;
	public GameObject GoodNoise;
	public GameObject BadNoise;	
	private Tutorial tutorial;
	private Easy easy;
	private Medium med;
	private Hard hard;
	private Xprt xprt;
	private Insane insane;
	private Matcher match;

	void Start () {}

	void Update () {
		if (Physics2D.OverlapCircle(this.transform.position,0.7f) == true) {
			GameObject peg = Physics2D.OverlapCircle(this.transform.position,0.7f).gameObject;
			if (peg.name.Contains (ColliderBlock3[PlayerPrefs.GetInt("indexkey")])){
				GameObject LG3 = (GameObject) Instantiate (LightGreen,new Vector2(this.transform.position.x,this.transform.position.y), Quaternion.identity);
				Destroy (LG3,0.5f);
				Destroy (peg);
				if (SceneManager.GetActiveScene().name.Contains("Tutorial")) {
					tutorial = GameObject.FindObjectOfType <Tutorial>();
					tutorial.PegDestroyed ();
				}
				if (SceneManager.GetActiveScene().name.Contains("Easy")) {
					easy = GameObject.FindObjectOfType <Easy>();
					easy.PegDestroyed ();
				}
				if (SceneManager.GetActiveScene().name.Contains("Med")) {
					med = GameObject.FindObjectOfType <Medium>();
					med.PegDestroyed ();
				}
				if (SceneManager.GetActiveScene().name.Contains("Hard")) {
					hard = GameObject.FindObjectOfType <Hard>();
					hard.PegDestroyed ();
				}
				if (SceneManager.GetActiveScene().name.Contains("Xprt")) {
					xprt = GameObject.FindObjectOfType <Xprt>();
					xprt.PegDestroyed ();
				}
				if (SceneManager.GetActiveScene().name.Contains("Insane")) {
					insane = GameObject.FindObjectOfType <Insane>();
					insane.PegDestroyed ();
				}
				if (GameObject.FindGameObjectWithTag("NoSFX") == false) {
					GameObject GN = (GameObject) Instantiate (GoodNoise,new Vector2(0f,0f), Quaternion.identity);
					GameObject.DontDestroyOnLoad(GN);
					Destroy (GN,0.5f);
				}
			} else if (peg.name.Contains("Start") || peg.name.Contains("Cover")) {
                // do nothing
			} else {
				if (SceneManager.GetActiveScene().name.Contains("Tutorial")) {
					tutorial = GameObject.FindObjectOfType <Tutorial>();
					tutorial.StrikeDestroyed ();
				}
				if (SceneManager.GetActiveScene().name.Contains("Easy")) {
					easy = GameObject.FindObjectOfType <Easy>();
					easy.StrikeDestroyed ();
				}
				if (SceneManager.GetActiveScene().name.Contains("Med")) {
					med = GameObject.FindObjectOfType <Medium>();
					med.StrikeDestroyed ();
				}
				if (SceneManager.GetActiveScene().name.Contains("Hard")) {
					hard = GameObject.FindObjectOfType <Hard>();
					hard.StrikeDestroyed ();
				}
				if (SceneManager.GetActiveScene().name.Contains("Xprt")) {
					xprt = GameObject.FindObjectOfType <Xprt>();
					xprt.StrikeDestroyed ();
				}	
				GameObject LR3 = (GameObject) Instantiate (LightRed,new Vector2(this.transform.position.x,this.transform.position.y), Quaternion.identity);
				Destroy (LR3,0.5f);	
				if (GameObject.Find("Strike3(Clone)") == true) {
					Destroy (GameObject.Find("Strike3(Clone)"));
				} else {
					if (GameObject.Find("Strike2(Clone)") == true) {
						Destroy (GameObject.Find("Strike2(Clone)"));
					} 
				}		
				Destroy (peg);
				if (SceneManager.GetActiveScene().name.Contains("Tutorial")) {
					tutorial = GameObject.FindObjectOfType <Tutorial>();
					tutorial.PegDestroyed ();
				}
				if (SceneManager.GetActiveScene().name.Contains("Easy")) {
					easy = GameObject.FindObjectOfType <Easy>();
					easy.PegDestroyed ();
				}
				if (SceneManager.GetActiveScene().name.Contains("Med")) {
					med = GameObject.FindObjectOfType <Medium>();
					med.PegDestroyed ();
				}
				if (SceneManager.GetActiveScene().name.Contains("Hard")) {
					hard = GameObject.FindObjectOfType <Hard>();
					hard.PegDestroyed ();
				}
				if (SceneManager.GetActiveScene().name.Contains("Xprt")) {
					xprt = GameObject.FindObjectOfType <Xprt>();
					xprt.PegDestroyed ();
				}
				if (SceneManager.GetActiveScene().name.Contains("Insane")) {
					insane = GameObject.FindObjectOfType <Insane>();
					insane.PegDestroyed ();
				}			
				if (GameObject.FindGameObjectWithTag("NoSFX") == false) {
					GameObject BN = (GameObject) Instantiate (BadNoise,new Vector2(0f,0f), Quaternion.identity);
					GameObject.DontDestroyOnLoad(BN);
					Destroy (BN,0.5f);
				}
			}
		}
	}
}