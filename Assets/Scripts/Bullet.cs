using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    private Animator anim;


    private void Start()
    {
        speed = 10;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(0, speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine("BulletHit");
    }

    IEnumerator BulletHit()
    {
        speed = 0;
        anim.SetTrigger("bulletHit");
        yield return new WaitForSeconds(.20f);
        speed = 10;
        gameObject.SetActive(false);
    }
}