using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTradeBarriers : MonoBehaviour {    
    public GameObject[] obstacles;
   
    private int randomObstacle;
    private int spawnObject;
    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    private float minTime = 0.65f;
    Collider2D collider;
    // Update is called once per frame    
    void FixedUpdate () {
        
        randomObstacle = UnityEngine.Random.Range(0, 4);
        spawnObject = UnityEngine.Random.Range(0, 2);       

        if (timeBtwSpawn <= 0 && spawnObject==1)
        {            
            GameObject newObstacle = Instantiate(obstacles[randomObstacle], obstacles[randomObstacle].transform.position, Quaternion.identity);
            collider = newObstacle.AddComponent<BoxCollider2D>();
            collider.isTrigger = true;
            newObstacle.AddComponent<Obstacle>();                                  
            timeBtwSpawn = startTimeBtwSpawn;
            //startTimeBtwSpawn -= decreaseTime;

            //if (startTimeBtwSpawn > minTime) {
            //    startTimeBtwSpawn -= decreaseTime;
            //}
        }
        else {
            timeBtwSpawn -= Time.deltaTime;
        }	
	}
}
