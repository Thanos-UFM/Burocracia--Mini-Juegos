using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectXYInvestment : MonoBehaviour {
    public GameObject gameObject;
    public Rigidbody2D coin;
    public int moveSpeedCoin;

    public float moveSpeed;
    public Transform currentPoint;
    public Transform[] points;
    public int pointSelection;
    private bool armMovingY = false;
    private bool armStartMovingY = false;    
    // Use this for initialization
    void Start () {
        currentPoint = points[pointSelection];
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);
        moveObject(gameObject);        
    }

    private void moveObject(GameObject gameObject)
    {       
        int changeDirection = UnityEngine.Random.Range(0, 50);
        int throwCoin = UnityEngine.Random.Range(0, 20);

        if (changeDirection == 1)
        {
            if (pointSelection == 1)
            {
                pointSelection = 0;
            }
            else if (pointSelection == 0) {
                pointSelection = 1;
            }

            currentPoint = points[pointSelection];
        }
        else
        {
            moveObjectX(gameObject);
        }

        if (throwCoin == 1) {
            Debug.Log("Salio del cochito una cagadita de oro");
            Rigidbody2D newCoin = (Rigidbody2D)Instantiate(coin);
            newCoin.transform.position = gameObject.transform.position;
            newCoin.velocity = -transform.up * moveSpeedCoin;
        }
    }

    private void moveObjectX(GameObject gameObject)
    {
        if (gameObject.transform.position == currentPoint.position)
        {

            if (pointSelection == 0)
            {
                pointSelection = 1;

            }

            else if (pointSelection == 1)
            {
                pointSelection = 0;
            }

            currentPoint = points[pointSelection];
        }
    }
}
