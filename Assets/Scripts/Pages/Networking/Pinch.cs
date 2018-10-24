using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinch : MonoBehaviour {
    float timer = 0f;
    bool moveToRight = false;
    float originalPosx, movex;
    // Use this for initialization
    void Start () {
        originalPosx = this.gameObject.transform.localPosition.x;
        if (this.gameObject.transform.localPosition.x < 0)
            moveToRight = true;


        if (moveToRight)
        {
            movex = this.gameObject.transform.localPosition.x + this.gameObject.GetComponent<BoxCollider>().bounds.size.x / 2f;
        }
        else {
            movex = this.gameObject.transform.localPosition.x - this.gameObject.GetComponent<BoxCollider>().bounds.size.x / 2f;
        }
        StartAnimation();
    }
    void StartAnimation() {

        iTween.MoveTo(this.gameObject, iTween.Hash(
            "x", movex,
            "time", 1f,
            "oncomplete", "OnCompleteAnimation",
            "oncompletetarget", gameObject,

            "oncompleteparams", this.gameObject,
            "islocal", true
        ));
    }
    void OnCompleteAnimation() {
        iTween.MoveTo(this.gameObject, iTween.Hash(
        "x", originalPosx,
        "time", 1f,
        "oncomplete", "StartAnimation",
        "oncompletetarget", gameObject,

        "oncompleteparams", this.gameObject,
        "islocal", true
    ));
    }

}
