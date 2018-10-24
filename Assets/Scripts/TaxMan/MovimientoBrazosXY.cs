using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoBrazosXY : MonoBehaviour {
    public GameObject gameObject;    

    public Transform currentPoint;
    public Transform[] points;    
    public int pointSelection;
    private bool armMovingY = false;
    private bool armStartMovingY = false;   
    private int gameLvl;
    private float moveSpeed = 5f;

    // Use this for initialization
    void Start () {                
        currentPoint = points[pointSelection];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, currentPoint.position, Time.deltaTime * (moveSpeed + gameLvl));
        moveObjectY(gameObject);
    }

    private void moveObjectY(GameObject gameObject)
    {
        if (armMovingY == false && gameObject.transform.position == currentPoint.position)
        {
            int startMovingY = UnityEngine.Random.Range(0, 5);            
            if (startMovingY == 1)
            {
                armStartMovingY = true;
            }
            else
            {
                moveObjectX(gameObject);
            }
        }

        if (armStartMovingY == true)
        {
            armStartMovingY = false;
            armMovingY = true;

            if (pointSelection == 0) {
                pointSelection = 1;
            }
            else if (pointSelection == 2)
            {
                pointSelection = 3;
            }
            else if (pointSelection == 4)
            {
                pointSelection = 5;
            }

            currentPoint = points[pointSelection];            
        }

        if (armMovingY == true)
        {
            if (gameObject.transform.position == currentPoint.position)
            {
                if (pointSelection == 1)
                {
                    pointSelection = 0;
                    currentPoint = points[pointSelection];
                }
                else if(pointSelection == 3)
                {
                    pointSelection = 2;
                    currentPoint = points[pointSelection];
                }
                else if (pointSelection == 5)
                {
                    pointSelection = 4;
                    currentPoint = points[pointSelection];
                }

                else if (pointSelection == 0 || pointSelection == 2 || pointSelection == 4)
                {
                    moveObjectX(gameObject);
                    armMovingY = false;

                }
            }
        }


    }

    private void moveObjectX(GameObject gameObject)
    {
        int[] positionsX = { 0, 2, 4};

        if (gameObject.transform.position == currentPoint.position)
        {
            if (pointSelection == 0 || pointSelection == 2 || pointSelection == 4)
            {
                int x = UnityEngine.Random.Range(0, 3);
                pointSelection = positionsX[x];

            }

            currentPoint = points[pointSelection];
        }

    }
}
