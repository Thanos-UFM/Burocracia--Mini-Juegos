using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDestroy : MonoBehaviour {    
    string OBJECT_NAME = "Coin(Clone)";

    void OnTriggerEnter2D(Collider2D collisionObject)
    {        
        if (collisionObject.name == OBJECT_NAME)
        {            
            Destroy(collisionObject.gameObject);
        }

    }
}
