using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jump : MonoBehaviour {

    [Range(1, 10)]
    public float jumpVelocity;
    Animator animator;
    public bool isGrounded;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    Rigidbody2D rigidBody;    

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();

        var introTextGo = GameObject.Find("IntroText").GetComponent<Text>();
        var introTextGoTitle = GameObject.Find("Title").GetComponent<Text>();
        if (PlayerPrefs.GetInt("Lvl").Equals(1))
        {
            introTextGoTitle.text = "JUMP";
        }
        else
        {
            introTextGoTitle.text = "JUMP FASTER";
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
        //textItem.text = "Sin ocurrencia";

        if (isGrounded)
        {            
            //if (Input.GetButtonDown("Jump")) //TEST DESKTOP
            //{
            //    rigidBody.velocity = Vector2.up * jumpVelocity;
            //}            
            if (Input.GetMouseButtonDown(0))
            {                
                rigidBody.velocity = Vector2.up * jumpVelocity;
            }
        }        

        if (rigidBody.velocity.y < 0)
        {
            //textItem.text = "a primera fase";
            rigidBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        //else if (rigidBody.velocity.y > 0 && !Input.GetButton("Jump"))//TEST DESKTOP
        //{
        //    rigidBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        //}  
        else if (rigidBody.velocity.y > 0 && !Input.GetMouseButton(0))
        {
            rigidBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        
        if (coll.gameObject.CompareTag("Ground"))
        {            
            animator.SetFloat("Speed", -1.0f);
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {            
            animator.SetFloat("Speed", 1.0f);
            isGrounded = false;
        }
    }    
}
