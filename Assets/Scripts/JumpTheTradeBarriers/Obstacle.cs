using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    float speed = 2;	
		
	void FixedUpdate () {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
