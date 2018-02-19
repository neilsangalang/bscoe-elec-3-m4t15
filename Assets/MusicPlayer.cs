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
		Invoke("LoadSceneManager", 2f);
	}
	
	// Update is called once per frame
	void Update () {
		SceneManager.LoadScene(1);
	}
}
