using UnityEngine;
using System.Collections.Generic;

public class Endure : MonoBehaviour {
	static Endure instance = null;

	void Awake () {
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}
}