using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
		print(xThrow);
		float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
		print(yThrow);
	}
}
