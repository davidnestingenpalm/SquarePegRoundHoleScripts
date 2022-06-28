using UnityEngine;
using System.Collections.Generic;

public class Reseter : MonoBehaviour {

	private LevelManager levelmanager;
	public GameObject easyresetblock;
	public GameObject mediumresetblock;
	public GameObject hardresetblock;
	public GameObject expertresetblock;
	public GameObject insaneresetblock;
	public GameObject gameresetblock;

	public void EasyReset () {
		GameObject Easyblock = (GameObject) Instantiate (easyresetblock,new Vector2(this.transform.position.x,this.transform.position.y), Quaternion.identity);
		GameObject.DontDestroyOnLoad(Easyblock);
		levelmanager = GameObject.FindObjectOfType <LevelManager>();
		levelmanager.LoadLevel("Reset Confirm");
	}
	
	public void MediumReset () {
		GameObject Medblock = (GameObject) Instantiate (mediumresetblock,new Vector2(this.transform.position.x,this.transform.position.y), Quaternion.identity);
		GameObject.DontDestroyOnLoad(Medblock);
		levelmanager = GameObject.FindObjectOfType <LevelManager>();
		levelmanager.LoadLevel("Reset Confirm");
	}
	
	public void HardReset () {
		GameObject Hardblock = (GameObject) Instantiate (hardresetblock,new Vector2(this.transform.position.x,this.transform.position.y), Quaternion.identity);
		GameObject.DontDestroyOnLoad(Hardblock);
		levelmanager = GameObject.FindObjectOfType <LevelManager>();
		levelmanager.LoadLevel("Reset Confirm");
	}
	
	public void ExpertReset () {
		GameObject Expertblock = (GameObject) Instantiate (expertresetblock,new Vector2(this.transform.position.x,this.transform.position.y), Quaternion.identity);
		GameObject.DontDestroyOnLoad(Expertblock);
		levelmanager = GameObject.FindObjectOfType <LevelManager>();
		levelmanager.LoadLevel("Reset Confirm");
	}
	
	public void InsaneReset () {
		GameObject Insaneblock = (GameObject) Instantiate (insaneresetblock,new Vector2(this.transform.position.x,this.transform.position.y), Quaternion.identity);
		GameObject.DontDestroyOnLoad(Insaneblock);
		levelmanager = GameObject.FindObjectOfType <LevelManager>();
		levelmanager.LoadLevel("Reset Confirm");
	}
	
	public void GameReset () {
		GameObject Gameblock = (GameObject) Instantiate (gameresetblock,new Vector2(this.transform.position.x,this.transform.position.y), Quaternion.identity);
		GameObject.DontDestroyOnLoad(Gameblock);
		levelmanager = GameObject.FindObjectOfType <LevelManager>();
		levelmanager.LoadLevel("Reset Confirm");
	}
	
	public void ResetScore () {
		GameObject Reseting = GameObject.FindGameObjectWithTag ("Reset"); 
		if (Reseting.name.Contains ("easy")) {
			PlayerPrefs.SetFloat("highscoreEasy1", 0);
			PlayerPrefs.SetFloat("highscoreEasy2", 0);
			PlayerPrefs.SetFloat("highscoreEasy3", 0);
			PlayerPrefs.SetFloat("highscoreEasy4", 0);
			PlayerPrefs.SetFloat("highscoreEasy5", 0);
			PlayerPrefs.SetFloat("highscoreEndureEasy1", 0);
			PlayerPrefs.SetFloat("highscoreEndureEasy2", 0);
			PlayerPrefs.SetFloat("highscoreEndureEasy3", 0);
			PlayerPrefs.SetFloat("highscoreEndureEasy4", 0);
			PlayerPrefs.SetFloat("highscoreEndureEasy5", 0);
			PlayerPrefs.SetFloat("highscorePerfectEasy1", 0);
			PlayerPrefs.SetFloat("highscorePerfectEasy2", 0);
			PlayerPrefs.SetFloat("highscorePerfectEasy3", 0);
			PlayerPrefs.SetFloat("highscorePerfectEasy4", 0);
			PlayerPrefs.SetFloat("highscorePerfectEasy5", 0);
			PlayerPrefs.SetFloat("highscoreGamesEasy1", 0);
			PlayerPrefs.SetFloat("highscoreGamesEasy2", 0);
			PlayerPrefs.SetFloat("highscoreGamesEasy3", 0);
			PlayerPrefs.SetFloat("highscoreGamesEasy4", 0);
			PlayerPrefs.SetFloat("highscoreGamesEasy5", 0);
		}
		
		if (Reseting.name.Contains ("medium")) {
			PlayerPrefs.SetFloat("highscoreMed1", 0);
			PlayerPrefs.SetFloat("highscoreMed2", 0);
			PlayerPrefs.SetFloat("highscoreMed3", 0);
			PlayerPrefs.SetFloat("highscoreMed4", 0);
			PlayerPrefs.SetFloat("highscoreMed5", 0);
			PlayerPrefs.SetFloat("highscoreEndureMed1", 0);
			PlayerPrefs.SetFloat("highscoreEndureMed2", 0);
			PlayerPrefs.SetFloat("highscoreEndureMed3", 0);
			PlayerPrefs.SetFloat("highscoreEndureMed4", 0);
			PlayerPrefs.SetFloat("highscoreEndureMed5", 0);
			PlayerPrefs.SetFloat("highscorePerfectMed1", 0);
			PlayerPrefs.SetFloat("highscorePerfectMed2", 0);
			PlayerPrefs.SetFloat("highscorePerfectMed3", 0);
			PlayerPrefs.SetFloat("highscorePerfectMed4", 0);
			PlayerPrefs.SetFloat("highscorePerfectMed5", 0);
			PlayerPrefs.SetFloat("highscoreGamesMed1", 0);
			PlayerPrefs.SetFloat("highscoreGamesMed2", 0);
			PlayerPrefs.SetFloat("highscoreGamesMed3", 0);
			PlayerPrefs.SetFloat("highscoreGamesMed4", 0);
			PlayerPrefs.SetFloat("highscoreGamesMed5", 0);
		}
		
		if (Reseting.name.Contains ("hard")) {
			PlayerPrefs.SetFloat("highscoreHard1", 0);
			PlayerPrefs.SetFloat("highscoreHard2", 0);
			PlayerPrefs.SetFloat("highscoreHard3", 0);
			PlayerPrefs.SetFloat("highscoreHard4", 0);
			PlayerPrefs.SetFloat("highscoreHard5", 0);
			PlayerPrefs.SetFloat("highscoreEndureHard1", 0);
			PlayerPrefs.SetFloat("highscoreEndureHard2", 0);
			PlayerPrefs.SetFloat("highscoreEndureHard3", 0);
			PlayerPrefs.SetFloat("highscoreEndureHard4", 0);
			PlayerPrefs.SetFloat("highscoreEndureHard5", 0);
			PlayerPrefs.SetFloat("highscorePerfectHard1", 0);
			PlayerPrefs.SetFloat("highscorePerfectHard2", 0);
			PlayerPrefs.SetFloat("highscorePerfectHard3", 0);
			PlayerPrefs.SetFloat("highscorePerfectHard4", 0);
			PlayerPrefs.SetFloat("highscorePerfectHard5", 0);
			PlayerPrefs.SetFloat("highscoreGamesHard1", 0);
			PlayerPrefs.SetFloat("highscoreGamesHard2", 0);
			PlayerPrefs.SetFloat("highscoreGamesHard3", 0);
			PlayerPrefs.SetFloat("highscoreGamesHard4", 0);
			PlayerPrefs.SetFloat("highscoreGamesHard5", 0);
		}
		
		if (Reseting.name.Contains ("expert")) {
			PlayerPrefs.SetFloat("highscoreXprt1", 0);
			PlayerPrefs.SetFloat("highscoreXprt2", 0);
			PlayerPrefs.SetFloat("highscoreXprt3", 0);
			PlayerPrefs.SetFloat("highscoreXprt4", 0);
			PlayerPrefs.SetFloat("highscoreXprt5", 0);
			PlayerPrefs.SetFloat("highscoreEndureXprt1", 0);
			PlayerPrefs.SetFloat("highscoreEndureXprt2", 0);
			PlayerPrefs.SetFloat("highscoreEndureXprt3", 0);
			PlayerPrefs.SetFloat("highscoreEndureXprt4", 0);
			PlayerPrefs.SetFloat("highscoreEndureXprt5", 0);
			PlayerPrefs.SetFloat("highscorePerfectXprt1", 0);
			PlayerPrefs.SetFloat("highscorePerfectXprt2", 0);
			PlayerPrefs.SetFloat("highscorePerfectXprt3", 0);
			PlayerPrefs.SetFloat("highscorePerfectXprt4", 0);
			PlayerPrefs.SetFloat("highscorePerfectXprt5", 0);
			PlayerPrefs.SetFloat("highscoreGamesXprt1", 0);
			PlayerPrefs.SetFloat("highscoreGamesXprt2", 0);
			PlayerPrefs.SetFloat("highscoreGamesXprt3", 0);
			PlayerPrefs.SetFloat("highscoreGamesXprt4", 0);
			PlayerPrefs.SetFloat("highscoreGamesXprt5", 0);
		}
		
		if (Reseting.name.Contains ("insane")) {	
			PlayerPrefs.SetFloat("highscoreInsane1", 0);
			PlayerPrefs.SetFloat("highscoreInsane2", 0);
			PlayerPrefs.SetFloat("highscoreInsane3", 0);
			PlayerPrefs.SetFloat("highscoreInsane4", 0);
			PlayerPrefs.SetFloat("highscoreInsane5", 0);
			PlayerPrefs.SetFloat("highscoreEndureInsane1", 0);
			PlayerPrefs.SetFloat("highscoreEndureInsane2", 0);
			PlayerPrefs.SetFloat("highscoreEndureInsane3", 0);
			PlayerPrefs.SetFloat("highscoreEndureInsane4", 0);
			PlayerPrefs.SetFloat("highscoreEndureInsane5", 0);
			PlayerPrefs.SetFloat("highscorePerfectInsane1", 0);
			PlayerPrefs.SetFloat("highscorePerfectInsane2", 0);
			PlayerPrefs.SetFloat("highscorePerfectInsane3", 0);
			PlayerPrefs.SetFloat("highscorePerfectInsane4", 0);
			PlayerPrefs.SetFloat("highscorePerfectInsane5", 0);
			PlayerPrefs.SetFloat("highscoreGamesInsane1", 0);
			PlayerPrefs.SetFloat("highscoreGamesInsane2", 0);
			PlayerPrefs.SetFloat("highscoreGamesInsane3", 0);
			PlayerPrefs.SetFloat("highscoreGamesInsane4", 0);
			PlayerPrefs.SetFloat("highscoreGamesInsane5", 0);
		}
		
		if (Reseting.name.Contains ("game")) {
			PlayerPrefs.SetFloat("highscoreEasy1", 0);
			PlayerPrefs.SetFloat("highscoreEasy2", 0);
			PlayerPrefs.SetFloat("highscoreEasy3", 0);
			PlayerPrefs.SetFloat("highscoreEasy4", 0);
			PlayerPrefs.SetFloat("highscoreEasy5", 0);
			PlayerPrefs.SetFloat("highscoreEndureEasy1", 0);
			PlayerPrefs.SetFloat("highscoreEndureEasy2", 0);
			PlayerPrefs.SetFloat("highscoreEndureEasy3", 0);
			PlayerPrefs.SetFloat("highscoreEndureEasy4", 0);
			PlayerPrefs.SetFloat("highscoreEndureEasy5", 0);
			PlayerPrefs.SetFloat("highscorePerfectEasy1", 0);
			PlayerPrefs.SetFloat("highscorePerfectEasy2", 0);
			PlayerPrefs.SetFloat("highscorePerfectEasy3", 0);
			PlayerPrefs.SetFloat("highscorePerfectEasy4", 0);
			PlayerPrefs.SetFloat("highscorePerfectEasy5", 0);
			PlayerPrefs.SetFloat("highscoreGamesEasy1", 0);
			PlayerPrefs.SetFloat("highscoreGamesEasy2", 0);
			PlayerPrefs.SetFloat("highscoreGamesEasy3", 0);
			PlayerPrefs.SetFloat("highscoreGamesEasy4", 0);
			PlayerPrefs.SetFloat("highscoreGamesEasy5", 0);

			PlayerPrefs.SetFloat("highscoreMed1", 0);
			PlayerPrefs.SetFloat("highscoreMed2", 0);
			PlayerPrefs.SetFloat("highscoreMed3", 0);
			PlayerPrefs.SetFloat("highscoreMed4", 0);
			PlayerPrefs.SetFloat("highscoreMed5", 0);
			PlayerPrefs.SetFloat("highscoreEndureMed1", 0);
			PlayerPrefs.SetFloat("highscoreEndureMed2", 0);
			PlayerPrefs.SetFloat("highscoreEndureMed3", 0);
			PlayerPrefs.SetFloat("highscoreEndureMed4", 0);
			PlayerPrefs.SetFloat("highscoreEndureMed5", 0);
			PlayerPrefs.SetFloat("highscorePerfectMed1", 0);
			PlayerPrefs.SetFloat("highscorePerfectMed2", 0);
			PlayerPrefs.SetFloat("highscorePerfectMed3", 0);
			PlayerPrefs.SetFloat("highscorePerfectMed4", 0);
			PlayerPrefs.SetFloat("highscorePerfectMed5", 0);
			PlayerPrefs.SetFloat("highscoreGamesMed1", 0);
			PlayerPrefs.SetFloat("highscoreGamesMed2", 0);
			PlayerPrefs.SetFloat("highscoreGamesMed3", 0);
			PlayerPrefs.SetFloat("highscoreGamesMed4", 0);
			PlayerPrefs.SetFloat("highscoreGamesMed5", 0);

			PlayerPrefs.SetFloat("highscoreHard1", 0);
			PlayerPrefs.SetFloat("highscoreHard2", 0);
			PlayerPrefs.SetFloat("highscoreHard3", 0);
			PlayerPrefs.SetFloat("highscoreHard4", 0);
			PlayerPrefs.SetFloat("highscoreHard5", 0);
			PlayerPrefs.SetFloat("highscoreEndureHard1", 0);
			PlayerPrefs.SetFloat("highscoreEndureHard2", 0);
			PlayerPrefs.SetFloat("highscoreEndureHard3", 0);
			PlayerPrefs.SetFloat("highscoreEndureHard4", 0);
			PlayerPrefs.SetFloat("highscoreEndureHard5", 0);
			PlayerPrefs.SetFloat("highscorePerfectHard1", 0);
			PlayerPrefs.SetFloat("highscorePerfectHard2", 0);
			PlayerPrefs.SetFloat("highscorePerfectHard3", 0);
			PlayerPrefs.SetFloat("highscorePerfectHard4", 0);
			PlayerPrefs.SetFloat("highscorePerfectHard5", 0);
			PlayerPrefs.SetFloat("highscoreGamesHard1", 0);
			PlayerPrefs.SetFloat("highscoreGamesHard2", 0);
			PlayerPrefs.SetFloat("highscoreGamesHard3", 0);
			PlayerPrefs.SetFloat("highscoreGamesHard4", 0);
			PlayerPrefs.SetFloat("highscoreGamesHard5", 0);

			PlayerPrefs.SetFloat("highscoreXprt1", 0);
			PlayerPrefs.SetFloat("highscoreXprt2", 0);
			PlayerPrefs.SetFloat("highscoreXprt3", 0);
			PlayerPrefs.SetFloat("highscoreXprt4", 0);
			PlayerPrefs.SetFloat("highscoreXprt5", 0);
			PlayerPrefs.SetFloat("highscoreEndureXprt1", 0);
			PlayerPrefs.SetFloat("highscoreEndureXprt2", 0);
			PlayerPrefs.SetFloat("highscoreEndureXprt3", 0);
			PlayerPrefs.SetFloat("highscoreEndureXprt4", 0);
			PlayerPrefs.SetFloat("highscoreEndureXprt5", 0);
			PlayerPrefs.SetFloat("highscorePerfectXprt1", 0);
			PlayerPrefs.SetFloat("highscorePerfectXprt2", 0);
			PlayerPrefs.SetFloat("highscorePerfectXprt3", 0);
			PlayerPrefs.SetFloat("highscorePerfectXprt4", 0);
			PlayerPrefs.SetFloat("highscorePerfectXprt5", 0);
			PlayerPrefs.SetFloat("highscoreGamesXprt1", 0);
			PlayerPrefs.SetFloat("highscoreGamesXprt2", 0);
			PlayerPrefs.SetFloat("highscoreGamesXprt3", 0);
			PlayerPrefs.SetFloat("highscoreGamesXprt4", 0);
			PlayerPrefs.SetFloat("highscoreGamesXprt5", 0);

			PlayerPrefs.SetFloat("highscoreInsane1", 0);
			PlayerPrefs.SetFloat("highscoreInsane2", 0);
			PlayerPrefs.SetFloat("highscoreInsane3", 0);
			PlayerPrefs.SetFloat("highscoreInsane4", 0);
			PlayerPrefs.SetFloat("highscoreInsane5", 0);
			PlayerPrefs.SetFloat("highscoreEndureInsane1", 0);
			PlayerPrefs.SetFloat("highscoreEndureInsane2", 0);
			PlayerPrefs.SetFloat("highscoreEndureInsane3", 0);
			PlayerPrefs.SetFloat("highscoreEndureInsane4", 0);
			PlayerPrefs.SetFloat("highscoreEndureInsane5", 0);
			PlayerPrefs.SetFloat("highscorePerfectInsane1", 0);
			PlayerPrefs.SetFloat("highscorePerfectInsane2", 0);
			PlayerPrefs.SetFloat("highscorePerfectInsane3", 0);
			PlayerPrefs.SetFloat("highscorePerfectInsane4", 0);
			PlayerPrefs.SetFloat("highscorePerfectInsane5", 0);
			PlayerPrefs.SetFloat("highscoreGamesInsane1", 0);
			PlayerPrefs.SetFloat("highscoreGamesInsane2", 0);
			PlayerPrefs.SetFloat("highscoreGamesInsane3", 0);
			PlayerPrefs.SetFloat("highscoreGamesInsane4", 0);
			PlayerPrefs.SetFloat("highscoreGamesInsane5", 0);
			
			PlayerPrefs.SetFloat("MedLevelAllow1", 0);
			PlayerPrefs.SetFloat("HardLevelAllow1", 0);
			PlayerPrefs.SetFloat("ExpertLevelAllow1", 0);
			PlayerPrefs.SetFloat("MedLevelAllow2", 0);
			PlayerPrefs.SetFloat("HardLevelAllow2", 0);
			PlayerPrefs.SetFloat("ExpertLevelAllow2", 0);
			PlayerPrefs.SetFloat("InsaneLevelAllow", 0);
		}	
		levelmanager = GameObject.FindObjectOfType <LevelManager>();
		levelmanager.LoadLevel("Reset Done");
	}
}