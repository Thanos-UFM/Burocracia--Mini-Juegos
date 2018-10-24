using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCart : MonoBehaviour
{
    //public GameObject CanvasFinal;
    Rigidbody rb;
    float dirX;
    float moveSpeed = 10f;
    float screenHalfWidthInWorldUnits;
    float alturaObjeto;

    // Use this for initialization
    void Start()
    {
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;
        rb = GetComponent<Rigidbody>();
        alturaObjeto = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dirX = Input.acceleration.x * moveSpeed;
        //  transform.position = new Vector2(Mathf.Clamp(transform.position.x, -7.5f, 7.5f), transform.position.y);
        // rb.AddForce(dirX, 0, 0, ForceMode.Impulse);
        rb.velocity = new Vector2(dirX, 0f);



        if (transform.position.x < -screenHalfWidthInWorldUnits + 1f)
        {

            transform.position = new Vector2(-screenHalfWidthInWorldUnits + 1f, alturaObjeto);
        }

        if (transform.position.x > screenHalfWidthInWorldUnits - 1f)
        {

            transform.position = new Vector2(screenHalfWidthInWorldUnits - 1f, alturaObjeto);
        }

    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "DestroyLadrillos")
        {


            foreach (ContactPoint contact in collision.contacts)
            {
                FixedJoint fixedJoint = gameObject.AddComponent<FixedJoint>();
                fixedJoint.anchor = contact.point;
                fixedJoint.connectedBody = collision.rigidbody;
            }

        }
    }

}
