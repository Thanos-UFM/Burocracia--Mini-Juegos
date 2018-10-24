using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.MyLibs;
using UnityEngine.UI;

public class TapEventAction : MonoBehaviour
{

    public Camera cam;
    public GameObject CharacterbodyFat;
    RaycastHit hit;
    float difficulty = 1f;


    void Start()
    {

        var introTextGo = GameObject.Find("IntroText").GetComponent<Text>();
        var introTextGoTitle = GameObject.Find("Title").GetComponent<Text>();
        if (PlayerPrefs.GetInt("Lvl").Equals(1))
        {
            introTextGoTitle.text = "TAP POINTS";
        }
        else
        {
            introTextGoTitle.text = "TAP FASTER";
        }
        iTween.MoveTo(introTextGo.gameObject, iTween.Hash(
            "x", -125f,
            "time", 0.6f,
            "oncomplete", "OnCompleteShowInstructions",
            "oncompletetarget", gameObject,
            "oncompleteparams", introTextGo.gameObject,
            "easetype", iTween.EaseType.easeInBounce,
            "islocal", true
        ));


        cam = Camera.main;
        if (PlayerPrefs.GetInt("Lvl").Equals(0))
        {
            PlayerPrefs.SetInt("Lvl", 1);
        }
        difficulty = PlayerPrefs.GetInt("Lvl");
        Debug.Log("PlayerPrefs DEL JUEGO " + PlayerPrefs.GetInt("Lvl"));
    }


    void OnCompleteShowInstructions(GameObject obj)
    {
        iTween.MoveTo(obj, iTween.Hash(
           "x", obj.transform.localPosition.x,
           "time", 1.4f,
           "oncomplete", "OnCompleteInstructions",
           "oncompletetarget", gameObject,
           "oncompleteparams", obj,
           "easetype", iTween.EaseType.easeInOutCubic,
           "islocal", true
        ));
    }
    void OnCompleteInstructions(GameObject obj)
    {
        iTween.MoveTo(obj, iTween.Hash(
        "x", -380f,
        "time", 0.5f,
        "oncomplete", "OnCompleteInstructions",
        "oncompletetarget", gameObject,
        "oncompleteparams", obj,
        "easetype", iTween.EaseType.easeInOutCubic,
        "islocal", true
    ));
    }

    void Update()
    {
        var speedBodyIncrement = (difficulty / 10);
        Debug.Log("Incremente de crecimiento  " + speedBodyIncrement);
        CharacterbodyFat.transform.localScale = new Vector3(CharacterbodyFat.transform.localScale.x + (0.5f + speedBodyIncrement) * Time.deltaTime, CharacterbodyFat.transform.localScale.y, CharacterbodyFat.transform.localScale.z);
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0))
        {
            
            var mousWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);
            var pos = new Vector3(mousWorldPos.x, mousWorldPos.y, this.transform.position.z);

            GameObject objectHit = MyHelpers.getRaycastedGameObject(new Vector3(Input.mousePosition.x, Input.mousePosition.y, this.transform.position.z), cam);

            if (objectHit != null)
            {

                if (objectHit.name.Equals("circle(Clone)"))
                {
                    Destroy(objectHit);
                    if (CharacterbodyFat.transform.localScale.x >= 2.575463f)
                    {
                        CharacterbodyFat.transform.localScale = new Vector3(CharacterbodyFat.transform.localScale.x - 0.5f, 5, 5);
                    }

                }

            }

        }


    }

}
