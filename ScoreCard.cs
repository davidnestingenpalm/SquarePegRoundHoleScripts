using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScoreCard : MonoBehaviour {

//	public static int PerfectGame;
//	public static int TotalScore;
//	public static int NumberGame;	
	private int PerfectGame;
	private int TotalScore;
	private int NumberGame;
	private int Score;
	
	public void ScoreKeeper () {
		if (SceneManager.GetActiveScene().name.Contains("Easy")) {
			Score = GameObject.Find("Pegs").GetComponent<Easy>().LevelScore;
		}
		if (SceneManager.GetActiveScene().name.Contains("Med")) {
			Score = GameObject.Find("Pegs").GetComponent<Medium>().LevelScore;
		}
		if (SceneManager.GetActiveScene().name.Contains("Hard")) {
			Score = GameObject.Find("Pegs").GetComponent<Hard>().LevelScore;
		}
		if (SceneManager.GetActiveScene().name.Contains("Xprt")) {
			Score = GameObject.Find("Pegs").GetComponent<Xprt>().LevelScore;
		}
		if (SceneManager.GetActiveScene().name.Contains("Insane")) {
			Score = GameObject.Find("Pegs").GetComponent<Insane>().LevelScore;
		}
		TotalScore = PlayerPrefs.GetInt("TotalScore",0);
		TotalScore = TotalScore + Score;
		PlayerPrefs.SetInt("TotalScore",TotalScore);
	}
	
	public void NumberGameKeeper () {
		NumberGame = PlayerPrefs.GetInt("NumberGame",0);
		NumberGame++;
		PlayerPrefs.SetInt("NumberGame",NumberGame);
	}
	
	public void PerfectGameKeeper () {
		PerfectGame = PlayerPrefs.GetInt("PerfectGame",0);
		PerfectGame++;
		PlayerPrefs.SetInt("PerfectGame",PerfectGame);
	}
	
	public void EraseScores () {
//		TotalScore = 0;
//		PerfectGame = 0;
//		NumberGame = 0;
		PlayerPrefs.SetInt("TotalScore",0);
		PlayerPrefs.SetInt("PerfectGame",0);
		PlayerPrefs.SetInt("NumberGame",0);
	}
}