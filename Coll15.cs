using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Coll15 : MonoBehaviour {

	private List<string> ColliderBlock15 = new List<string> {"One", "LetA", "Square", "Checker","Two", "LetB", "Circle", "Stripe","Three", "LetC", "Triangle", "Polkadot","Four", "LetD", "Star", "Diagonal","Five", "LetE", "Plus", "Target"};
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
			if (peg.name.Contains (ColliderBlock15[16+PlayerPrefs.GetInt("indexkey")]) || peg.name.Contains(ColliderBlock15[(PlayerPrefs.GetInt("Answers14")-1)*4+PlayerPrefs.GetInt("indexkey1")])){
				GameObject LG5 = (GameObject) Instantiate (LightGreen,new Vector2(this.transform.position.x,this.transform.position.y), Quaternion.identity);
				Destroy (LG5,0.5f);
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
				GameObject LR5 = (GameObject) Instantiate (LightRed,new Vector2(this.transform.position.x,this.transform.position.y), Quaternion.identity);
				Destroy (LR5,0.5f);		
				if (GameObject.Find("Strike3(Clone)") == true) {
					Destroy (GameObject.Find("Strike3(Clone)"));
				} else {
					if (GameObject.Find("Strike2(Clone)") == true) {
						Destroy (GameObject.Find("Strike2(Clone)"));
					} 
				}		
				Destroy (peg);
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