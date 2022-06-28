using UnityEngine;
using System.Collections.Generic;

public class Coll7 : MonoBehaviour {

	private List<string> ColliderBlock7 = new List<string> {"Two", "LetB", "Blue", "Circle", "Stripe"};
	public GameObject LightGreen;
	public GameObject LightRed;
	public GameObject GoodNoise;
	public GameObject BadNoise;
	private Xprt xprt;
	private Matcher match;

	void Start () {}

	void Update () {
		if (Physics2D.OverlapCircle(this.transform.position,0.7f) == true) {
			GameObject peg = Physics2D.OverlapCircle(this.transform.position,0.7f).gameObject;
			if (peg.name.Contains (ColliderBlock7[PlayerPrefs.GetInt("indexkey1")])){
				GameObject LG2 = (GameObject) Instantiate (LightGreen,new Vector2(this.transform.position.x,this.transform.position.y), Quaternion.identity);
				Destroy (LG2,0.5f);
				Destroy (peg);		
				xprt = GameObject.FindObjectOfType <Xprt>();
				xprt.PegDestroyed ();		
				if (GameObject.FindGameObjectWithTag("NoSFX") == false) {
					GameObject GN = (GameObject) Instantiate (GoodNoise,new Vector2(0f,0f), Quaternion.identity);
					GameObject.DontDestroyOnLoad(GN);
					Destroy (GN,0.5f);
				}
			} else if (peg.name.Contains("Start") || peg.name.Contains("Cover")) {
                // do nothing
			} else {
				xprt = GameObject.FindObjectOfType <Xprt>();
				xprt.StrikeDestroyed ();	
				GameObject LR2 = (GameObject) Instantiate (LightRed,new Vector2(this.transform.position.x,this.transform.position.y), Quaternion.identity);
				Destroy (LR2,0.5f);	
				if (GameObject.Find("Strike3(Clone)") == true) {
					Destroy (GameObject.Find("Strike3(Clone)"));
				} else {
					if (GameObject.Find("Strike2(Clone)") == true) {
						Destroy (GameObject.Find("Strike2(Clone)"));
					} 
				}	
				Destroy (peg);
				xprt = GameObject.FindObjectOfType <Xprt>();
				xprt.PegDestroyed ();
				if (GameObject.FindGameObjectWithTag("NoSFX") == false) {
					GameObject BN = (GameObject) Instantiate (BadNoise,new Vector2(0f,0f), Quaternion.identity);
					GameObject.DontDestroyOnLoad(BN);
					Destroy (BN,0.5f);
				}
			}
		}
	}
}