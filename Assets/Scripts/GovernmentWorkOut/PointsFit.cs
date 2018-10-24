using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsFit : MonoBehaviour
{

    public GameObject CharacterBody;
    public GameObject FitPoint;
    public Vector3 secondsBetweenSpawnsMinMax;
    float nextSpawnTime;
    public float difficulty = 1f;

    public Vector3 spawnSizeMinMax;
    public float spawnAngleMax;
 
 
    void Start()
    {
        if (PlayerPrefs.GetInt("Lvl").Equals(0))
        {
            PlayerPrefs.SetInt("Lvl", 1);
        }
     
        difficulty = PlayerPrefs.GetInt("Lvl");
        
    }

    // Update is called once per frame
    void Update()
    {

        var Distanciax = CharacterBody.GetComponent<BoxCollider>().bounds.size.x / 2;
        var Distanciay = CharacterBody.GetComponent<BoxCollider>().bounds.size.y / 2;


        

        var localPositionx = CharacterBody.transform.localPosition.x;
        var localPositiony = CharacterBody.transform.localPosition.y;




        if (Time.time > nextSpawnTime)
        {
            float secondsBetweenSpawns = 1f - (difficulty * 0.090f);
          //  float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent());
            nextSpawnTime = Time.time + secondsBetweenSpawns;

            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);

            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
            Vector3 spawnPosition = new Vector3(Random.Range(- Distanciax + localPositionx , Distanciax + localPositionx), Random.Range(-Distanciay +localPositiony, Distanciay+localPositiony) , -2.52f);
            
            GameObject newBlock = (GameObject)Instantiate(FitPoint, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
            newBlock.transform.localScale =  Vector3.one * spawnSize;
        }

       



    }

}
