using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTranslateBF : MonoBehaviour {

    // Use this for initialization
    float timer = 0f;
    float rotation = 1f, posx = 1f;
    float multiply = 1f;
	void Start () {
        if (this.transform.localRotation.z < 0f)
        {
            multiply = -1.2f;
        }


    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer < 2)
        {
            //this.transform.localPosition = new Vector3(this.transform.localPosition.x + posx, this.transform.localPosition.y, this.transform.localPosition.z);
            transform.localPosition = new Vector3(transform.localPosition.x - 0.1f, transform.localPosition.y, transform.localPosition.z);
        }
        else if (timer >= 2 && timer <= 4)
        {
            transform.localPosition = new Vector3(transform.localPosition.x + 0.1f, transform.localPosition.y, transform.localPosition.z);
            //  this.transform.localPosition = new Vector3(this.transform.localPosition.x - posx, this.transform.localPosition.y, this.transform.localPosition.z);
        }
        else {
            timer = 0f;
        }
      // transform.Rotate(new Vector3(0f,0f,Time.deltaTime*45f));
      
        transform.localRotation = Quaternion.Euler(0f,0f, multiply* rotation);
        rotation += 1;
        posx++;
    }
}
