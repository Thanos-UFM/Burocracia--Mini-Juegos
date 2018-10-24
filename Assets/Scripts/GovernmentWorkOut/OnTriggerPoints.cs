using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerPoints : MonoBehaviour {
    

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "CircleFit")
        {
            Destroy(this.gameObject);

        }

    }
}
