using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Matcher : MonoBehaviour {

	private int indexkey,indexkey1,q;
	private List<int> Answers,Answers1,Answers2;
	private List<List<int>> ListAns,ListAns1;

	void Start () {}

	void Indexer () {
		string scenename = SceneManager.GetActiveScene().name;
		if (SceneManager.GetActiveScene().name.Contains("123") || SceneManager.GetActiveScene().name.Contains("Tutorial") || SceneManager.GetActiveScene().name.Contains("NumLet")) {
			indexkey = 0;
			indexkey1 = 1;
		}
		if (SceneManager.GetActiveScene().name.Contains ("ABC")) {
			indexkey = 1;
		}
		if (SceneManager.GetActiveScene().name.Contains ("Color")) {
			indexkey = 2;
		}
		if (SceneManager.GetActiveScene().name.Contains ("Shape") || SceneManager.GetActiveScene().name.Contains("ShpLet") || SceneManager.GetActiveScene().name.Contains("Music")) {
			indexkey = 3;
			indexkey1 = 1;
		}
		if (SceneManager.GetActiveScene().name.Contains("Pattern") || SceneManager.GetActiveScene().name.Contains("PatLet")) {
			indexkey = 4;
			indexkey1 = 1;
		}
		if (SceneManager.GetActiveScene().name.Contains("Credit") ||SceneManager.GetActiveScene().name.Contains("ShpPat")) {
			indexkey = 3;
			indexkey1 = 4;
		}
		if (SceneManager.GetActiveScene().name.Contains("NumShp")) {
			indexkey = 0;
			indexkey1 = 3;
		}
		if (SceneManager.GetActiveScene().name.Contains("NumPat")) {
			indexkey = 0;
			indexkey1 = 4;
		}
	}

	void Answerer () {
		ListAns = new List<List<int>>();
		ListAns1 = new List<List<int>>();
		if (SceneManager.GetActiveScene().name.Contains ("Tutorial")) {
			ListAns.Add (new List<int> {3,1,2});
			Answers = ListAns[Random.Range(0,ListAns.Count)];
		}
		if (SceneManager.GetActiveScene().name.Contains ("Easy")) {
			ListAns.Add (new List<int> {3,1,2});
			ListAns.Add (new List<int> {2,3,1});
			Answers = ListAns[Random.Range(0,ListAns.Count)];
		}
		if (SceneManager.GetActiveScene().name.Contains ("Med")) {
			ListAns.Add (new List<int> {2,3,4,1});
			ListAns.Add (new List<int> {2,4,1,3});
			ListAns.Add (new List<int> {2,1,4,3});
			ListAns.Add (new List<int> {3,4,1,2});
			ListAns.Add (new List<int> {3,4,2,1});
			ListAns.Add (new List<int> {3,1,4,2});
			ListAns.Add (new List<int> {4,3,1,2});
			ListAns.Add (new List<int> {4,1,2,3});
			ListAns.Add (new List<int> {4,3,2,1});			
			Answers = ListAns[Random.Range(0,ListAns.Count)];
		}
		if (SceneManager.GetActiveScene().name.Contains ("Hard")) {
			ListAns.Add (new List<int> {2,3,4,5,1});
			ListAns.Add (new List<int> {2,3,5,1,4});
			ListAns.Add (new List<int> {2,3,1,5,4});
			ListAns.Add (new List<int> {2,4,5,1,3});
			ListAns.Add (new List<int> {2,4,1,5,3});
			ListAns.Add (new List<int> {2,4,5,3,1});
			ListAns.Add (new List<int> {2,5,1,3,4});
			ListAns.Add (new List<int> {2,5,4,1,3});
			ListAns.Add (new List<int> {2,5,4,3,1});
			ListAns.Add (new List<int> {2,1,5,3,4});
			ListAns.Add (new List<int> {2,1,4,5,3});
			
			ListAns.Add (new List<int> {3,1,4,5,2});
			ListAns.Add (new List<int> {3,1,2,5,4});
			ListAns.Add (new List<int> {3,1,5,2,4});
			ListAns.Add (new List<int> {3,4,5,1,2});
			ListAns.Add (new List<int> {3,4,5,2,1});
			ListAns.Add (new List<int> {3,4,2,5,1});
			ListAns.Add (new List<int> {3,4,1,5,2});
			ListAns.Add (new List<int> {3,5,1,2,4});
			ListAns.Add (new List<int> {3,5,2,1,4});
			ListAns.Add (new List<int> {3,5,4,1,2});
			ListAns.Add (new List<int> {3,5,4,2,1});
			
			ListAns.Add (new List<int> {4,5,1,2,3});
			ListAns.Add (new List<int> {4,5,1,3,2});
			ListAns.Add (new List<int> {4,5,2,1,3});
			ListAns.Add (new List<int> {4,5,2,3,1});
			ListAns.Add (new List<int> {4,3,2,5,1});
			ListAns.Add (new List<int> {4,3,5,2,1});
			ListAns.Add (new List<int> {4,3,1,5,2});
			ListAns.Add (new List<int> {4,3,5,1,2});
			ListAns.Add (new List<int> {4,1,2,5,3});
			ListAns.Add (new List<int> {4,1,5,2,3});
			ListAns.Add (new List<int> {4,1,5,3,2});
			
			ListAns.Add (new List<int> {5,1,2,3,4});
			ListAns.Add (new List<int> {5,1,4,3,2});
			ListAns.Add (new List<int> {5,1,4,2,3});
			ListAns.Add (new List<int> {5,3,1,2,4});
			ListAns.Add (new List<int> {5,3,2,1,4});
			ListAns.Add (new List<int> {5,3,4,1,2});
			ListAns.Add (new List<int> {5,3,4,2,1});
			ListAns.Add (new List<int> {5,4,1,2,3});
			ListAns.Add (new List<int> {5,4,1,3,2});
			ListAns.Add (new List<int> {5,4,2,1,3});
			ListAns.Add (new List<int> {5,4,2,3,1});			
			Answers = ListAns[Random.Range(0,ListAns.Count)];
		}
		if (SceneManager.GetActiveScene().name.Contains ("Xprt")) {
			ListAns.Add (new List<int> {1,2,3});
			ListAns.Add (new List<int> {1,3,2});
			ListAns.Add (new List<int> {2,3,1});
			ListAns.Add (new List<int> {2,1,3});
			ListAns.Add (new List<int> {3,1,2});
			ListAns.Add (new List<int> {3,2,1});
			
			int q = Random.Range(0,ListAns.Count);
			Answers = ListAns[q];	
			ListAns.RemoveAt (q);
			Answers1=ListAns[Random.Range(0,ListAns.Count)];
		}
		if (SceneManager.GetActiveScene().name.Contains ("Insane")) {
			ListAns.Add (new List<int> {1,2,3,4,5});
			ListAns.Add (new List<int> {1,2,3,5,4});
			ListAns.Add (new List<int> {1,2,4,3,5});
			ListAns.Add (new List<int> {1,2,4,5,3});
			ListAns.Add (new List<int> {1,2,5,4,3});
			ListAns.Add (new List<int> {1,2,5,3,4});
			ListAns.Add (new List<int> {1,3,2,4,5});
			ListAns.Add (new List<int> {1,3,2,5,4});
			ListAns.Add (new List<int> {1,3,4,2,5});
			ListAns.Add (new List<int> {1,3,4,5,2});
			ListAns.Add (new List<int> {1,3,5,2,4});
			ListAns.Add (new List<int> {1,3,5,4,2});
			ListAns.Add (new List<int> {1,4,2,3,5});
			ListAns.Add (new List<int> {1,4,2,5,3});
			ListAns.Add (new List<int> {1,4,3,2,5});
			ListAns.Add (new List<int> {1,4,3,5,2});
			ListAns.Add (new List<int> {1,4,5,2,3});
			ListAns.Add (new List<int> {1,4,5,3,2});
			ListAns.Add (new List<int> {1,5,2,4,3});
			ListAns.Add (new List<int> {1,5,2,3,4});
			ListAns.Add (new List<int> {1,5,4,2,3});
			ListAns.Add (new List<int> {1,5,4,3,2});
			ListAns.Add (new List<int> {1,5,3,2,4});
			ListAns.Add (new List<int> {1,5,3,4,2});
			
			ListAns.Add (new List<int> {2,1,3,4,5});
			ListAns.Add (new List<int> {2,1,3,5,4});
			ListAns.Add (new List<int> {2,1,4,3,5});
			ListAns.Add (new List<int> {2,1,4,5,3});
			ListAns.Add (new List<int> {2,1,5,4,3});
			ListAns.Add (new List<int> {2,1,5,3,4});
			ListAns.Add (new List<int> {2,3,1,4,5});
			ListAns.Add (new List<int> {2,3,1,5,4});
			ListAns.Add (new List<int> {2,3,4,1,5});
			ListAns.Add (new List<int> {2,3,4,5,1});
			ListAns.Add (new List<int> {2,3,5,1,4});
			ListAns.Add (new List<int> {2,3,5,4,1});
			ListAns.Add (new List<int> {2,4,1,3,5});
			ListAns.Add (new List<int> {2,4,1,5,3});
			ListAns.Add (new List<int> {2,4,3,1,5});
			ListAns.Add (new List<int> {2,4,3,5,1});
			ListAns.Add (new List<int> {2,4,5,1,3});
			ListAns.Add (new List<int> {2,4,5,3,1});
			ListAns.Add (new List<int> {2,5,1,4,3});
			ListAns.Add (new List<int> {2,5,1,3,4});
			ListAns.Add (new List<int> {2,5,4,1,3});
			ListAns.Add (new List<int> {2,5,4,3,1});
			ListAns.Add (new List<int> {2,5,3,1,4});
			ListAns.Add (new List<int> {2,5,3,4,1});
			
			ListAns.Add (new List<int> {3,2,1,4,5});
			ListAns.Add (new List<int> {3,2,1,5,4});
			ListAns.Add (new List<int> {3,2,4,1,5});
			ListAns.Add (new List<int> {3,2,4,5,1});
			ListAns.Add (new List<int> {3,2,5,4,1});
			ListAns.Add (new List<int> {3,2,5,1,4});
			ListAns.Add (new List<int> {3,1,2,4,5});
			ListAns.Add (new List<int> {3,1,2,5,4});
			ListAns.Add (new List<int> {3,1,4,2,5});
			ListAns.Add (new List<int> {3,1,4,5,2});
			ListAns.Add (new List<int> {3,1,5,2,4});
			ListAns.Add (new List<int> {3,1,5,4,2});
			ListAns.Add (new List<int> {3,4,2,1,5});
			ListAns.Add (new List<int> {3,4,2,5,1});
			ListAns.Add (new List<int> {3,4,1,2,5});
			ListAns.Add (new List<int> {3,4,1,5,2});
			ListAns.Add (new List<int> {3,4,5,2,1});
			ListAns.Add (new List<int> {3,4,5,1,2});
			ListAns.Add (new List<int> {3,5,2,4,1});
			ListAns.Add (new List<int> {3,5,2,1,4});
			ListAns.Add (new List<int> {3,5,4,2,1});
			ListAns.Add (new List<int> {3,5,4,1,2});
			ListAns.Add (new List<int> {3,5,1,2,4});
			ListAns.Add (new List<int> {3,5,1,4,2});
			
			ListAns.Add (new List<int> {4,2,3,1,5});
			ListAns.Add (new List<int> {4,2,3,5,1});
			ListAns.Add (new List<int> {4,2,1,3,5});
			ListAns.Add (new List<int> {4,2,1,5,3});
			ListAns.Add (new List<int> {4,2,5,1,3});
			ListAns.Add (new List<int> {4,2,5,3,1});
			ListAns.Add (new List<int> {4,3,2,1,5});
			ListAns.Add (new List<int> {4,3,2,5,1});
			ListAns.Add (new List<int> {4,3,1,2,5});
			ListAns.Add (new List<int> {4,3,1,5,2});
			ListAns.Add (new List<int> {4,3,5,2,1});
			ListAns.Add (new List<int> {4,3,5,1,2});
			ListAns.Add (new List<int> {4,1,2,3,5});
			ListAns.Add (new List<int> {4,1,2,5,3});
			ListAns.Add (new List<int> {4,1,3,2,5});
			ListAns.Add (new List<int> {4,1,3,5,2});
			ListAns.Add (new List<int> {4,1,5,2,3});
			ListAns.Add (new List<int> {4,1,5,3,2});
			ListAns.Add (new List<int> {4,5,2,1,3});
			ListAns.Add (new List<int> {4,5,2,3,1});
			ListAns.Add (new List<int> {4,5,1,2,3});
			ListAns.Add (new List<int> {4,5,1,3,2});
			ListAns.Add (new List<int> {4,5,3,2,1});
			ListAns.Add (new List<int> {4,5,3,1,2});
			
			ListAns.Add (new List<int> {5,2,3,4,1});
			ListAns.Add (new List<int> {5,2,3,1,4});
			ListAns.Add (new List<int> {5,2,4,3,1});
			ListAns.Add (new List<int> {5,2,4,1,3});
			ListAns.Add (new List<int> {5,2,1,4,3});
			ListAns.Add (new List<int> {5,2,1,3,4});
			ListAns.Add (new List<int> {5,3,2,4,1});
			ListAns.Add (new List<int> {5,3,2,1,4});
			ListAns.Add (new List<int> {5,3,4,2,1});
			ListAns.Add (new List<int> {5,3,4,1,2});
			ListAns.Add (new List<int> {5,3,1,2,4});
			ListAns.Add (new List<int> {5,3,1,4,2});
			ListAns.Add (new List<int> {5,4,2,3,1});
			ListAns.Add (new List<int> {5,4,2,1,3});
			ListAns.Add (new List<int> {5,4,3,2,1});
			ListAns.Add (new List<int> {5,4,3,1,2});
			ListAns.Add (new List<int> {5,4,1,2,3});
			ListAns.Add (new List<int> {5,4,1,3,2});
			ListAns.Add (new List<int> {5,1,2,4,3});
			ListAns.Add (new List<int> {5,1,2,3,4});
			ListAns.Add (new List<int> {5,1,4,2,3});
			ListAns.Add (new List<int> {5,1,4,3,2});
			ListAns.Add (new List<int> {5,1,3,2,4});
			ListAns.Add (new List<int> {5,1,3,4,2});
			
			if (GameObject.Find("EndureObject") == true) {
				ListAns1.Add (new List<int> {2,3,4});
				ListAns1.Add (new List<int> {2,3,1});
				ListAns1.Add (new List<int> {2,4,3});
				ListAns1.Add (new List<int> {2,4,1});
				ListAns1.Add (new List<int> {2,1,4});
				ListAns1.Add (new List<int> {2,1,3});
				ListAns1.Add (new List<int> {3,2,4});
				ListAns1.Add (new List<int> {3,2,1});
				ListAns1.Add (new List<int> {3,4,2});
				ListAns1.Add (new List<int> {3,4,1});
				ListAns1.Add (new List<int> {3,1,2});
				ListAns1.Add (new List<int> {3,1,4});
				ListAns1.Add (new List<int> {4,2,3});
				ListAns1.Add (new List<int> {4,2,1});
				ListAns1.Add (new List<int> {4,3,2});
				ListAns1.Add (new List<int> {4,3,1});
				ListAns1.Add (new List<int> {4,1,2});
				ListAns1.Add (new List<int> {4,1,3});
				ListAns1.Add (new List<int> {1,2,4});
				ListAns1.Add (new List<int> {1,2,3});
				ListAns1.Add (new List<int> {1,4,2});
				ListAns1.Add (new List<int> {1,4,3});
				ListAns1.Add (new List<int> {1,3,2});
				ListAns1.Add (new List<int> {1,3,4});
				
				q = Random.Range(0,ListAns1.Count);
				Answers2 = ListAns1[q];
				
				indexkey = (Answers2[0]-1);
				indexkey1 = (Answers2[1]-1);
			} else {
			
				ListAns1.Add (new List<int> {2,3,1});
				ListAns1.Add (new List<int> {2,4,1});
				ListAns1.Add (new List<int> {1,4,2});
				ListAns1.Add (new List<int> {3,4,2});
				ListAns1.Add (new List<int> {1,2,3});
				ListAns1.Add (new List<int> {1,4,3});
				ListAns1.Add (new List<int> {1,3,4});
				ListAns1.Add (new List<int> {2,3,4});
				
//				Answers2 = ListAns1[ScoreCard.NumberGame];
				Answers2 = ListAns1[PlayerPrefs.GetInt("NumberGame",0)];
				
				indexkey = (Answers2[0]-1);
				indexkey1 = (Answers2[1]-1);
			}		
			
			q = Random.Range(0,ListAns.Count);
			Answers = ListAns[q];	
			ListAns.RemoveAt (q);
			
			q = Random.Range(0,ListAns.Count);
			Answers1 = ListAns[q];
			ListAns.RemoveAt (q);
		}
	}

	public void MusicAnswers () {
		Indexer ();
		PlayerPrefs.SetInt("indexkey",indexkey);
	}

	public void EasyAnswers () {
		Indexer ();
		Answerer ();
		PlayerPrefs.SetInt("indexkey",indexkey);
		PlayerPrefs.SetInt("Answers00",Answers[0]);
		PlayerPrefs.SetInt("Answers01",Answers[1]);
		PlayerPrefs.SetInt("Answers02",Answers[2]);
	}

	public void MediumAnswers () {
		Indexer ();
		Answerer ();
		PlayerPrefs.SetInt("indexkey",indexkey);
		PlayerPrefs.SetInt("Answers00",Answers[0]);
		PlayerPrefs.SetInt("Answers01",Answers[1]);
		PlayerPrefs.SetInt("Answers02",Answers[2]);
		PlayerPrefs.SetInt("Answers03",Answers[3]);
	}

	public void HardAnswers () {
		Indexer ();
		Answerer ();
		PlayerPrefs.SetInt("indexkey",indexkey);
		PlayerPrefs.SetInt("Answers00",Answers[0]);
		PlayerPrefs.SetInt("Answers01",Answers[1]);
		PlayerPrefs.SetInt("Answers02",Answers[2]);
		PlayerPrefs.SetInt("Answers03",Answers[3]);
		PlayerPrefs.SetInt("Answers04",Answers[4]);
	}

	public void XprtAnswers () {
		Indexer ();
		Answerer ();
		PlayerPrefs.SetInt("indexkey",indexkey);
		PlayerPrefs.SetInt("indexkey1",indexkey1);
		PlayerPrefs.SetInt("Answers00",Answers[0]);
		PlayerPrefs.SetInt("Answers01",Answers[1]);
		PlayerPrefs.SetInt("Answers02",Answers[2]);
		PlayerPrefs.SetInt("Answers10",Answers1[0]);
		PlayerPrefs.SetInt("Answers11",Answers1[1]);
		PlayerPrefs.SetInt("Answers12",Answers1[2]);
	}

	public void InsaneAnswers () {
		Answerer ();
		PlayerPrefs.SetInt("indexkey",indexkey);
		PlayerPrefs.SetInt("indexkey1",indexkey1);
		PlayerPrefs.SetInt("Answers00",Answers[0]);
		PlayerPrefs.SetInt("Answers01",Answers[1]);
		PlayerPrefs.SetInt("Answers02",Answers[2]);
		PlayerPrefs.SetInt("Answers03",Answers[3]);
		PlayerPrefs.SetInt("Answers04",Answers[4]);
		PlayerPrefs.SetInt("Answers10",Answers1[0]);
		PlayerPrefs.SetInt("Answers11",Answers1[1]);
		PlayerPrefs.SetInt("Answers12",Answers1[2]);
		PlayerPrefs.SetInt("Answers13",Answers1[3]);
		PlayerPrefs.SetInt("Answers14",Answers1[4]);
		PlayerPrefs.SetInt("Answers20",Answers2[0]);
		PlayerPrefs.SetInt("Answers21",Answers2[1]);
		PlayerPrefs.SetInt("Answers22",Answers2[2]);
	}
}