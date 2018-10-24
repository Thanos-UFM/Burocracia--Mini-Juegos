using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver2 : MonoBehaviour {

	public GameObject CanvasFinal;


	void Start () {
		CanvasFinal.SetActive(false);
	}


    void OnTriggerStay(Collider baseCollider)
    {
        if (baseCollider.tag == "LadrillosFall")
        {
            baseCollider.tag = "DestroyLadrillos";
        }

    }
}
