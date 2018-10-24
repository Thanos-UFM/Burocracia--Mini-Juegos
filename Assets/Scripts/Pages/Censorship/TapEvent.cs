using UnityEngine;
using System.Collections;
using Scripts.MyLibs;

public class TapEvent : MonoBehaviour
{
	public Camera cam;
	public float speed = 0.1F;
	void Update()
	{
		#if UNITY_EDITOR
		if(Input.GetMouseButtonDown(0)){

			GameObject objectHit =  MyHelpers.getRaycastedGameObject(new Vector3( Input.mousePosition.x, Input.mousePosition.y,1f),cam);
			if (objectHit != null ) {
				MyHandClass hand = objectHit.GetComponent<MyHandClass>();
				if (hand != null) {
					hand.OnSwipe ();
				}
			}
		}
		#endif
	}
}