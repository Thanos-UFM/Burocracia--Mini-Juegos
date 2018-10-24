using System.Collections;
using System.Collections.Generic;
using Scripts.Data;
using UnityEngine;

public class MoveHorizontaly : MonoBehaviour {
    float timer = 0f;
    bool moveToRight = false;
    // Use this for initialization
    void Start () {
        if (this.gameObject.transform.localPosition.x < 0)
            moveToRight = true;
    }


    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
     
        if (moveToRight)
        {
            transform.localPosition = new Vector3(transform.localPosition.x + 0.005f, transform.localPosition.y, transform.localPosition.z);
        }
        else {
            transform.localPosition = new Vector3(transform.localPosition.x - 0.005f, transform.localPosition.y, transform.localPosition.z);
        }

    }
}
