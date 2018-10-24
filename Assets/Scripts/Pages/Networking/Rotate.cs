using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    // Use this for initialization
    float timer = 0f;
    float rotation = 1f, posx = 1f;
    float multiply = 1f;
    void Start()
    {
        if (this.transform.localRotation.z < 0f)
        {
            multiply = -1f;
        }


    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(0f, 0f, transform.localRotation.x + (multiply * rotation));
        rotation += 1;
    }
}
