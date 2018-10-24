using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacle : MonoBehaviour {     

    void OnTriggerEnter2D(Collider2D collisionObject)
    {
        
        if (collisionObject.tag == "Obstacle")
        {            
            Destroy(collisionObject.gameObject);            
        }

    }
}
