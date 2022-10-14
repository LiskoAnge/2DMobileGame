using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    private ParticleSystem ps;
    public GameObject thisParticle;
    private float timer = 0.56f;

    private void Start()
    {
    ps = GetComponent<ParticleSystem>();

        if (!ps.isPlaying)
        {
            ps.Play();
        }
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            StartCoroutine(DestroyParticle());
        }
    }

    IEnumerator DestroyParticle()
    {
        yield return new WaitForSeconds(.30f);
        timer = 0.56f;
        thisParticle.SetActive(false);
    }
}


/*
private void OnTriggerEnter2D(Collider2D collision)
{
    StartCoroutine("DestroyParticle");
} */