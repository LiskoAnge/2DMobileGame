using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParticle : MonoBehaviour
{
    private ParticleSystem ps;

    private void Start()
    {
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
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
}
