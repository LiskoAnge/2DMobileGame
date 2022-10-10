using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    //how fast the background is scrolled
    public float scrollSpeed = 1f;

    // To scroll the background smoothly
    public float offsetScroll;

    // Initial position of the background
    Vector2 initPos;

    //the background's new position
    float newPos;


    void Start()
    {
        // Getting the initial position of background
        initPos = transform.position;
    }



    void Update()
    {
        //New position of background based on its offset
        newPos = Mathf.Repeat(Time.time * -scrollSpeed, offsetScroll);

        //establish the new position
        transform.position = initPos + Vector2.up * newPos;
    }

}