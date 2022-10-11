using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallAsteroid : MonoBehaviour
{
    private float obstSpeed = 1;
    private float rotationSpeed = 27f;

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
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("BottomScreen"))
        {
            gameObject.SetActive(false);
        }
        if (other.gameObject.tag.Equals("Bullet"))
        {
            StartCoroutine("DestroySmAsteroid");
        }
    }

    IEnumerator DestroySmAsteroid()
    {
        ani.SetTrigger("asteroidExploded");
        FindObjectOfType<SoundManager>().AsteroidExplosion();
        yield return new WaitForSeconds(0.56f);
        gameObject.SetActive(false);
    }
}