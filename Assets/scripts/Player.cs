using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;



public class Player : MonoBehaviour
{
    AudioSource audioSource = new AudioSource();
    Vector3 currentPosition, currentRotation;
    public GameObject playercamera;
    [SerializeField] float controlSpeed;
    [SerializeField] float tiltSpeed;
    [SerializeField] float xMinRange;
    [SerializeField] float xMaxRange;
    [SerializeField] float yMinRange;
    [SerializeField] float yMaxRange;
    [SerializeField] float yRotation;
    [SerializeField] float xRotation;
    [SerializeField] GameObject explosion;
    //GameObject explosion;
    float xThrow, yThrow;
    bool explodes = false;


    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //explosion = GameObject.Find("Explosion");
        controlSpeed = 10f;
        tiltSpeed = 15.0f;
        xMinRange = -4f;
        xMaxRange = 4f;
        yMinRange = -3f;
        yMaxRange = 3f;
        yRotation = 0.0F;
        xRotation = 0.0F;
}

    void RotateY()
    {
        if (yThrow == 0 && (transform.localEulerAngles.x >= 1 || transform.localEulerAngles.x <= -1))
        { 

            if (yRotation >= -15.0f && yRotation <= 0.0f)
            {
                if(yRotation >= -2.0f && yRotation <= 0.0f)
                {
                    yRotation += 1f;
                }
                else
                {
                    yRotation += 2f;
                }
            }
            else if (yRotation <= 15.0f)
            {
                if (yRotation <= 2.0f)
                {
                    yRotation -= 1f;
                }
                else
                {
                    yRotation -= 2f;
                }
            }
        }
        else if (yThrow == 0)
        {
            yRotation = 0f;
        }
        yRotation += -yThrow * tiltSpeed * Time.deltaTime * 10;
        yRotation = Mathf.Clamp(yRotation, -15.0f, 15.0f);
    }

    private void RotateX()
    {
        if (xThrow == 0 && (transform.localEulerAngles.z >= 1 || transform.localEulerAngles.z <= -1))
        {

            if (xRotation >= -20.0f && xRotation <= 0.0f)
            {
                if (xRotation >= -2.0f && xRotation <= 0.0f)
                {
                    xRotation += 1f;
                }
                else
                {
                    xRotation += 2f;
                }
            }
            else if (xRotation <= 20.0f)
            {
                if (xRotation <= 2.0f)
                {
                    xRotation -= 1f;
                }
                else
                {
                    xRotation -= 2f;
                }
            }
        }
        else if (xThrow == 0)
        {
            xRotation = 0f;
        }
        xRotation += -xThrow * tiltSpeed * Time.deltaTime * 10;
        xRotation = Mathf.Clamp(xRotation, -18.0f, 20.0f);
    }

    // Update is called once per frame
    void Update()
    {

        currentPosition = transform.localPosition;
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        //print(xThrow);
        //print(yThrow);

        currentPosition.x += xThrow * controlSpeed * Time.deltaTime;
        currentPosition.y += yThrow * controlSpeed * Time.deltaTime;
        currentPosition = new Vector3( Mathf.Clamp(currentPosition.x, xMinRange, xMaxRange), Mathf.Clamp(currentPosition.y, yMinRange, yMaxRange), transform.localPosition.z);
        yRotation = Mathf.Clamp(yRotation, -15.0f, 15.0f);
        xRotation = Mathf.Clamp(xRotation, -18.0f, 20.0f);

        RotateY();
        RotateX();

        transform.localEulerAngles = new Vector3(Mathf.Clamp(yRotation, -15.0f, 30.0f), 0, Mathf.Clamp(xRotation, -20.0f, 20.0f));

        if (transform.localEulerAngles.z >= 4 || transform.localEulerAngles.z <= -4 || transform.localEulerAngles.x >= 4 || transform.localEulerAngles.x <= -4 )
            transform.localPosition = currentPosition;

    }

     void OnTriggerEnter(Collider col)
    {
        Debug.Log("Hit!");
        //explosion.SetActive(true);
        if (!explodes)
        {
            explodes = true;
            audioSource.Play();
            explosion = Instantiate(explosion, transform.position, Quaternion.identity);    
        }
        StartCoroutine(restart());
    }

    IEnumerator restart()
    {
        explodes = false;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("level1");
    }

}