using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gyroscope : MonoBehaviour
{
    Animator anim;

    Rigidbody2D rgbd;

    float axisX;

    public GameObject gameOverPanel;

    public GameObject shootButton;

    public GameObject canShootText;

    public GameObject enableUpgrades;

    public bool gameOver = false;
    public bool shieldIsActive;

    private float rocketSpeedTilt = 35;
    private float endOfExplosion = 0.59f;
    public float shieldTime = 3;

    void Start()
    {
        enableUpgrades.SetActive(false);
        shootButton.SetActive(false);
        canShootText.SetActive(false);
        gameOverPanel.SetActive(false);
        rgbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    //--------------------GYROSCOPE SYSTEM TO MOVE PLAYER BY TILTING DEVICE - NOT USED FOR NOW BUT COULD BE USEFUL ------------------//
    void Update()
    {
        //preventing the player from going off screen
        if (transform.position.x < -10)
        {
            Vector3 pos = transform.position;
            pos.x = -10;
            transform.position = pos;
        }
        if (transform.position.x > 10)
        {
            Vector3 pos = transform.position;
            pos.x = 10;
            transform.position = pos;
        }

        if(transform.position.z > 0)
        {
            Vector3 pos = transform.position;
            pos.z = 0;
            transform.position = pos;

        }

        if (transform.position.z < 0)
        {
            Vector3 pos = transform.position;
            pos.z = 0;
            transform.position = pos;

        }

        //adjusting the variables according to game's axis
        Vector3 dir = Vector3.zero;

        dir.x = Input.acceleration.x;

        dir.z = -Input.acceleration.y;


        if (dir.sqrMagnitude > 1)
        {
            dir.Normalize();
        }

        //moving 10 meters per second instead of 10 per frame
        dir *= Time.deltaTime;

        //move the game object
        transform.Translate(dir * rocketSpeedTilt);
    } 
}
