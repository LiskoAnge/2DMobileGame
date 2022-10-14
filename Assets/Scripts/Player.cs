using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletPos;
    public float timer = 1;

    private Animator anim;
    private Rigidbody2D rgbd;


    public GameObject gameOverPanel;
    public bool gameOver = false;



    void Start()
    {
        Physics.IgnoreLayerCollision(0, 17);   //ignore collision between player and bullet
        gameOverPanel.SetActive(false);
        rgbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Fire();
        }
        if(HealthBar.lifeBar == 0)
        {
            StartCoroutine("GameOver");
        }
    }

    public void Fire()
    {
        GameObject bullet = ObjectPool.sharedInstance.GetPooledObject("Bullet");

        if (bullet != null)
        {
            bullet.transform.position = bulletPos.position;
            FindObjectOfType<SoundManager>().BulletSound();
            bullet.SetActive(true);
            timer = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 10)
        {
            if (HealthBar.lifeBar >= 1)
            {
                StartCoroutine("PlayerHit");
            }
        }
    }

    IEnumerator PlayerHit()
    {
        Physics2D.IgnoreLayerCollision(7, 10, true);    //temporarily disable collision with enemies
        anim.SetBool("playerHit", true);
        FindObjectOfType<SoundManager>().PlayerExplosion();
        HealthBar.lifeBar += -1;    //decrease healthbar
        //Debug.Log(HealthBar.lifeBar);
        yield return new WaitForSeconds(1.5f);   //player is invincible for 1 sec
        Physics2D.IgnoreLayerCollision(7, 10, false);
        anim.SetBool("playerHit", false);

        //rgbd.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -10f), ForceMode2D.Impulse);  this only works with dynamic rigidbodies - player is atm kinematic but maybe I'll change it in a later stage
    }

    IEnumerator GameOver()
    {

        //game over bool to check for highscore in different function
        Physics2D.IgnoreLayerCollision(7, 10, true);
        gameOver = true;
        //Debug.Log("game over");//console message
        //parameter inside the animator met -> animation start
        //fire explosion animation
        anim.SetTrigger("playerDeath");
        //wait until the end of animation
        FindObjectOfType<SoundManager>().PlayerExplosion();
        yield return new WaitForSeconds(0.59f);
        //we can now destroy game object
        Destroy(gameObject);
        //game over text appears on screen
        gameOverPanel.SetActive(true);
    }
}

