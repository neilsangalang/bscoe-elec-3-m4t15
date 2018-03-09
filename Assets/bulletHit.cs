using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHit : MonoBehaviour {
    public GameObject explosion;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnParticleCollision(GameObject other)
    {
        Debug.Log(other + " hits!!");
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log(" Enemy Hits!!!!");
            GameObject newExplosion = Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(other);
        }
        
    }
}
