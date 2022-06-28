using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	private List<string> Easylevels = new List<string> {"Easy 123","Easy ABC","Easy Color","Easy Shape","Easy Pattern"};
	private List<string> Medlevels = new List<string> {"Med 123","Med ABC","Med Color","Med Shape","Med Pattern"};
	private List<string> Hardlevels = new List<string> {"Hard 123","Hard ABC","Hard Color","Hard Shape","Hard Pattern"};
	private List<string> Xprtlevels = new List<string> {"Xprt NumLet","Xprt NumShp","Xprt NumPat","Xprt ShpLet","Xprt PatLet","Xprt ShpPat"};

	public void LoadLevel(string name) {
		SceneManager.LoadScene(name);
	}
	public void QuitRequest() {
		Application.Quit ();
	}
	public void LoadDiffScreen() {
		if (GameObject.FindGameObjectWithTag ("endure") == true) {
			SceneManager.LoadScene("Menu Endur Diff");
		} else {
			SceneManager.LoadScene("Menu Reg Diff");
		}
		
	}			
	public void LoadNextLevel() {		
		if (SceneManager.GetActiveScene().name.Contains("Easy")) {
			if (GameObject.Find("EndureObject") == true) {
				SceneManager.LoadScene(Easylevels[Random.Range (0,5)]);
			} else {
				if (SceneManager.GetActiveScene().name.Contains("123")) {
					SceneManager.LoadScene("Easy ABC");
				}
				if (SceneManager.GetActiveScene().name.Contains("ABC")) {
					SceneManager.LoadScene("Easy Color");
				}
				if (SceneManager.GetActiveScene().name.Contains("Color")) {
					SceneManager.LoadScene("Easy Shape");
				}
				if (SceneManager.GetActiveScene().name.Contains("Shape")) {
					SceneManager.LoadScene("Easy Pattern");
				}
				if (SceneManager.GetActiveScene().name.Contains("Pattern")) {
					SceneManager.LoadScene("Win Easy");
				}
			}
		}
		
		if (SceneManager.GetActiveScene().name.Contains("Med")) {
			if (GameObject.Find("EndureObject") == true) {
				SceneManager.LoadScene(Medlevels[Random.Range (0,5)]);
			} else {
				if (SceneManager.GetActiveScene().name.Contains("123")) {
					SceneManager.LoadScene("Med ABC");
				}
				if (SceneManager.GetActiveScene().name.Contains("ABC")) {
					SceneManager.LoadScene("Med Color");
				}
				if (SceneManager.GetActiveScene().name.Contains("Color")) {
					SceneManager.LoadScene("Med Shape");
				}
				if (SceneManager.GetActiveScene().name.Contains("Shape")) {
					SceneManager.LoadScene("Med Pattern");
				}
				if (SceneManager.GetActiveScene().name.Contains("Pattern")) {
					SceneManager.LoadScene("Win Med");
				}
			}
		}
		
		if (SceneManager.GetActiveScene().name.Contains("Hard")) {
			if (GameObject.Find("EndureObject") == true) {
				SceneManager.LoadScene(Hardlevels[Random.Range (0,5)]);
			} else {
				if (SceneManager.GetActiveScene().name.Contains("123")) {
					SceneManager.LoadScene("Hard ABC");
				}
				if (SceneManager.GetActiveScene().name.Contains("ABC")) {
					SceneManager.LoadScene("Hard Color");
				}
				if (SceneManager.GetActiveScene().name.Contains("Color")) {
					SceneManager.LoadScene("Hard Shape");
				}
				if (SceneManager.GetActiveScene().name.Contains("Shape")) {
					SceneManager.LoadScene("Hard Pattern");
				}
				if (SceneManager.GetActiveScene().name.Contains("Pattern")) {
					SceneManager.LoadScene("Win Hard");
				}
			}
		}
		
		if (SceneManager.GetActiveScene().name.Contains("Xprt")) {
			if (GameObject.Find("EndureObject") == true) {
				SceneManager.LoadScene(Xprtlevels[Random.Range (0,6)]);
			} else {
				if (SceneManager.GetActiveScene().name.Contains("NumLet")) {
					SceneManager.LoadScene("Xprt NumShp");
				}
				if (SceneManager.GetActiveScene().name.Contains("NumShp")) {
					SceneManager.LoadScene("Xprt NumPat");
				}
				if (SceneManager.GetActiveScene().name.Contains("NumPat")) {
					SceneManager.LoadScene("Xprt ShpLet");
				}
				if (SceneManager.GetActiveScene().name.Contains("ShpLet")) {
					SceneManager.LoadScene("Xprt PatLet");
				}
				if (SceneManager.GetActiveScene().name.Contains("PatLet")) {
					SceneManager.LoadScene("Xprt ShpPat");
				}
				if (SceneManager.GetActiveScene().name.Contains("ShpPat")) {
					SceneManager.LoadScene("Win Xprt");
				}
			}
		}
		
		if (SceneManager.GetActiveScene().name.Contains("Insane")) {
			if (GameObject.Find("EndureObject") == true) {
				SceneManager.LoadScene("Insane");
			} else {
				if (PlayerPrefs.GetInt("NumberGame",0) > 7) {
//				if (ScoreCard.NumberGame > 7) {
					SceneManager.LoadScene("Win Insane");
				} else {
					SceneManager.LoadScene("Insane");
				}
			}
		}
		
	}
}