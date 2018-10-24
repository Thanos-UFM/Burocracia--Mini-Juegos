using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {
    public float speed = 0.5f;
    public Renderer rend;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    Vector2 offset = new Vector2(Time.time * speed,0);
        rend.material.mainTextureOffset = offset;

       
}
}
