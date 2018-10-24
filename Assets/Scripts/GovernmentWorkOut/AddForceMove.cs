using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceMove : MonoBehaviour {
    public float forceMult;
    Rigidbody rb;
    float screenHalfWidthInWorldUnits;

    float secondsCounter = 0;
    float secondsToCount = 2;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }
    
	// Update is called once per frame
	 void FixedUpdate() {

        secondsCounter += Time.deltaTime;
        if (secondsCounter >= secondsToCount)
        {
            secondsCounter = 0;
            forceMult = 10f;
        }
     
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;
        rb.AddForce(forceMult * Time.deltaTime , 0, 0, ForceMode.Impulse);

        //if (transform.position.x < -screenHalfWidthInWorldUnits)
        //{

        //  transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);

        //}

        //        if (transform.position.x > screenHalfWidthInWorldUnits)
        //      {
        //        transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);

        //  }
    }

}
