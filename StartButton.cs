using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {

	void OnMouseUp () {
		if (GameObject.FindWithTag("display") != null){
			GameObject [] Displays = GameObject.FindGameObjectsWithTag("display");
			foreach (GameObject display in Displays){
				GameObject.Destroy(display);
			}
		}
		PlayerPrefs.SetInt("PegsCanMove",1);
	}
}