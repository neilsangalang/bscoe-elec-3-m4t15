using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bulletHit : MonoBehaviour {
    public GameObject Explosion;
    AudioSource audioSource = new AudioSource();
    GameObject enemy;
    GameObject totalScore;
    float HP;
    int score;

	// Use this for initialization
	void Start () {
        totalScore = GameObject.Find("Score");
        score = 0;
        totalScore.GetComponent<Text>().text = "000";
    }
	
    void OnParticleCollision(GameObject other)
    {
        Debug.Log(other + " hits!!");
        if(other.gameObject.tag == "Enemy")
        {
            enemy = other;
            reduceHP();
            if (HP < 5)
            {
                audioSource = other.GetComponent<AudioSource>();
                enemy.GetComponent<MeshRenderer>().enabled = false;
                enemy.GetComponent<BoxCollider>().enabled = false;
                audioSource.Play();
                scoreUp(enemy);
                Debug.Log(" Enemy Hits!!!!");
                GameObject newExplosion = Instantiate(Explosion, other.transform.position, other.transform.rotation);
                StartCoroutine(destroy());
            }
            
        }
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(enemy);
    }

    void reduceHP()
    {
        enemy.transform.Find("Enemy Canvas/Healthbar").GetComponent<Slider>().value -= 5;
        HP = enemy.transform.Find("Enemy Canvas/Healthbar").GetComponent<Slider>().value;
    }

    void scoreUp(GameObject enemy)
    {   
        Int32.TryParse(totalScore.GetComponent<Text>().text, out score);
        if (enemy.name.Substring(0, 7).Equals("Enemy A"))
        {
            score += 500;
        }
        else if (enemy.name.Substring(0, 7).Equals("Enemy B"))
        {
            score += 200;
        }
        else if (enemy.name.Substring(0, 7).Equals("Enemy C"))
        {
            score += 100;
        }
        totalScore.GetComponent<Text>().text = score.ToString();
    }
}
