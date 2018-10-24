using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.MyLibs;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Experimental.UIElements;
using Scripts.Data;
using System;

public class MainScript : MonoBehaviour {

    int quantityOfHands = 8;
    float timer = 0f;
    [HideInInspector]
    public float myGameDifficulty = 1f;
    [HideInInspector]
    public int quantityOfHandsByDifficulty = 0;

    [HideInInspector]
    public int quantityOfFails = 0;
    [HideInInspector]
    public float score = 0f;
    [HideInInspector]
    public bool isPlaying = true;
    [HideInInspector]
    public int quantityOfUpperHands = 0, quantityOfDownHands = 0;

    [HideInInspector]
    public List<GameObject> handList = new List<GameObject>();

    [HideInInspector]
    public List<GameObject> handListOnlyLevel = new List<GameObject>();

    UnityEngine.UI.Slider mySlider;

    [HideInInspector]
    public int countLeftEye = 0, countLeftEar = 0, countRightEye = 0, countRightEar = 0, countMouth = 0, countNose = 0;

    GameObject finalWinAnimation, finalLostAnimation;
    bool firstTime = true;
    // Use this for initialization
    void Start() {

        if (PlayerPrefs.GetInt("Lvl").Equals(0))
        {
            PlayerPrefs.SetInt("Lvl", 1);
        }

        myGameDifficulty = (float)PlayerPrefs.GetInt("Lvl");

        var introTextGo = GameObject.Find("IntroText").GetComponent<Text>();
        var introTextGoTitle = GameObject.Find("Title").GetComponent<Text>();
        if (PlayerPrefs.GetInt("Lvl").Equals(1))
        {
            introTextGoTitle.text = "REMOVE";
        }
        else
        {
            introTextGoTitle.text = "REMOVE FASTER";
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

        finalWinAnimation = GameObject.Find("FinalWinAnimation");
        finalWinAnimation.SetActive(false);

        finalLostAnimation = GameObject.Find("FinalLostAnimation");
        finalLostAnimation.SetActive(false);

        Instantiate(Resources.Load<Canvas>("Prefab/TimerSlide"), new Vector3(-255, -255, 1), Quaternion.identity);

        GameObject tempSlider = GameObject.Find("Slider");
        if (tempSlider != null)
        {
            mySlider = tempSlider.GetComponent<UnityEngine.UI.Slider>();
        }
        var intDifficulty = (int)myGameDifficulty;
        quantityOfHandsByDifficulty = 0;
        switch (intDifficulty) {
            case 1:
                quantityOfHandsByDifficulty = 3;
                break;
            case 2:
                quantityOfHandsByDifficulty = 4;
                break;
            case 3:
                quantityOfHandsByDifficulty = 5;
                break;
            default:
                quantityOfHandsByDifficulty = 6;
                break;
        }
        generateNewHand(quantityOfHandsByDifficulty, true);
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
    void OnCompleteInstructions(GameObject obj) {
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

    public void generateNewHand(int quantity, bool firstTime = false)
    {

        for (int i = 0; i < quantity; i++) {
            GameObject leftHandPrefab = Resources.Load<GameObject>("Prefab/Censorship/LeftHand");
            GameObject RightHandPrefab = Resources.Load<GameObject>("Prefab/Censorship/RightHand");
            GameObject UpperHandPrefab = Resources.Load<GameObject>("Prefab/Censorship/UpperHand");
            GameObject DownHandPrefab = Resources.Load<GameObject>("Prefab/Censorship/DownHand");

            var typeRandom = UnityEngine.Random.Range(0, 600);
            var location = typeRandom < 150 ? 0 : typeRandom >= 150f && typeRandom < 300f ? 1 : typeRandom >= 300f && typeRandom < 450f ? 2 : 3;
            var positionRandom = UnityEngine.Random.Range(0f, 450f);
            var posy = positionRandom < 150 ? 0.6f : positionRandom >= 150f && positionRandom < 300f ? 0.2f : -0.2f;
            var colorRandom = UnityEngine.Random.Range(0f, 450f);
            var colorIndex = colorRandom < 150 ? 1 : colorRandom >= 150f && colorRandom < 300f ? 2 : 3;
            GameObject hand;
            if (location == 0)
            {
                hand = Instantiate(leftHandPrefab, new Vector3(-1.8f, posy, 0.1f), Quaternion.identity);
                hand.transform.parent = this.transform;
                hand.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/Censorship/hand-left-" + colorIndex);
                hand.GetComponent<MyHandClass>().create(firstTime);

            }
            else if (location == 1)
            {

                hand = Instantiate(RightHandPrefab, new Vector3(1.8f, posy, 0f), Quaternion.identity);
                hand.transform.parent = this.transform;
                hand.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/Censorship/hand-right-" + colorIndex);
                hand.GetComponent<MyHandClass>().create(firstTime);

            }
            else if (location == 2)
            {
                if (quantityOfUpperHands == 0) {
                    var quaternion = Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(-85f, -95f));
                    hand = Instantiate(UpperHandPrefab, new Vector3(0.04f, 2.57f, 0f), quaternion);
                    hand.transform.parent = this.transform;
                    quantityOfUpperHands++;
                    hand.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/Censorship/hand-left-" + colorIndex);

                    hand.GetComponent<MyHandClass>().create(firstTime);
                }
                else
                {
                    generateNewHand(1, firstTime);
                }
            }
            else
            {
                if (quantityOfDownHands == 0)
                {
                    var quaternion = Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(-85f, -95f));
                    hand = Instantiate(DownHandPrefab, new Vector3(-0.4f, -2.57f, 0f), quaternion);
                    hand.transform.parent = this.transform;
                    quantityOfDownHands++;
                    hand.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/Censorship/hand-right-" + colorIndex);

                    hand.GetComponent<MyHandClass>().create(firstTime);
                }
                else {
                    generateNewHand(1, firstTime);
                }
            }
        }
    }


    // Update is called once per frame
    void Update () {
		timer += Time.deltaTime;
        try {
            if (mySlider != null)
                mySlider.value = timer / 10f;
        } catch(Exception ex)
        {

        }	

		if (timer > 10f && isPlaying) {
			isPlaying = false;
			if(quantityOfFails == 0 && score != 0)
				gameOver ();
			else
				gameOver (true);

		}
	}
	public void gameOver(bool fail = false){
		//DestroyImmediate(mySlider.gameObject,true);
		isPlaying = false;
        if (firstTime)
        {
            Debug.Log("GAME FINISHED " + fail + " SCORE: " + score);
            PlayerPrefs.SetFloat("score", score);
            PlayerPrefs.SetString("sceneName", "Censorship");

            PlayerPrefs.SetInt("fail", fail ? 1 : 0);
            if (mySlider != null)
                DestroyImmediate(mySlider.gameObject);

            if (fail)
                finalLostAnimation.SetActive(true);
            else
                finalWinAnimation.SetActive(true);


            Coroutiner.StartCoroutine(NavigateToGameOver());


            firstTime = false;
        }

    }

    private void DestroyImmediate()
    {
        throw new NotImplementedException();
    }

    public IEnumerator NavigateToGameOver()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("GameOver");

    }
}
