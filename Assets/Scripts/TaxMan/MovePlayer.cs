using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour {

    public GameObject character;
    public Animator animator;
    private float ScreenWidth;
    CapsuleCollider2D collider;    

    // Use this for initialization
    void Start () {
        ScreenWidth = Screen.width;
        collider = character.AddComponent<CapsuleCollider2D>();        
        collider.isTrigger = true;

        var introTextGo = GameObject.Find("IntroText").GetComponent<Text>();
        var introTextGoTitle = GameObject.Find("Title").GetComponent<Text>();
        if (PlayerPrefs.GetInt("Lvl").Equals(1))
        {
            introTextGoTitle.text = "MOVE";
        }
        else
        {
            introTextGoTitle.text = "MOVE FASTER";
        }
        var introTextGoSubTitle = GameObject.Find("Subtitle").GetComponent<Text>();
        introTextGoSubTitle.text = "To avoid";
        iTween.MoveTo(introTextGo.gameObject, iTween.Hash(
            "x", -145f,
            "time", 0.6f,
            "oncomplete", "OnCompleteShowInstructions",
            "oncompletetarget", gameObject,
            "oncompleteparams", introTextGo.gameObject,
            "easetype", iTween.EaseType.easeInBounce,
            "islocal", true
        ));
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
                "x", -355f,
                "time", 0.5f,
                "oncomplete", "OnCompleteInstructions",
                "oncompletetarget", gameObject,
                "oncompleteparams", obj,
                "easetype", iTween.EaseType.easeInOutCubic,
                "islocal", true
          ));

    }
    // Update is called once per frame
    void FixedUpdate () {
        float horizontalInput = 0;
        collider.offset = new Vector2(0,1.7f);
        collider.size = new Vector2(2.5f,5f);
        animator.SetFloat("Speed", horizontalInput);
        
#if UNITY_EDITOR
        horizontalInput = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", horizontalInput);

        if (horizontalInput < 0) {
            collider.offset = new Vector2(-3.5f, 0.7f);
            collider.size = new Vector2(2.5f, 5f);
        }

        if (horizontalInput > 0) {
            collider.offset = new Vector2(3.5f, 0.7f);
            collider.size = new Vector2(2.5f, 5f);
        }
#endif

        if (Input.GetTouch((int)horizontalInput).position.x > ScreenWidth / 2)
        {
            //Movement right
            animator.SetFloat("Speed", 1.0f);
            collider.offset = new Vector2(3.5f, 0.7f);
            collider.size = new Vector2(2.5f, 5f);
        }

        if (Input.GetTouch((int)horizontalInput).position.x < ScreenWidth / 2)
        {
            //Movement left
            animator.SetFloat("Speed", -1.0f);
            collider.offset = new Vector2(-3.5f, 0.7f);
            collider.size = new Vector2(2.5f, 5f);
        }

    }
}
