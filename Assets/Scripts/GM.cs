using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public float timer = 2;

    public Vector3 spawnPosition;

    public Vector3 bulletPos;
    //public Vector3 spawnRotation;


    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            SpawnObject();
            SpawnSmallObject();
        }
    }

    public void SpawnObject()
    {
        GameObject bigAsteroid = ObjectPool.sharedInstance.GetPooledObject("Asteroid");

        if (bigAsteroid != null)
        {
            spawnPosition = new Vector3(Random.Range(-2.2F, 2.2F), Random.Range(5F, 5.1F), 0);
            //Debug.Log(spawnPosition);
            bigAsteroid.transform.position = spawnPosition;
            //bigAsteroid.transform.rotation = spawnRotation;
            bigAsteroid.SetActive(true);
            timer = 7;
        }
    }

    public void SpawnSmallObject()
    {
        GameObject smallAsteroid = ObjectPool.sharedInstance.GetPooledObject("smallAsteroid");

        if (smallAsteroid != null)
        {
            spawnPosition = new Vector3(Random.Range(-2.2F, 2.2F), Random.Range(5F, 5.1F), 0);
            smallAsteroid.transform.position = spawnPosition;
            //bigAsteroid.transform.rotation = spawnRotation;
            smallAsteroid.SetActive(true);
            timer = 3;
        }
    } 

    /*
     * var SpawnObject : GameObject;
var SpawnPoint : GameObject;

var NextSpawnTime : float = 0;
var MinSpawnTime : float =0;
var MaxSpawnTime : float =0;

function SetTimer()
{
    this.NextSpawnTime = Random.Range(this.MinSpawnTime, this.MaxSpawnTime);
}

function Start ()
{
    //initialise the spawn counter at startup
    this.SetTimer();
}

function Update () 
{
    this.NextSpawnTime -= Time.deltaTime;
    if(this.NextSpawnTime <= 0)
    {
          Instantiate(this.SpawnObject, this.SpawnPoint.transform.position, this.SpawnPoint.transform.rotation );
          this.SetTimer();
    }    
}
    */

}
