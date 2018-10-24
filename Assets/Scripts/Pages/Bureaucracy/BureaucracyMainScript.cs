using System.Collections;
using System.Collections.Generic;
using Scripts.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BureaucracyMainScript : MonoBehaviour
{
    public GameObject person;
    Rigidbody rb;
    float timer = 0f;
    [HideInInspector]
    public float myGameDifficulty = 1f;

    [HideInInspector]
    public float score = 0f;
    [HideInInspector]
    public bool isPlaying = true;

    UnityEngine.UI.Slider mySlider;
    GameObject finalWinAnimation, finalLostAnimation;

    // Use this for initialization
    void Start()
    {

        finalWinAnimation = GameObject.Find("FinalWinAnimation");
        finalWinAnimation.SetActive(false);

        finalLostAnimation = GameObject.Find("FinalLostAnimation");
        finalLostAnimation.SetActive(false);

        rb = person.GetComponent<Rigidbody>();
        mySlider = this.gameObject.GetComponentInChildren<UnityEngine.UI.Slider>();
        if (PlayerPrefs.GetInt("Lvl").Equals(0))
        {
            PlayerPrefs.SetInt("Lvl", 1);
        }

        myGameDifficulty = (float)PlayerPrefs.GetInt("Lvl");
        var introTextGo = GameObject.Find("IntroText").GetComponent<Text>();
        var introTextGoTitle = GameObject.Find("Title").GetComponent<Text>();
        if (PlayerPrefs.GetInt("Lvl").Equals(1))
        {
            introTextGoTitle.text = "TAP";
        }
        else {
            introTextGoTitle.text = "TAP FASTER";
        }
         
        var introTextGoSubTitle = GameObject.Find("Subtitle").GetComponent<Text>();
        introTextGoSubTitle.text = "to cut the strings";
        iTween.MoveTo(introTextGo.gameObject, iTween.Hash(
            "x", -125f,
            "time", 0.6f,
            "oncomplete", "OnCompleteShowInstructions",
            "oncompletetarget", gameObject,
            "oncompleteparams", introTextGo.gameObject,
            "easetype", iTween.EaseType.easeInBounce,
            "islocal", true
        ));
    }

    void FixedUpdate()
    {
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0))
        {
            Debug.Log("TAPPP");
            rb.AddForce(0f, 0.05f, 0f, ForceMode.Impulse);

        }
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (mySlider != null)
            mySlider.value = timer / 10f;


        if (timer > 10f && isPlaying)
        {
            isPlaying = false;
            gameOver(true);

        }
    }
    public void gameOver(bool fail = false)
    {
        isPlaying = false;
        Debug.Log("GAME FINISHED " + fail + " SCORE: " + score);
        PlayerPrefs.SetFloat("score", fail ? 0 : 10);
        PlayerPrefs.SetString("sceneName", "Bureaucracy");
        PlayerPrefs.SetInt("fail", fail ? 1 : 0);
        if (mySlider != null)
            Destroy(mySlider.gameObject);

        GameObject.Find("LineRenderer0").GetComponent<LineRenderer>().enabled = false;
        GameObject.Find("LineRenderer1").GetComponent<LineRenderer>().enabled = false;
        GameObject.Find("LineRenderer2").GetComponent<LineRenderer>().enabled = false;
        GameObject.Find("LineRenderer3").GetComponent<LineRenderer>().enabled = false;
        if (fail)
            finalLostAnimation.SetActive(true);
        else
            finalWinAnimation.SetActive(true);

        Coroutiner.StartCoroutine(NavigateToGameOver());

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
