using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {
	private WinLoseScript Finalscore;
	private float finalscore;
	private int perfectgames;
	private int numbergames;
	
	private float oldHighscore1;
	private float oldHighscore2;
	private float oldHighscore3;
	private float oldHighscore4;
	private float oldHighscore5;
	private float oldGamesscore1;
	private float oldGamesscore2;
	private float oldGamesscore3;
	private float oldGamesscore4;
	private float oldGamesscore5;	
	private float oldPerfectscore1;
	private float oldPerfectscore2;
	private float oldPerfectscore3;
	private float oldPerfectscore4;
	private float oldPerfectscore5;

	public void StoreHighscore() {
//		finalscore = GameObject.Find("Canvas").GetComponent<WinLoseScript>().Finalscore;
//		perfectgames = GameObject.Find("Canvas").GetComponent<WinLoseScript>().perfectGame;
//		numbergames = GameObject.Find("Canvas").GetComponent<WinLoseScript>().numberGame;
		finalscore = PlayerPrefs.GetFloat("FinalScore",0f);
		perfectgames = PlayerPrefs.GetInt("PerfectGame",0);
		numbergames = PlayerPrefs.GetInt("NumberGame",0);
		
		if (SceneManager.GetActiveScene().name.Contains("Easy")) {
			if (GameObject.Find("EndureObject") == false) {

				float highscoreEasy = finalscore;
				Social.ReportScore((long)highscoreEasy,SPRHresources.leaderboard_easy_leaders,(bool success) => {});

				oldHighscore1 = PlayerPrefs.GetFloat("highscoreEasy1", 0);
				oldHighscore2 = PlayerPrefs.GetFloat("highscoreEasy2", 0);
				oldHighscore3 = PlayerPrefs.GetFloat("highscoreEasy3", 0);
				oldHighscore4 = PlayerPrefs.GetFloat("highscoreEasy4", 0);
				oldHighscore5 = PlayerPrefs.GetFloat("highscoreEasy5", 0);

				if (finalscore >= oldHighscore1) {
					PlayerPrefs.SetFloat("highscoreEasy1", finalscore);
					PlayerPrefs.SetFloat("highscoreEasy2", oldHighscore1);
					PlayerPrefs.SetFloat("highscoreEasy3", oldHighscore2);
					PlayerPrefs.SetFloat("highscoreEasy4", oldHighscore3);
					PlayerPrefs.SetFloat("highscoreEasy5", oldHighscore4);
					PlayerPrefs.Save ();
				}
				if (finalscore >= oldHighscore2 && finalscore < oldHighscore1) {
					PlayerPrefs.SetFloat("highscoreEasy2", finalscore);
					PlayerPrefs.SetFloat("highscoreEasy3", oldHighscore2);
					PlayerPrefs.SetFloat("highscoreEasy4", oldHighscore3);
					PlayerPrefs.SetFloat("highscoreEasy5", oldHighscore4);
					PlayerPrefs.Save ();
				}
				if (finalscore >= oldHighscore3 && finalscore < oldHighscore2) {
					PlayerPrefs.SetFloat("highscoreEasy3", finalscore);
					PlayerPrefs.SetFloat("highscoreEasy4", oldHighscore3);
					PlayerPrefs.SetFloat("highscoreEasy5", oldHighscore4);
					PlayerPrefs.Save ();
				}
				if (finalscore >= oldHighscore4 && finalscore < oldHighscore3) {
					PlayerPrefs.SetFloat("highscoreEasy4", finalscore);
					PlayerPrefs.SetFloat("highscoreEasy5", oldHighscore4);
					PlayerPrefs.Save ();
				}
				if (finalscore >= oldHighscore5 && finalscore < oldHighscore4) {
					PlayerPrefs.SetFloat("highscoreEasy5", finalscore);
					PlayerPrefs.Save ();
				}
			} else {
				oldHighscore1 = PlayerPrefs.GetFloat("highscoreEndureEasy1", 0);
				oldHighscore2 = PlayerPrefs.GetFloat("highscoreEndureEasy2", 0);
				oldHighscore3 = PlayerPrefs.GetFloat("highscoreEndureEasy3", 0);
				oldHighscore4 = PlayerPrefs.GetFloat("highscoreEndureEasy4", 0);
				oldHighscore5 = PlayerPrefs.GetFloat("highscoreEndureEasy5", 0);
			
				oldPerfectscore1 = PlayerPrefs.GetFloat("highscorePerfectEasy1", 0);
				oldPerfectscore2 = PlayerPrefs.GetFloat("highscorePerfectEasy2", 0);
				oldPerfectscore3 = PlayerPrefs.GetFloat("highscorePerfectEasy3", 0);
				oldPerfectscore4 = PlayerPrefs.GetFloat("highscorePerfectEasy4", 0);
				oldPerfectscore5 = PlayerPrefs.GetFloat("highscorePerfectEasy5", 0);
				
				oldGamesscore1 = PlayerPrefs.GetFloat("highscoreGamesEasy1", 0);
				oldGamesscore2 = PlayerPrefs.GetFloat("highscoreGamesEasy2", 0);
				oldGamesscore3 = PlayerPrefs.GetFloat("highscoreGamesEasy3", 0);
				oldGamesscore4 = PlayerPrefs.GetFloat("highscoreGamesEasy4", 0);
				oldGamesscore5 = PlayerPrefs.GetFloat("highscoreGamesEasy5", 0);
			
				if (finalscore >= oldHighscore1) {
					PlayerPrefs.SetFloat("highscoreEndureEasy1", finalscore);
					PlayerPrefs.SetFloat("highscoreEndureEasy2", oldHighscore1);
					PlayerPrefs.SetFloat("highscoreEndureEasy3", oldHighscore2);
					PlayerPrefs.SetFloat("highscoreEndureEasy4", oldHighscore3);
					PlayerPrefs.SetFloat("highscoreEndureEasy5", oldHighscore4);
					PlayerPrefs.SetFloat("highscorePerfectEasy1", perfectgames);
					PlayerPrefs.SetFloat("highscorePerfectEasy2", oldPerfectscore1);
					PlayerPrefs.SetFloat("highscorePerfectEasy3", oldPerfectscore2);
					PlayerPrefs.SetFloat("highscorePerfectEasy4", oldPerfectscore3);
					PlayerPrefs.SetFloat("highscorePerfectEasy5", oldPerfectscore4);
					PlayerPrefs.SetFloat("highscoreGamesEasy1", numbergames);
					PlayerPrefs.SetFloat("highscoreGamesEasy2", oldGamesscore1);
					PlayerPrefs.SetFloat("highscoreGamesEasy3", oldGamesscore2);
					PlayerPrefs.SetFloat("highscoreGamesEasy4", oldGamesscore3);
					PlayerPrefs.SetFloat("highscoreGamesEasy5", oldGamesscore4);
					PlayerPrefs.Save ();
				}				
				if (finalscore >= oldHighscore2 && finalscore < oldHighscore1) {
					PlayerPrefs.SetFloat("highscoreEndureEasy2", finalscore);
					PlayerPrefs.SetFloat("highscoreEndureEasy3", oldHighscore2);
					PlayerPrefs.SetFloat("highscoreEndureEasy4", oldHighscore3);
					PlayerPrefs.SetFloat("highscoreEndureEasy5", oldHighscore4);
					PlayerPrefs.SetFloat("highscorePerfectEasy2", perfectgames);
					PlayerPrefs.SetFloat("highscorePerfectEasy3", oldPerfectscore2);
					PlayerPrefs.SetFloat("highscorePerfectEasy4", oldPerfectscore3);
					PlayerPrefs.SetFloat("highscorePerfectEasy5", oldPerfectscore4);
					PlayerPrefs.SetFloat("highscoreGamesEasy2", numbergames);
					PlayerPrefs.SetFloat("highscoreGamesEasy3", oldGamesscore2);
					PlayerPrefs.SetFloat("highscoreGamesEasy4", oldGamesscore3);
					PlayerPrefs.SetFloat("highscoreGamesEasy5", oldGamesscore4);
					PlayerPrefs.Save ();
				}				
				if (finalscore >= oldHighscore3 && finalscore < oldHighscore2) {
					PlayerPrefs.SetFloat("highscoreEndureEasy3", finalscore);
					PlayerPrefs.SetFloat("highscoreEndureEasy4", oldHighscore3);
					PlayerPrefs.SetFloat("highscoreEndureEasy5", oldHighscore4);
					PlayerPrefs.SetFloat("highscorePerfectEasy3", perfectgames);
					PlayerPrefs.SetFloat("highscorePerfectEasy4", oldPerfectscore3);
					PlayerPrefs.SetFloat("highscorePerfectEasy5", oldPerfectscore4);
					PlayerPrefs.SetFloat("highscoreGamesEasy3", numbergames);
					PlayerPrefs.SetFloat("highscoreGamesEasy4", oldGamesscore3);
					PlayerPrefs.SetFloat("highscoreGamesEasy5", oldGamesscore4);
					PlayerPrefs.Save ();
				}				
				if (finalscore >= oldHighscore4 && finalscore < oldHighscore3) {
					PlayerPrefs.SetFloat("highscoreEndureEasy4", finalscore);
					PlayerPrefs.SetFloat("highscoreEndureEasy5", oldHighscore4);
					PlayerPrefs.SetFloat("highscorePerfectEasy4", perfectgames);
					PlayerPrefs.SetFloat("highscorePerfectEasy5", oldPerfectscore4);
					PlayerPrefs.SetFloat("highscoreGamesEasy4", numbergames);
					PlayerPrefs.SetFloat("highscoreGamesEasy5", oldGamesscore4);
					PlayerPrefs.Save ();
				}				
				if (finalscore >= oldHighscore5 && finalscore < oldHighscore4) {
					PlayerPrefs.SetFloat("highscoreEndureEasy5", finalscore);
					PlayerPrefs.SetFloat("highscorePerfectEasy5", perfectgames);
					PlayerPrefs.SetFloat("highscoreGamesEasy5", numbergames);
					PlayerPrefs.Save ();
				}
			}
		}
		
		if (SceneManager.GetActiveScene().name.Contains("Med")) {
			if (GameObject.Find("EndureObject") == false) {

				float highscoreMed = finalscore*10;
				Social.ReportScore((long)highscoreMed,SPRHresources.leaderboard_medium_leaders,(bool success) => {});

				oldHighscore1 = PlayerPrefs.GetFloat("highscoreMed1", 0);
				oldHighscore2 = PlayerPrefs.GetFloat("highscoreMed2", 0);
				oldHighscore3 = PlayerPrefs.GetFloat("highscoreMed3", 0);
				oldHighscore4 = PlayerPrefs.GetFloat("highscoreMed4", 0);
				oldHighscore5 = PlayerPrefs.GetFloat("highscoreMed5", 0);
				
				if (finalscore >= oldHighscore1) {
					PlayerPrefs.SetFloat("highscoreMed1", finalscore);
					PlayerPrefs.SetFloat("highscoreMed2", oldHighscore1);
					PlayerPrefs.SetFloat("highscoreMed3", oldHighscore2);
					PlayerPrefs.SetFloat("highscoreMed4", oldHighscore3);
					PlayerPrefs.SetFloat("highscoreMed5", oldHighscore4);
					PlayerPrefs.Save ();
				}
				if (finalscore >= oldHighscore2 && finalscore < oldHighscore1) {
					PlayerPrefs.SetFloat("highscoreMed2", finalscore);
					PlayerPrefs.SetFloat("highscoreMed3", oldHighscore2);
					PlayerPrefs.SetFloat("highscoreMed4", oldHighscore3);
					PlayerPrefs.SetFloat("highscoreMed5", oldHighscore4);
					PlayerPrefs.Save ();
				}
				if (finalscore >= oldHighscore3 && finalscore < oldHighscore2) {
					PlayerPrefs.SetFloat("highscoreMed3", finalscore);
					PlayerPrefs.SetFloat("highscoreMed4", oldHighscore3);
					PlayerPrefs.SetFloat("highscoreMed5", oldHighscore4);
					PlayerPrefs.Save ();
				}
				if (finalscore >= oldHighscore4 && finalscore < oldHighscore3) {
					PlayerPrefs.SetFloat("highscoreMed4", finalscore);
					PlayerPrefs.SetFloat("highscoreMed5", oldHighscore4);
					PlayerPrefs.Save ();
				}
				if (finalscore >= oldHighscore5 && finalscore < oldHighscore4) {
					PlayerPrefs.SetFloat("highscoreMed5", finalscore);
					PlayerPrefs.Save ();
				}
			} else {
				oldHighscore1 = PlayerPrefs.GetFloat("highscoreEndureMed1", 0);
				oldHighscore2 = PlayerPrefs.GetFloat("highscoreEndureMed2", 0);
				oldHighscore3 = PlayerPrefs.GetFloat("highscoreEndureMed3", 0);
				oldHighscore4 = PlayerPrefs.GetFloat("highscoreEndureMed4", 0);
				oldHighscore5 = PlayerPrefs.GetFloat("highscoreEndureMed5", 0);
			
				oldPerfectscore1 = PlayerPrefs.GetFloat("highscorePerfectMed1", 0);
				oldPerfectscore2 = PlayerPrefs.GetFloat("highscorePerfectMed2", 0);
				oldPerfectscore3 = PlayerPrefs.GetFloat("highscorePerfectMed3", 0);
				oldPerfectscore4 = PlayerPrefs.GetFloat("highscorePerfectMed4", 0);
				oldPerfectscore5 = PlayerPrefs.GetFloat("highscorePerfectMed5", 0);
				
				oldGamesscore1 = PlayerPrefs.GetFloat("highscoreGamesMed1", 0);
				oldGamesscore2 = PlayerPrefs.GetFloat("highscoreGamesMed2", 0);
				oldGamesscore3 = PlayerPrefs.GetFloat("highscoreGamesMed3", 0);
				oldGamesscore4 = PlayerPrefs.GetFloat("highscoreGamesMed4", 0);
				oldGamesscore5 = PlayerPrefs.GetFloat("highscoreGamesMed5", 0);
				
				if (finalscore >= oldHighscore1) {
					PlayerPrefs.SetFloat("highscoreEndureMed1", finalscore);
					PlayerPrefs.SetFloat("highscoreEndureMed2", oldHighscore1);
					PlayerPrefs.SetFloat("highscoreEndureMed3", oldHighscore2);
					PlayerPrefs.SetFloat("highscoreEndureMed4", oldHighscore3);
					PlayerPrefs.SetFloat("highscoreEndureMed5", oldHighscore4);
					PlayerPrefs.SetFloat("highscorePerfectMed1", perfectgames);
					PlayerPrefs.SetFloat("highscorePerfectMed2", oldPerfectscore1);
					PlayerPrefs.SetFloat("highscorePerfectMed3", oldPerfectscore2);
					PlayerPrefs.SetFloat("highscorePerfectMed4", oldPerfectscore3);
					PlayerPrefs.SetFloat("highscorePerfectMed5", oldPerfectscore4);
					PlayerPrefs.SetFloat("highscoreGamesMed1", numbergames);
					PlayerPrefs.SetFloat("highscoreGamesMed2", oldGamesscore1);
					PlayerPrefs.SetFloat("highscoreGamesMed3", oldGamesscore2);
					PlayerPrefs.SetFloat("highscoreGamesMed4", oldGamesscore3);
					PlayerPrefs.SetFloat("highscoreGamesMed5", oldGamesscore4);
					PlayerPrefs.Save ();
				}				
				if (finalscore >= oldHighscore2 && finalscore < oldHighscore1) {
					PlayerPrefs.SetFloat("highscoreEndureMed2", finalscore);
					PlayerPrefs.SetFloat("highscoreEndureMed3", oldHighscore2);
					PlayerPrefs.SetFloat("highscoreEndureMed4", oldHighscore3);
					PlayerPrefs.SetFloat("highscoreEndureMed5", oldHighscore4);
					PlayerPrefs.SetFloat("highscorePerfectMed2", perfectgames);
					PlayerPrefs.SetFloat("highscorePerfectMed3", oldPerfectscore2);
					PlayerPrefs.SetFloat("highscorePerfectMed4", oldPerfectscore3);
					PlayerPrefs.SetFloat("highscorePerfectMed5", oldPerfectscore4);
					PlayerPrefs.SetFloat("highscoreGamesMed2", numbergames);
					PlayerPrefs.SetFloat("highscoreGamesMed3", oldGamesscore2);
					PlayerPrefs.SetFloat("highscoreGamesMed4", oldGamesscore3);
					PlayerPrefs.SetFloat("highscoreGamesMed5", oldGamesscore4);
					PlayerPrefs.Save ();
				}				
				if (finalscore >= oldHighscore3 && finalscore < oldHighscore2) {
					PlayerPrefs.SetFloat("highscoreEndureMed3", finalscore);
					PlayerPrefs.SetFloat("highscoreEndureMed4", oldHighscore3);
					PlayerPrefs.SetFloat("highscoreEndureMed5", oldHighscore4);
					PlayerPrefs.SetFloat("highscorePerfectMed3", perfectgames);
					PlayerPrefs.SetFloat("highscorePerfectMed4", oldPerfectscore3);
					PlayerPrefs.SetFloat("highscorePerfectMed5", oldPerfectscore4);
					PlayerPrefs.SetFloat("highscoreGamesMed3", numbergames);
					PlayerPrefs.SetFloat("highscoreGamesMed4", oldGamesscore3);
					PlayerPrefs.SetFloat("highscoreGamesMed5", oldGamesscore4);
					PlayerPrefs.Save ();
				}				
				if (finalscore >= oldHighscore4 && finalscore < oldHighscore3) {
					PlayerPrefs.SetFloat("highscoreEndureMed4", finalscore);
					PlayerPrefs.SetFloat("highscoreEndureMed5", oldHighscore4);
					PlayerPrefs.SetFloat("highscorePerfectMed4", perfectgames);
					PlayerPrefs.SetFloat("highscorePerfectMed5", oldPerfectscore4);
					PlayerPrefs.SetFloat("highscoreGamesMed4", numbergames);
					PlayerPrefs.SetFloat("highscoreGamesMed5", oldGamesscore4);
					PlayerPrefs.Save ();
				}				
				if (finalscore >= oldHighscore5 && finalscore < oldHighscore4) {
					PlayerPrefs.SetFloat("highscoreEndureMed5", finalscore);
					PlayerPrefs.SetFloat("highscorePerfectMed5", perfectgames);
					PlayerPrefs.SetFloat("highscoreGamesMed5", numbergames);
					PlayerPrefs.Save ();
				}
			}
		}
		
		if (SceneManager.GetActiveScene().name.Contains("Hard")) {
			if (GameObject.Find("EndureObject") == false) {

				float highscoreHard = finalscore*10;
				Social.ReportScore((long)highscoreHard,SPRHresources.leaderboard_hard_leaders,(bool success) => {});

				oldHighscore1 = PlayerPrefs.GetFloat("highscoreHard1", 0);
				oldHighscore2 = PlayerPrefs.GetFloat("highscoreHard2", 0);
				oldHighscore3 = PlayerPrefs.GetFloat("highscoreHard3", 0);
				oldHighscore4 = PlayerPrefs.GetFloat("highscoreHard4", 0);
				oldHighscore5 = PlayerPrefs.GetFloat("highscoreHard5", 0);
				
				if (finalscore >= oldHighscore1) {
					PlayerPrefs.SetFloat("highscoreHard1", finalscore);
					PlayerPrefs.SetFloat("highscoreHard2", oldHighscore1);
					PlayerPrefs.SetFloat("highscoreHard3", oldHighscore2);
					PlayerPrefs.SetFloat("highscoreHard4", oldHighscore3);
					PlayerPrefs.SetFloat("highscoreHard5", oldHighscore4);
					PlayerPrefs.Save ();
				}
				if (finalscore >= oldHighscore2 && finalscore < oldHighscore1) {
					PlayerPrefs.SetFloat("highscoreHard2", finalscore);
					PlayerPrefs.SetFloat("highscoreHard3", oldHighscore2);
					PlayerPrefs.SetFloat("highscoreHard4", oldHighscore3);
					PlayerPrefs.SetFloat("highscoreHard5", oldHighscore4);
					PlayerPrefs.Save ();
				}
				if (finalscore >= oldHighscore3 && finalscore < oldHighscore2) {
					PlayerPrefs.SetFloat("highscoreHard3", finalscore);
					PlayerPrefs.SetFloat("highscoreHard4", oldHighscore3);
					PlayerPrefs.SetFloat("highscoreHard5", oldHighscore4);
					PlayerPrefs.Save ();
				}
				if (finalscore >= oldHighscore4 && finalscore < oldHighscore3) {
					PlayerPrefs.SetFloat("highscoreHard4", finalscore);
					PlayerPrefs.SetFloat("highscoreHard5", oldHighscore4);
					PlayerPrefs.Save ();
				}
				if (finalscore >= oldHighscore5 && finalscore < oldHighscore4) {
					PlayerPrefs.SetFloat("highscoreHard5", finalscore);
					PlayerPrefs.Save ();
				}
			} else {
				oldHighscore1 = PlayerPrefs.GetFloat("highscoreEndureHard1", 0);
				oldHighscore2 = PlayerPrefs.GetFloat("highscoreEndureHard2", 0);
				oldHighscore3 = PlayerPrefs.GetFloat("highscoreEndureHard3", 0);
				oldHighscore4 = PlayerPrefs.GetFloat("highscoreEndureHard4", 0);
				oldHighscore5 = PlayerPrefs.GetFloat("highscoreEndureHard5", 0);
			
				oldPerfectscore1 = PlayerPrefs.GetFloat("highscorePerfectHard1", 0);
				oldPerfectscore2 = PlayerPrefs.GetFloat("highscorePerfectHard2", 0);
				oldPerfectscore3 = PlayerPrefs.GetFloat("highscorePerfectHard3", 0);
				oldPerfectscore4 = PlayerPrefs.GetFloat("highscorePerfectHard4", 0);
				oldPerfectscore5 = PlayerPrefs.GetFloat("highscorePerfectHard5", 0);
				
				oldGamesscore1 = PlayerPrefs.GetFloat("highscoreGamesHard1", 0);
				oldGamesscore2 = PlayerPrefs.GetFloat("highscoreGamesHard2", 0);
				oldGamesscore3 = PlayerPrefs.GetFloat("highscoreGamesHard3", 0);
				oldGamesscore4 = PlayerPrefs.GetFloat("highscoreGamesHard4", 0);
				oldGamesscore5 = PlayerPrefs.GetFloat("highscoreGamesHard5", 0);
				
				if (finalscore >= oldHighscore1) {
					PlayerPrefs.SetFloat("highscoreEndureHard1", finalscore);
					PlayerPrefs.SetFloat("highscoreEndureHard2", oldHighscore1);
					PlayerPrefs.SetFloat("highscoreEndureHard3", oldHighscore2);
					PlayerPrefs.SetFloat("highscoreEndureHard4", oldHighscore3);
					PlayerPrefs.SetFloat("highscoreEndureHard5", oldHighscore4);
					PlayerPrefs.SetFloat("highscorePerfectHard1", perfectgames);
					PlayerPrefs.SetFloat("highscorePerfectHard2", oldPerfectscore1);
					PlayerPrefs.SetFloat("highscorePerfectHard3", oldPerfectscore2);
					PlayerPrefs.SetFloat("highscorePerfectHard4", oldPerfectscore3);
					PlayerPrefs.SetFloat("highscorePerfectHard5", oldPerfectscore4);
					PlayerPrefs.SetFloat("highscoreGamesHard1", numbergames);
					PlayerPrefs.SetFloat("highscoreGamesHard2", oldGamesscore1);
					PlayerPrefs.SetFloat("highscoreGamesHard3", oldGamesscore2);
					PlayerPrefs.SetFloat("highscoreGamesHard4", oldGamesscore3);
					PlayerPrefs.SetFloat("highscoreGamesHard5", oldGamesscore4);
					PlayerPrefs.Save ();
				}				
				if (finalscore >= oldHighscore2 && finalscore < oldHighscore1) {
					PlayerPrefs.SetFloat("highscoreEndureHard2", finalscore);
					PlayerPrefs.SetFloat("highscoreEndureHard3", oldHighscore2);
					PlayerPrefs.SetFloat("highscoreEndureHard4", oldHighscore3);
					PlayerPrefs.SetFloat("highscoreEndureHard5", oldHighscore4);
					PlayerPrefs.SetFloat("highscorePerfectHard2", perfectgames);
					PlayerPrefs.SetFloat("highscorePerfectHard3", oldPerfectscore2);
					PlayerPrefs.SetFloat("highscorePerfectHard4", oldPerfectscore3);
					PlayerPrefs.SetFloat("highscorePerfectHard5", oldPerfectscore4);
					PlayerPrefs.SetFloat("highscoreGamesHard2", numbergames);
					PlayerPrefs.SetFloat("highscoreGamesHard3", oldGamesscore2);
					PlayerPrefs.SetFloat("highscoreGamesHard4", oldGamesscore3);
					PlayerPrefs.SetFloat("highscoreGamesHard5", oldGamesscore4);
					PlayerPrefs.Save ();
				}				
				if (finalscore >= oldHighscore3 && finalscore < oldHighscore2) {
					PlayerPrefs.SetFloat("highscoreEndureHard3", finalscore);
					PlayerPrefs.SetFloat("highscoreEndureHard4", oldHighscore3);
					PlayerPrefs.SetFloat("highscoreEndureHard5", oldHighscore4);
					PlayerPrefs.SetFloat("highscorePerfectHard3", perfectgames);
					PlayerPrefs.SetFloat("highscorePerfectHard4", oldPerfectscore3);
					PlayerPrefs.SetFloat("highscorePerfectHard5", oldPerfectscore4);
					PlayerPrefs.SetFloat("highscoreGamesHard3", numbergames);
					PlayerPrefs.SetFloat("highscoreGamesHard4", oldGamesscore3);
					PlayerPrefs.SetFloat("highscoreGamesHard5", oldGamesscore4);
					
					PlayerPrefs.Save ();
				}				
				if (finalscore >= oldHighscore4 && finalscore < oldHighscore3) {
					PlayerPrefs.SetFloat("highscoreEndureHard4", finalscore);
					PlayerPrefs.SetFloat("highscoreEndureHard5", oldHighscore4);
					PlayerPrefs.SetFloat("highscorePerfectHard4", perfectgames);
					PlayerPrefs.SetFloat("highscorePerfectHard5", oldPerfectscore4);
					PlayerPrefs.SetFloat("highscoreGamesHard4", numbergames);
					PlayerPrefs.SetFloat("highscoreGamesHard5", oldGamesscore4);
					PlayerPrefs.Save ();
				}				
				if (finalscore >= oldHighscore5 && finalscore < oldHighscore4) {
					PlayerPrefs.SetFloat("highscoreEndureHard5", finalscore);
					PlayerPrefs.SetFloat("highscorePerfectHard5", perfectgames);
					PlayerPrefs.SetFloat("highscoreGamesHard5", numbergames);
					PlayerPrefs.Save ();
				}
			}
		}
		
		if (SceneManager.GetActiveScene().name.Contains("Xprt")) {
			if (GameObject.Find("EndureObject") == false) {

				float highscoreXprt = finalscore*10;
				Social.ReportScore((long)highscoreXprt,SPRHresources.leaderboard_expert_leaders,(bool success) => {});

				oldHighscore1 = PlayerPrefs.GetFloat("highscoreXprt1", 0);
				oldHighscore2 = PlayerPrefs.GetFloat("highscoreXprt2", 0);
				oldHighscore3 = PlayerPrefs.GetFloat("highscoreXprt3", 0);
				oldHighscore4 = PlayerPrefs.GetFloat("highscoreXprt4", 0);
				oldHighscore5 = PlayerPrefs.GetFloat("highscoreXprt5", 0);
				
				if (finalscore >= oldHighscore1) {
					PlayerPrefs.SetFloat("highscoreXprt1", finalscore);
					PlayerPrefs.SetFloat("highscoreXprt2", oldHighscore1);
					PlayerPrefs.SetFloat("highscoreXprt3", oldHighscore2);
					PlayerPrefs.SetFloat("highscoreXprt4", oldHighscore3);
					PlayerPrefs.SetFloat("highscoreXprt5", oldHighscore4);
					PlayerPrefs.Save ();
				}
				if (finalscore >= oldHighscore2 && finalscore < oldHighscore1) {
					PlayerPrefs.SetFloat("highscoreXprt2", finalscore);
					PlayerPrefs.SetFloat("highscoreXprt3", oldHighscore2);
					PlayerPrefs.SetFloat("highscoreXprt4", oldHighscore3);
					PlayerPrefs.SetFloat("highscoreXprt5", oldHighscore4);
					PlayerPrefs.Save ();
				}
				if (finalscore >= oldHighscore3 && finalscore < oldHighscore2) {
					PlayerPrefs.SetFloat("highscoreXprt3", finalscore);
					PlayerPrefs.SetFloat("highscoreXprt4", oldHighscore3);
					PlayerPrefs.SetFloat("highscoreXprt5", oldHighscore4);
					PlayerPrefs.Save ();
				}
				if (finalscore >= oldHighscore4 && finalscore < oldHighscore3) {
					PlayerPrefs.SetFloat("highscoreXprt4", finalscore);
					PlayerPrefs.SetFloat("highscoreXprt5", oldHighscore4);
					PlayerPrefs.Save ();
				}
				if (finalscore >= oldHighscore5 && finalscore < oldHighscore4) {
					PlayerPrefs.SetFloat("highscoreXprt5", finalscore);
					PlayerPrefs.Save ();
				}
			} else {
				oldHighscore1 = PlayerPrefs.GetFloat("highscoreEndureXprt1", 0);
				oldHighscore2 = PlayerPrefs.GetFloat("highscoreEndureXprt2", 0);
				oldHighscore3 = PlayerPrefs.GetFloat("highscoreEndureXprt3", 0);
				oldHighscore4 = PlayerPrefs.GetFloat("highscoreEndureXprt4", 0);
				oldHighscore5 = PlayerPrefs.GetFloat("highscoreEndureXprt5", 0);
			
				oldPerfectscore1 = PlayerPrefs.GetFloat("highscorePerfectXprt1", 0);
				oldPerfectscore2 = PlayerPrefs.GetFloat("highscorePerfectXprt2", 0);
				oldPerfectscore3 = PlayerPrefs.GetFloat("highscorePerfectXprt3", 0);
				oldPerfectscore4 = PlayerPrefs.GetFloat("highscorePerfectXprt4", 0);
				oldPerfectscore5 = PlayerPrefs.GetFloat("highscorePerfectXprt5", 0);
				
				oldGamesscore1 = PlayerPrefs.GetFloat("highscoreGamesXprt1", 0);
				oldGamesscore2 = PlayerPrefs.GetFloat("highscoreGamesXprt2", 0);
				oldGamesscore3 = PlayerPrefs.GetFloat("highscoreGamesXprt3", 0);
				oldGamesscore4 = PlayerPrefs.GetFloat("highscoreGamesXprt4", 0);
				oldGamesscore5 = PlayerPrefs.GetFloat("highscoreGamesXprt5", 0);
				
				if (finalscore >= oldHighscore1) {
					PlayerPrefs.SetFloat("highscoreEndureXprt1", finalscore);
					PlayerPrefs.SetFloat("highscoreEndureXprt2", oldHighscore1);
					PlayerPrefs.SetFloat("highscoreEndureXprt3", oldHighscore2);
					PlayerPrefs.SetFloat("highscoreEndureXprt4", oldHighscore3);
					PlayerPrefs.SetFloat("highscoreEndureXprt5", oldHighscore4);
					PlayerPrefs.SetFloat("highscorePerfectXprt1", perfectgames);
					PlayerPrefs.SetFloat("highscorePerfectXprt2", oldPerfectscore1);
					PlayerPrefs.SetFloat("highscorePerfectXprt3", oldPerfectscore2);
					PlayerPrefs.SetFloat("highscorePerfectXprt4", oldPerfectscore3);
					PlayerPrefs.SetFloat("highscorePerfectXprt5", oldPerfectscore4);
					PlayerPrefs.SetFloat("highscoreGamesXprt1", numbergames);
					PlayerPrefs.SetFloat("highscoreGamesXprt2", oldGamesscore1);
					PlayerPrefs.SetFloat("highscoreGamesXprt3", oldGamesscore2);
					PlayerPrefs.SetFloat("highscoreGamesXprt4", oldGamesscore3);
					PlayerPrefs.SetFloat("highscoreGamesXprt5", oldGamesscore4);
					PlayerPrefs.Save ();
				}				
				if (finalscore >= oldHighscore2 && finalscore < oldHighscore1) {
					PlayerPrefs.SetFloat("highscoreEndureXprt2", finalscore);
					PlayerPrefs.SetFloat("highscoreEndureXprt3", oldHighscore2);
					PlayerPrefs.SetFloat("highscoreEndureXprt4", oldHighscore3);
					PlayerPrefs.SetFloat("highscoreEndureXprt5", oldHighscore4);
					PlayerPrefs.SetFloat("highscorePerfectXprt2", perfectgames);
					PlayerPrefs.SetFloat("highscorePerfectXprt3", oldPerfectscore2);
					PlayerPrefs.SetFloat("highscorePerfectXprt4", oldPerfectscore3);
					PlayerPrefs.SetFloat("highscorePerfectXprt5", oldPerfectscore4);
					PlayerPrefs.SetFloat("highscoreGamesXprt2", numbergames);
					PlayerPrefs.SetFloat("highscoreGamesXprt3", oldGamesscore2);
					PlayerPrefs.SetFloat("highscoreGamesXprt4", oldGamesscore3);
					PlayerPrefs.SetFloat("highscoreGamesXprt5", oldGamesscore4);
					PlayerPrefs.Save ();
				}				
				if (finalscore >= oldHighscore3 && finalscore < oldHighscore2) {
					PlayerPrefs.SetFloat("highscoreEndureXprt3", finalscore);
					PlayerPrefs.SetFloat("highscoreEndureXprt4", oldHighscore3);
					PlayerPrefs.SetFloat("highscoreEndureXprt5", oldHighscore4);
					PlayerPrefs.SetFloat("highscorePerfectXprt3", perfectgames);
					PlayerPrefs.SetFloat("highscorePerfectXprt4", oldPerfectscore3);
					PlayerPrefs.SetFloat("highscorePerfectXprt5", oldPerfectscore4);
					PlayerPrefs.SetFloat("highscoreGamesXprt3", numbergames);
					PlayerPrefs.SetFloat("highscoreGamesXprt4", oldGamesscore3);
					PlayerPrefs.SetFloat("highscoreGamesXprt5", oldGamesscore4);
					PlayerPrefs.Save ();
				}				
				if (finalscore >= oldHighscore4 && finalscore < oldHighscore3) {
					PlayerPrefs.SetFloat("highscoreEndureXprt4", finalscore);
					PlayerPrefs.SetFloat("highscoreEndureXprt5", oldHighscore4);
					PlayerPrefs.SetFloat("highscorePerfectXprt4", perfectgames);
					PlayerPrefs.SetFloat("highscorePerfectXprt5", oldPerfectscore4);
					PlayerPrefs.SetFloat("highscoreGamesXprt4", numbergames);
					PlayerPrefs.SetFloat("highscoreGamesXprt5", oldGamesscore4);
					PlayerPrefs.Save ();
				}				
				if (finalscore >= oldHighscore5 && finalscore < oldHighscore4) {
					PlayerPrefs.SetFloat("highscoreEndureXprt5", finalscore);
					PlayerPrefs.SetFloat("highscorePerfectXprt5", perfectgames);
					PlayerPrefs.SetFloat("highscoreGamesXprt5", numbergames);
					PlayerPrefs.Save ();
				}
			}
		}
		
		if (SceneManager.GetActiveScene().name.Contains("Insane")) {
			if (GameObject.Find("EndureObject") == false) {

				float highscoreInsane = finalscore;
				Social.ReportScore((long)highscoreInsane,SPRHresources.leaderboard_insane_leaders,(bool success) => {});

				oldHighscore1 = PlayerPrefs.GetFloat("highscoreInsane1", 0);
				oldHighscore2 = PlayerPrefs.GetFloat("highscoreInsane2", 0);
				oldHighscore3 = PlayerPrefs.GetFloat("highscoreInsane3", 0);
				oldHighscore4 = PlayerPrefs.GetFloat("highscoreInsane4", 0);
				oldHighscore5 = PlayerPrefs.GetFloat("highscoreInsane5", 0);
				
				if (finalscore >= oldHighscore1) {
					PlayerPrefs.SetFloat("highscoreInsane1", finalscore);
					PlayerPrefs.SetFloat("highscoreInsane2", oldHighscore1);
					PlayerPrefs.SetFloat("highscoreInsane3", oldHighscore2);
					PlayerPrefs.SetFloat("highscoreInsane4", oldHighscore3);
					PlayerPrefs.SetFloat("highscoreInsane5", oldHighscore4);
					PlayerPrefs.Save ();
				}
				if (finalscore >= oldHighscore2 && finalscore < oldHighscore1) {
					PlayerPrefs.SetFloat("highscoreInsane2", finalscore);
					PlayerPrefs.SetFloat("highscoreInsane3", oldHighscore2);
					PlayerPrefs.SetFloat("highscoreInsane4", oldHighscore3);
					PlayerPrefs.SetFloat("highscoreInsane5", oldHighscore4);
					PlayerPrefs.Save ();
				}
				if (finalscore >= oldHighscore3 && finalscore < oldHighscore2) {
					PlayerPrefs.SetFloat("highscoreInsane3", finalscore);
					PlayerPrefs.SetFloat("highscoreInsane4", oldHighscore3);
					PlayerPrefs.SetFloat("highscoreInsane5", oldHighscore4);
					PlayerPrefs.Save ();
				}
				if (finalscore >= oldHighscore4 && finalscore < oldHighscore3) {
					PlayerPrefs.SetFloat("highscoreInsane4", finalscore);
					PlayerPrefs.SetFloat("highscoreInsane5", oldHighscore4);
					PlayerPrefs.Save ();
				}
				if (finalscore >= oldHighscore5 && finalscore < oldHighscore4) {
					PlayerPrefs.SetFloat("highscoreInsane5", finalscore);
					PlayerPrefs.Save ();
				}
			} else {
				oldHighscore1 = PlayerPrefs.GetFloat("highscoreEndureInsane1", 0);
				oldHighscore2 = PlayerPrefs.GetFloat("highscoreEndureInsane2", 0);
				oldHighscore3 = PlayerPrefs.GetFloat("highscoreEndureInsane3", 0);
				oldHighscore4 = PlayerPrefs.GetFloat("highscoreEndureInsane4", 0);
				oldHighscore5 = PlayerPrefs.GetFloat("highscoreEndureInsane5", 0);
				
				oldPerfectscore1 = PlayerPrefs.GetFloat("highscorePerfectInsane1", 0);
				oldPerfectscore2 = PlayerPrefs.GetFloat("highscorePerfectInsane2", 0);
				oldPerfectscore3 = PlayerPrefs.GetFloat("highscorePerfectInsane3", 0);
				oldPerfectscore4 = PlayerPrefs.GetFloat("highscorePerfectInsane4", 0);
				oldPerfectscore5 = PlayerPrefs.GetFloat("highscorePerfectInsane5", 0);
				
				oldGamesscore1 = PlayerPrefs.GetFloat("highscoreGamesInsane1", 0);
				oldGamesscore2 = PlayerPrefs.GetFloat("highscoreGamesInsane2", 0);
				oldGamesscore3 = PlayerPrefs.GetFloat("highscoreGamesInsane3", 0);
				oldGamesscore4 = PlayerPrefs.GetFloat("highscoreGamesInsane4", 0);
				oldGamesscore5 = PlayerPrefs.GetFloat("highscoreGamesInsane5", 0);
				
				if (finalscore >= oldHighscore1) {
					PlayerPrefs.SetFloat("highscoreEndureInsane1", finalscore);
					PlayerPrefs.SetFloat("highscoreEndureInsane2", oldHighscore1);
					PlayerPrefs.SetFloat("highscoreEndureInsane3", oldHighscore2);
					PlayerPrefs.SetFloat("highscoreEndureInsane4", oldHighscore3);
					PlayerPrefs.SetFloat("highscoreEndureInsane5", oldHighscore4);
					PlayerPrefs.SetFloat("highscorePerfectInsane1", perfectgames);
					PlayerPrefs.SetFloat("highscorePerfectInsane2", oldPerfectscore1);
					PlayerPrefs.SetFloat("highscorePerfectInsane3", oldPerfectscore2);
					PlayerPrefs.SetFloat("highscorePerfectInsane4", oldPerfectscore3);
					PlayerPrefs.SetFloat("highscorePerfectInsane5", oldPerfectscore4);
					PlayerPrefs.SetFloat("highscoreGamesInsane1", numbergames);
					PlayerPrefs.SetFloat("highscoreGamesInsane2", oldGamesscore1);
					PlayerPrefs.SetFloat("highscoreGamesInsane3", oldGamesscore2);
					PlayerPrefs.SetFloat("highscoreGamesInsane4", oldGamesscore3);
					PlayerPrefs.SetFloat("highscoreGamesInsane5", oldGamesscore4);
					PlayerPrefs.Save ();
				}				
				if (finalscore >= oldHighscore2 && finalscore < oldHighscore1) {
					PlayerPrefs.SetFloat("highscoreEndureInsane2", finalscore);
					PlayerPrefs.SetFloat("highscoreEndureInsane3", oldHighscore2);
					PlayerPrefs.SetFloat("highscoreEndureInsane4", oldHighscore3);
					PlayerPrefs.SetFloat("highscoreEndureInsane5", oldHighscore4);
					PlayerPrefs.SetFloat("highscorePerfectInsane2", perfectgames);
					PlayerPrefs.SetFloat("highscorePerfectInsane3", oldPerfectscore2);
					PlayerPrefs.SetFloat("highscorePerfectInsane4", oldPerfectscore3);
					PlayerPrefs.SetFloat("highscorePerfectInsane5", oldPerfectscore4);
					PlayerPrefs.SetFloat("highscoreGamesInsane2", numbergames);
					PlayerPrefs.SetFloat("highscoreGamesInsane3", oldGamesscore2);
					PlayerPrefs.SetFloat("highscoreGamesInsane4", oldGamesscore3);
					PlayerPrefs.SetFloat("highscoreGamesInsane5", oldGamesscore4);
					PlayerPrefs.Save ();
				}				
				if (finalscore >= oldHighscore3 && finalscore < oldHighscore2) {
					PlayerPrefs.SetFloat("highscoreEndureInsane3", finalscore);
					PlayerPrefs.SetFloat("highscoreEndureInsane4", oldHighscore3);
					PlayerPrefs.SetFloat("highscoreEndureInsane5", oldHighscore4);
					PlayerPrefs.SetFloat("highscorePerfectInsane3", perfectgames);
					PlayerPrefs.SetFloat("highscorePerfectInsane4", oldPerfectscore3);
					PlayerPrefs.SetFloat("highscorePerfectInsane5", oldPerfectscore4);
					PlayerPrefs.SetFloat("highscoreGamesInsane3", numbergames);
					PlayerPrefs.SetFloat("highscoreGamesInsane4", oldGamesscore3);
					PlayerPrefs.SetFloat("highscoreGamesInsane5", oldGamesscore4);
					PlayerPrefs.Save ();
				}				
				if (finalscore >= oldHighscore4 && finalscore < oldHighscore3) {
					PlayerPrefs.SetFloat("highscoreEndureInsane4", finalscore);
					PlayerPrefs.SetFloat("highscoreEndureInsane5", oldHighscore4);
					PlayerPrefs.SetFloat("highscorePerfectInsane4", perfectgames);
					PlayerPrefs.SetFloat("highscorePerfectInsane5", oldPerfectscore4);
					PlayerPrefs.SetFloat("highscoreGamesInsane4", numbergames);
					PlayerPrefs.SetFloat("highscoreGamesInsane5", oldGamesscore4);
					PlayerPrefs.Save ();
				}				
				if (finalscore >= oldHighscore5 && finalscore < oldHighscore4) {
					PlayerPrefs.SetFloat("highscoreEndureInsane5", finalscore);
					PlayerPrefs.SetFloat("highscorePerfectInsane5", perfectgames);
					PlayerPrefs.SetFloat("highscoreGamesInsane5", numbergames);
					PlayerPrefs.Save ();
				}
			}
		}
	}
}