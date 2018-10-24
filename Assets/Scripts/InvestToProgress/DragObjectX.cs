using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class DragObjectX : MonoBehaviour {

    public GameObject gameObjectToDrag;
   // public Rigidbody2D coin;
    public int moveSpeedCoin;   

    public Vector3 GOcenter;
    public Vector3 touchPosition;
    public Vector3 offset;
    public Vector3 newGOCenter;

    RaycastHit2D hit;

    public bool draggingMode = false;

	// Use this for initialization
	void Start () {
        //CollisionDestroy collisionDestroy = new CollisionDestroy(gameObject);
    }
	
	// Update is called once per frame
	void FixedUpdate () {        
        movingMoneyPot();
    }

    private void movingMoneyPot() {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            hit = Physics2D.Raycast(ray.origin, ray.direction);            
            if (hit.collider != null)
            {
                gameObjectToDrag = hit.collider.gameObject;
                GOcenter = gameObjectToDrag.transform.position;
                touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                offset = touchPosition - GOcenter;
                draggingMode = true;                
            }
        }

        if (Input.GetMouseButton(0))
        {            
            if (draggingMode)
            {
                touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                newGOCenter = touchPosition - offset;
                gameObjectToDrag.transform.position = new Vector3(newGOCenter.x, gameObjectToDrag.transform.position.y, GOcenter.z);

            }
        }

      /*  if (Input.GetMouseButtonUp(0))
        {
            draggingMode = false;           
            Rigidbody2D newCoin = (Rigidbody2D)Instantiate(coin);
            Debug.Log(newCoin.name);
            newCoin.transform.position = gameObjectToDrag.transform.position;
            newCoin.velocity = transform.up * moveSpeedCoin;
        }*/
#endif
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                hit = Physics2D.Raycast(ray.origin, ray.direction);                
                if (hit.collider != null)
                {
                    gameObjectToDrag = hit.collider.gameObject;
                    GOcenter = gameObjectToDrag.transform.position;
                    touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    offset = touchPosition - GOcenter;
                    draggingMode = true;                    
                }
            }

            if (touch.phase == TouchPhase.Moved)
            {
                if (draggingMode)
                {
                    touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    newGOCenter = touchPosition - offset;
                    gameObjectToDrag.transform.position = new Vector3(newGOCenter.x, gameObjectToDrag.transform.position.y, GOcenter.z);

                }
            }

         /*  if (touch.phase == TouchPhase.Ended)
            {
                draggingMode = false;
                Rigidbody2D newCoin = (Rigidbody2D)Instantiate(coin);               
                newCoin.transform.position = gameObjectToDrag.transform.position;
                newCoin.velocity = transform.up * moveSpeedCoin;
            }*/
        }
    }
}
