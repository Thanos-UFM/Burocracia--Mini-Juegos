using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveElements : MonoBehaviour {
	public float speed = 7;
	float screenHalfWidthInWorldUnits ;

    void Start(){
		screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;
	}

	void FixedUpdate() {
        //float inputXMoveLeft = 0;
		//float inputX = Input.GetAxisRaw ("Horizontal");
     
   //     if (inputX<0)
     //   {
       //     inputXMoveLeft = inputX;
        //}
    

		//float velocity = inputXMoveLeft * speed;
		//transform.Translate (Vector2.right * velocity * Time.deltaTime);
        
		if(transform.position.x < -screenHalfWidthInWorldUnits){
            
			transform.position = new Vector2 (screenHalfWidthInWorldUnits, transform.position.y);
		}

		if(transform.position.x > screenHalfWidthInWorldUnits){
			transform.position = new Vector2 (-screenHalfWidthInWorldUnits, transform.position.y);
		}
	}
}
