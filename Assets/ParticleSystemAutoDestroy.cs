using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemAutoDestroy : MonoBehaviour {

    private ParticleSystem particlesystem;

    public void Start()
    {
        particlesystem = GetComponent<ParticleSystem>();
    }

    public void Update()
    {
        if (particlesystem)
        {
            if (!particlesystem.IsAlive())
            {
                Destroy(gameObject);
            }
        }
    }
}
