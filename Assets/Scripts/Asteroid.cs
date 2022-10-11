using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private float obstSpeed = 1;
    private float rotationSpeed = 27f;
    public int hitToDestroy = 3;
    private int currentNumHit;

    Rigidbody2D rb;
    Animator ani;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        rb.velocity = new Vector2(0f, -obstSpeed);
        //moving obstacle towards player on the y axis


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
            //FindObjectOfType<SoundManager>().ExplosionSound();  not sure i want sound here 

            if (currentNumHit >= hitToDestroy)
            {
                StartCoroutine("DestroyAsteroid");
                //ani.SetTrigger("obstExplosion");
                //FindObjectOfType<SoundManager>().ExplosionSound();
                //Destroy(gameObject, 0.48f);

            }
        }
    }

    IEnumerator DestroyAsteroid()
    {
        ani.SetTrigger("asteroidExploded");
        FindObjectOfType<SoundManager>().AsteroidExplosion();
        yield return new WaitForSeconds(0.56f);
        gameObject.SetActive(false);
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