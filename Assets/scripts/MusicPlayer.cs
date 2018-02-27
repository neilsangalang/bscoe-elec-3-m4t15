using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

	void Awake(){
		DontDestroyOnLoad(gameObject);
	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	public void LoadSceneManager() {
		SceneManager.LoadScene(1);
	}
}
