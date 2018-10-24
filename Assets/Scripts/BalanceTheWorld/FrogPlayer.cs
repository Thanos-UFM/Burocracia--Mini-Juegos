using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogPlayer : MonoBehaviour {
	public GameObject CanvasFinal;
	//public GameObject PanelFinalScore;
	//public GameObject ButtonReset;

	public float speed = 7;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		CanvasFinal.SetActive(false);

		float inputX = Input.GetAxisRaw ("Horizontal");
		float velocity = inputX * speed;
		transform.Translate (Vector2.right * velocity * Time.deltaTime);



	}

	void OnTriggerEnter(Collider other){
		Debug.Log ("-------------Se ha golpeado a la Rana-----------");
		Destroy (gameObject);
		CanvasFinal.SetActive(true);
		//if(triggerCollider.tag == "Falling Rock"){
		//	Destroy (gameObject);
		//}

	}
}
