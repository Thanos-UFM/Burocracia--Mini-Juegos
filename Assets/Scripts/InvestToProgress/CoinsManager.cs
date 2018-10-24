using UnityEngine;
using System.Collections;

public class CoinsManager : MonoBehaviour {
	
	public GameObject fallingBlockPrefab;
	public Vector3 secondsBetweenSpawnsMinMax;
	float nextSpawnTime;
    public float difficulty = 1f;


    public Vector3 spawnSizeMinMax;
	public float spawnAngleMax;

	Vector2 screenHalfSizeWorldUnits;

	// Use this for initialization
	void Start () {
        
        if (PlayerPrefs.GetInt("Lvl").Equals(0))
        {
            PlayerPrefs.SetInt("Lvl", 1);
        }
        Debug.Log("PlayerPrefs DEL JUEGO " + PlayerPrefs.GetInt("Lvl"));
        screenHalfSizeWorldUnits = new Vector3 (Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
        difficulty = PlayerPrefs.GetInt("Lvl");
        Debug.Log("DIFICULTAD " + difficulty);
    }

	// Update is called once per frame
	void Update () {

		if (Time.time > nextSpawnTime) {
            float secondsBetweenSpawns = 1/difficulty;
            //float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x,Difficulty.GetDifficultyPercent());
          
            nextSpawnTime = Time.time + secondsBetweenSpawns;
           
            float spawnAngle = Random.Range (-spawnAngleMax, spawnAngleMax);
			float spawnSize = Random.Range (spawnSizeMinMax.x, spawnSizeMinMax.y);
			Vector3 spawnPosition = new Vector3 (Random.Range (-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize);
			GameObject newBlock = (GameObject) Instantiate (fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
			newBlock.transform.localScale = Vector3.one * spawnSize;

		}
			

	}




}