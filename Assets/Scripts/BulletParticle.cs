using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParticle : MonoBehaviour
{
    private ParticleSystem ps;
    public GameObject thisParticle;

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();

        if (!ps.isPlaying)
        {
            ps.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine("DestroyParticle");
    }

    IEnumerator DestroyParticle()
    {
        yield return new WaitForSeconds(.55f);
        thisParticle.SetActive(false);
    }
}
