using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 10f;
    private Rigidbody2D rb;
    //private Animator anim;

    private void Start()
    {
        //anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(0, speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("TopScreen"))
        {
            StartCoroutine("DestroyBullet");
        } 
    }

    IEnumerator DestroyBullet()
    {

        //anim.SetTrigger("bulletExplodes");
        yield return new WaitForSeconds(0.10f);
        gameObject.SetActive(false);

    }
}