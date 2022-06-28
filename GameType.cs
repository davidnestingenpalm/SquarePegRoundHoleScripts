using UnityEngine;
using System.Collections.Generic;

public class GameType : MonoBehaviour {

	void Start () {
		if (GameObject.FindGameObjectWithTag ("endure") == true) {
			Destroy (GameObject.FindGameObjectWithTag("endure"));
		}
	}
}