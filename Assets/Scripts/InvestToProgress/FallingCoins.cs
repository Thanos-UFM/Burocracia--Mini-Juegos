using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCoins : MonoBehaviour {

	public Vector2 speedMinMax;
	public float speed;
	public float tamano;
	public float tamanopositiony;

	float visibleHeightThreshold;

	void Start(){
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, 0);
		visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
		tamano = visibleHeightThreshold;
			tamanopositiony = transform.position.y;
	}

	void Update () {
		transform.Translate (Vector3.down * speed * Time.deltaTime , Space.Self);

        if (transform.position.y < visibleHeightThreshold)
			Destroy (gameObject);
	}

}
