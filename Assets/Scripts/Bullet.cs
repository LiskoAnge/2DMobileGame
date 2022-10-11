using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    //private Animator anim;
    public Vector3 bulPos;

    private void Start()
    {
        bulPos = new Vector3(0, 0, 0);
        //anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(0, speed);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        bulPos = col.transform.position;
        GameObject psBullet = ObjectPool.sharedInstance.GetPooledObject("psBullet");

        if (psBullet != null)
        {
            psBullet.transform.position = bulPos;
            //FindObjectOfType<SoundManager>().BulletSound();
            psBullet.SetActive(true);
            bulPos = new Vector3(0, 0, 0);

        }
        gameObject.SetActive(false);
    }

}