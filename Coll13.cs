using UnityEngine;
using System.Collections.Generic;

public class Coll13 : MonoBehaviour {

	private List<string> ColliderBlock13 = new List<string> {"One", "LetA", "Square", "Checker","Two", "LetB", "Circle", "Stripe","Three", "LetC", "Triangle", "Polkadot","Four", "LetD", "Star", "Diagonal","Five", "LetE", "Plus", "Target"};
	public GameObject LightGreen;
	public GameObject LightRed;
	public GameObject GoodNoise;
	public GameObject BadNoise;
	private Insane insane;
	private Matcher match;

	void Start () {}

	void Update () {
		if (Physics2D.OverlapCircle(this.transform.position,0.7f) == true) {
			GameObject peg = Physics2D.OverlapCircle(this.transform.position,0.7f).gameObject;
			if (peg.name.Contains (ColliderBlock13[8+PlayerPrefs.GetInt("indexkey")]) || peg.name.Contains(ColliderBlock13[(PlayerPrefs.GetInt("Answers12")-1)*4+PlayerPrefs.GetInt("indexkey1")])){
				GameObject LG3 = (GameObject) Instantiate (LightGreen,new Vector2(this.transform.position.x,this.transform.position.y), Quaternion.identity);
				Destroy (LG3,0.5f);
				Destroy (peg);
				insane = GameObject.FindObjectOfType <Insane>();
				insane.PegDestroyed ();
				if (GameObject.FindGameObjectWithTag("NoSFX") == false) {
					GameObject GN = (GameObject) Instantiate (GoodNoise,new Vector2(0f,0f), Quaternion.identity);
					GameObject.DontDestroyOnLoad(GN);
					Destroy (GN,0.5f);
				}
			} else if (peg.name.Contains("Start") || peg.name.Contains("Cover")) {
                // do nothing
			} else {	
				insane = GameObject.FindObjectOfType <Insane>();
				insane.StrikeDestroyed ();	
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
				insane = GameObject.FindObjectOfType <Insane>();
				insane.PegDestroyed ();		
				if (GameObject.FindGameObjectWithTag("NoSFX") == false) {
					GameObject BN = (GameObject) Instantiate (BadNoise,new Vector2(0f,0f), Quaternion.identity);
					GameObject.DontDestroyOnLoad(BN);
					Destroy (BN,0.5f);
				}
			}
		}
	}
}