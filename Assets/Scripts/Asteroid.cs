using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private float obstSpeed = 1;
    private float rotationSpeed = 27f;
    private int hitToDestroy = 2;
    private int currentNumHit;

    public Vector3 astPos;

    Rigidbody2D rb;
    CircleCollider2D cObst;

    void Start()
    {
        cObst = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(0f, -obstSpeed);
        //moving obstacle towards player in the y axis


        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        //slowly rotate obstacle on the z axis whilst coming towards player
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("BottomScreen"))
        {
            gameObject.SetActive(false);
            //Debug.Log("Asteroid destroyed because off screen");
        }
        if (other.gameObject.tag.Equals("Bullet"))
        {
            currentNumHit++;
            //Debug.Log(currentNumHit);
            FindObjectOfType<SoundManager>().AsteroidExplosion();

            if (currentNumHit >= hitToDestroy)
            {
                astPos = other.transform.position;
                GameObject psAsteroid = ObjectPool.sharedInstance.GetPooledObject("psAsteroid");

                if (psAsteroid != null)
                {
                    psAsteroid.transform.position = astPos;
                    FindObjectOfType<SoundManager>().AsteroidExplosion();
                    psAsteroid.SetActive(true);
                    astPos = new Vector3(0, 0, 0);
                }
                gameObject.SetActive(false);
                currentNumHit = 0;

                //ani.SetTrigger("obstExplosion");
                //FindObjectOfType<SoundManager>().ExplosionSound();
                //Destroy(gameObject, 0.48f);

            }
        }
    }

    /*
    if (other.gameObject.tag.Equals("tBullet"))
    {
        //cObst.enabled = !cObst.enabled;
        cObst.enabled = false;
        //Debug.Log("Collider.enabled = " + cObst.enabled);
        ani.SetTrigger("obstExplosion");
        FindObjectOfType<SoundManager>().ExplosionSound();
        Destroy(gameObject, 0.48f);
    }

    if (other.gameObject.tag.Equals("tPlayer"))
    {
        ani.SetTrigger("obstExplosion");
        FindObjectOfType<SoundManager>().ExplosionSound();
        Destroy(gameObject, 0.48f);
    } */

}