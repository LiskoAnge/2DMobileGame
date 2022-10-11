using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBckg : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 0, 20 * Time.deltaTime); //rotating 20 degree per second on the z axis
    }
}
