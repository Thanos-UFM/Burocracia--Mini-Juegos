using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.MyLibs;
using UnityEngine.SceneManagement;
using Scripts.Data;
using UnityEngine.UI;

public class MatrixPositionInfo {
    public float positionx { get; set; }
    public float positiony { get; set; }

    public bool isUsed { get; set; }
}
public class NetworkingMainScript : MonoBehaviour {

	int quantityOfHands = 8;
	float timer = 0f;
    [HideInInspector]
    public float myGameDifficulty = 1f;
    [HideInInspector]
    public float timeDivider = 1f;

    [HideInInspector]
	public int quantityOfFails = 0;
	[HideInInspector]
	public float score = 0f;
	[HideInInspector]
	public bool isPlaying = true;

	List<GameObject> handList = new List<GameObject>();

	UnityEngine.UI.Slider mySlider;
    MatrixPositionInfo[,] matrix = new MatrixPositionInfo[MATRIX_ROWS, MATRIX_COLUMNS];
    const int MATRIX_ROWS = 3;
    const int MATRIX_COLUMNS = 7;
    // Use this for initialization
    GameObject finalWinAnimation, finalLostAnimation;

    void Start () {

        finalWinAnimation = GameObject.Find("FinalWinAnimation");
        finalWinAnimation.SetActive(false);

        finalLostAnimation = GameObject.Find("FinalLostAnimation");
        finalLostAnimation.SetActive(false);


        if (PlayerPrefs.GetInt("Lvl").Equals(0))
        {
            PlayerPrefs.SetInt("Lvl", 1);
        }

        myGameDifficulty = (float)PlayerPrefs.GetInt("Lvl");
        timeDivider = 10f - (0.8f * myGameDifficulty);
        if (timeDivider < 5f)
            timeDivider = 5f;

        var introTextGo = GameObject.Find("IntroText").GetComponent<Text>();
        var introTextGoTitle = GameObject.Find("Title").GetComponent<Text>();
        if (PlayerPrefs.GetInt("Lvl").Equals(1))
        {
            introTextGoTitle.text = "MATCH";
        }
        else
        {
            introTextGoTitle.text = "MATCH FASTER";
        }

        var introTextGoSubTitle = GameObject.Find("Subtitle").GetComponent<Text>();
        introTextGoSubTitle.text = "To trade";
        iTween.MoveTo(introTextGo.gameObject, iTween.Hash(
            "x", -145f,
            "time", 0.6f,
            "oncomplete", "OnCompleteShowInstructions",
            "oncompletetarget", gameObject,
            "oncompleteparams", introTextGo.gameObject,
            "easetype", iTween.EaseType.easeInBounce,
            "islocal", true
        ));

        float rowSum = 0.45f, columnSum = -1.35f;

        for (int i = 0; i < MATRIX_ROWS; i++)
        {
       

            for (int j = 0; j < MATRIX_COLUMNS; j++)
            {
                var objInfo = new MatrixPositionInfo
                {
                    positionx = columnSum,
                    positiony = rowSum,
                    isUsed = false
                };
                matrix[i, j] = objInfo;
                columnSum += 0.45f;

    }
            rowSum -= 0.45f;
            columnSum = -1.35f;
        }

        drawObstacles();
        drawObstacles();

        mySlider = this.gameObject.GetComponentInChildren<UnityEngine.UI.Slider>();

	
	}
    public void drawObstacles() {
        for (int i = 0; i < MATRIX_ROWS; i++)
        {
            for (int j = 0; j < MATRIX_COLUMNS; j++)
            {
                var objInfo = matrix[i, j];
                if (!objInfo.isUsed)
                {
                    createAnObstacle(objInfo, i, j);
                }

            }
        }
    }
    public void createAnObstacle(MatrixPositionInfo objInfo, int i, int j) {
        var objectNum = 0;
        var positionRandom = UnityEngine.Random.Range(0f, 600f);
        var wichOne = UnityEngine.Random.Range(0f, 600f);

        if (myGameDifficulty % 15 ==0 || myGameDifficulty % 10 == 0)
        {
            objectNum = 0;
        }
        else {
            objectNum = positionRandom < 150 ? 0 : positionRandom >= 150f && positionRandom < 300f ? 1 : positionRandom >= 300f && positionRandom < 450f ? 2 : positionRandom >= 450f && positionRandom < 600f ? 3 : UnityEngine.Random.Range(0, 3);

       }
        switch (objectNum)
        {
            case 0: //generateCrosses
                generateCrosses(objInfo.positionx, objInfo.positiony);
                matrix[i, j].isUsed = true;
                break;
            case 1://generateHorizontalObstacles

                bool isOneUsed = false;
                float directionRandom = UnityEngine.Random.Range(0f, 600f);
                var direction = positionRandom < 150 ? true : positionRandom >= 150f && positionRandom < 300f ? false : positionRandom >= 300f && positionRandom < 450f ? true : positionRandom >= 450f && positionRandom < 600f ? false : true;

                for (int col = 0; col < MATRIX_COLUMNS; col++) //search for at least one used
                {
                    if (matrix[i, col].isUsed)
                    {
                        isOneUsed = true;
                    }

                }
                if (!isOneUsed)
                {
                    for (int col = 0; col < MATRIX_COLUMNS; col++) // Set all row to used
                    {
                        matrix[i, col].isUsed = true;
                    }

                    generateHorizontalObstacles(objInfo.positiony, direction);

                }
                break;
            case 2://pinch
                var howManyFails = 0;
                bool waPositioned = false;
                if (j - 1 >= 0)
                {
                    if (!matrix[i, j - 1].isUsed)
                    {

                        generatePinch(objInfo.positionx - 0.225f, objInfo.positiony);
                            matrix[i, j].isUsed = true;
                        matrix[i, j - 1].isUsed = true;

                        waPositioned = true;
                    }
                    else
                    {
                        howManyFails++;
                    }
                }
                else {
                    howManyFails++;
                }
                if (j + 1 < MATRIX_COLUMNS)
                {
                    if (!matrix[i, j + 1].isUsed)
                    {
                        if (!waPositioned) {

                            generatePinch(objInfo.positionx + 0.225f, objInfo.positiony);
                            matrix[i, j].isUsed = true;
                            matrix[i, j+1].isUsed = true;
                        }
                    }
                    else
                    {
                        howManyFails++;
                    }
                }
                else
                {
                    howManyFails++;
                }
             
                break;
            case 3://generateLinesBackAndForward
                bool isOneColUsed = false;
                for (int col = 0; col < MATRIX_COLUMNS; col++) //search for at least one used
                {
                    if (matrix[i, col].isUsed)
                    {
                        isOneColUsed = true;
                    }
                }
                if (!isOneColUsed)
                {
                    for (int col = 0; col < MATRIX_COLUMNS; col++) // Set all row to used
                    {
                        matrix[i, col].isUsed = true;
                    }
                    generateLinesBackAndForward(-0.6f, objInfo.positiony, true);
                    matrix[i, j].isUsed = true;

                }
                break;
        }
    }
    public void generatePinch(float posx, float posy)
    {
        GameObject obstacle5Prefab = Resources.Load<GameObject>("Prefab/Networking/Obstacle5");


        var obstacle5 = Instantiate(obstacle5Prefab, new Vector3(posx, posy, 0.1f), Quaternion.Euler(0f, 0f,0f));
        obstacle5.transform.parent = this.transform;

    }
    public void generateCrosses(float posx, float posy)
    {
        GameObject obstacle4Prefab = Resources.Load<GameObject>("Prefab/Networking/Obstacle4");


        var obstacle4 = Instantiate(obstacle4Prefab, new Vector3(posx, posy, 0.1f), Quaternion.Euler(0f,0f,-10f));
        obstacle4.transform.parent = this.transform;

    }
    public void generateLinesBackAndForward(float posx, float posy, bool moveToRight)
    {
        if (moveToRight)
        {
            GameObject obstacle1Prefab = Resources.Load<GameObject>("Prefab/Networking/Obstacle1");
            var obstacle1 = Instantiate(obstacle1Prefab, new Vector3(posx, posy, 0.1f), Quaternion.identity);
            obstacle1.transform.parent = this.transform;
        }
        else {
            GameObject obstacle2Prefab = Resources.Load<GameObject>("Prefab/Networking/Obstacle2");
            var obstacle2 = Instantiate(obstacle2Prefab, new Vector3(posx, posy, 0.1f), Quaternion.identity);
            obstacle2.transform.parent = this.transform;
        }


   
    }

    public void generateHorizontalObstacles(float posy, bool moveToRight) {
        var startxPos = -1f;
        GameObject obstacle2Prefab = Resources.Load<GameObject>("Prefab/Networking/Obstacle3");
        if (!moveToRight)
            startxPos = startxPos * -1f;

        var obstacle3 = Instantiate(obstacle2Prefab, new Vector3(startxPos, posy, 0.1f), Quaternion.identity);
        obstacle3.transform.parent = this.transform;
    }

    // Update is called once per frame
    void Update () {
		timer += Time.deltaTime;
		if(mySlider != null && isPlaying)
			mySlider.value = timer / timeDivider;


		if (timer > timeDivider && isPlaying) {
			gameOver (true);
		}
	}
	public void gameOver(bool fail = false){
        //DestroyImmediate(mySlider.gameObject,true);
        if (isPlaying) {

            isPlaying = false;
            Debug.Log("GAME FINISHED " + fail + " SCORE: " + score);
            PlayerPrefs.SetFloat("score", fail ? 0 : 10);
            PlayerPrefs.SetString("sceneName", "Networking");
            PlayerPrefs.SetInt("fail", fail ? 1 : 0);

            if (mySlider != null)
                Destroy(mySlider.gameObject);

            if (fail)
                finalLostAnimation.SetActive(true);
            else
                finalWinAnimation.SetActive(true);

            Coroutiner.StartCoroutine(NavigateToGameOver());

        }


    }
    public IEnumerator NavigateToGameOver()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("GameOver");

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
        "x", -355f,
        "time", 0.5f,
        "oncomplete", "OnCompleteInstructions",
        "oncompletetarget", gameObject,
        "oncompleteparams", obj,
        "easetype", iTween.EaseType.easeInOutCubic,
        "islocal", true
    ));
    }


}
