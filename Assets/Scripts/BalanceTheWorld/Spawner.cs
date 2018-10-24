using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {
	
	public GameObject fallingBlockPrefab;
	public Vector3 secondsBetweenSpawnsMinMax;
	float nextSpawnTime;
    public float difficulty = 1f;


    public Vector3 spawnSizeMinMax;
	public float spawnAngleMax;

	Vector2 screenHalfSizeWorldUnits;

	// Use this for initialization
	void Start () {

        var introTextGo = GameObject.Find("IntroText").GetComponent<Text>();
        var introTextGoTitle = GameObject.Find("Title").GetComponent<Text>();

        if (PlayerPrefs.GetInt("Lvl").Equals(1))
        {
            introTextGoTitle.text = "AVOID BLOCKS";
        }
        else
        {
            introTextGoTitle.text = "AVOID FASTER";
        }
        iTween.MoveTo(introTextGo.gameObject, iTween.Hash(
            "x", -125f,
            "time", 0.6f,
            "oncomplete", "OnCompleteShowInstructions",
            "oncompletetarget", gameObject,
            "oncompleteparams", introTextGo.gameObject,
            "easetype", iTween.EaseType.easeInBounce,
            "islocal", true
        ));

        if (PlayerPrefs.GetInt("Lvl").Equals(0))
        {
            PlayerPrefs.SetInt("Lvl", 1);
        }
        Debug.Log("PlayerPrefs DEL JUEGO " + PlayerPrefs.GetInt("Lvl"));
        screenHalfSizeWorldUnits = new Vector3 (Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
        difficulty = PlayerPrefs.GetInt("Lvl");
    }

    void OnCompleteShowInstructions(GameObject obj)
    {
        iTween.MoveTo(obj, iTween.Hash(
           "x", obj.transform.localPosition.x,
           "time", 1.4f,
           "oncomplete", "OnCompleteInstructions",
           "oncompletetarget", gameObject,
           "oncompleteparams", obj,
           "easetype", iTween.EaseType.easeInOutCubic,
           "islocal", true
        ));
    }
    void OnCompleteInstructions(GameObject obj)
    {
        iTween.MoveTo(obj, iTween.Hash(
        "x", -380f,
        "time", 0.5f,
        "oncomplete", "OnCompleteInstructions",
        "oncompletetarget", gameObject,
        "oncompleteparams", obj,
        "easetype", iTween.EaseType.easeInOutCubic,
        "islocal", true
    ));
    }

    // Update is called once per frame
    void Update () {

		if (Time.time > nextSpawnTime) {
            float secondsBetweenSpawns = 1f - (difficulty * 0.090f);
            //float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x,Difficulty.GetDifficultyPercent());
            nextSpawnTime = Time.time + secondsBetweenSpawns;

			float spawnAngle = Random.Range (-spawnAngleMax, spawnAngleMax);

			float spawnSize = Random.Range (spawnSizeMinMax.x, spawnSizeMinMax.y);
			Vector3 spawnPosition = new Vector3 (Random.Range (-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize);
			GameObject newBlock = (GameObject) Instantiate (fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));

            int[] positionsX = { 0, 90 };
            int x = UnityEngine.Random.Range(0, 2);
            int pointSelection = positionsX[x];

            if (pointSelection == 90)
            {
                newBlock.transform.localScale = new Vector3(1.5f, 0.8f, 1) * spawnSize;
            }
            else if (pointSelection == 0)
            {
                newBlock.transform.localScale = new Vector3(0.8f, 1.5f, 1) * spawnSize;
            }

        }
			

	}
}