using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoinCount : MonoBehaviour {
    string OBJECT_NAME = "Coin(Clone)";
    private int countCoins;
    GameObject woods;
    GameObject fallingCoins;
    GameObject street;
    GameObject piggyBank;
    GameObject movingMoneyCart;
    GameObject kilometers;
    GameObject coins;
    public Transform[] kilometersPositions;
    Camera cam;

    float speed = 7f;
    float timer = 0f;
    UnityEngine.UI.Slider mySlider;


    void Start()
    {

        Instantiate(Resources.Load<Canvas>("Prefab/TimerSlide"), new Vector3(-255, -255, 1), Quaternion.identity);

        GameObject tempSlider = GameObject.Find("Slider");
        if (tempSlider != null)
        {
            mySlider = tempSlider.GetComponent<UnityEngine.UI.Slider>();
        }

        var introTextGo = GameObject.Find("IntroText").GetComponent<Text>();
        var introTextGoTitle = GameObject.Find("Title").GetComponent<Text>();
        if (PlayerPrefs.GetInt("Lvl").Equals(1))
        {
            introTextGoTitle.text = "MOVE";
        }
        else
        {
            introTextGoTitle.text = "MOVE FASTER";
        }
        var introTextGoSubTitle = GameObject.Find("Subtitle").GetComponent<Text>();
        introTextGoSubTitle.text = "To save";
        iTween.MoveTo(introTextGo.gameObject, iTween.Hash(
            "x", -145f,
            "time", 0.6f,
            "oncomplete", "OnCompleteShowInstructions",
            "oncompletetarget", gameObject,
            "oncompleteparams", introTextGo.gameObject,
            "easetype", iTween.EaseType.easeInBounce,
            "islocal", true
        ));
        cam = GetComponent<Camera>();
        woods = GameObject.Find("Woods");
        fallingCoins = GameObject.Find("FallingCoinManager");
        street = GameObject.Find("Street");
        movingMoneyCart = GameObject.Find("MovingMoneyCart");
        piggyBank = GameObject.Find("PiggyBank");
        kilometers = GameObject.Find("Kilometers");        
        woods.SetActive(false);
                
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
    void FixedUpdate()
    {

        timer += Time.deltaTime;
        if (mySlider != null)
            mySlider.value = timer / 10f;

 
        coins = GameObject.Find("Coin(Clone)");
        
        if (countCoins  == 11 || timer > 10f) {
            if (coins != null)
            {
                coins.SetActive(false);
            }

            piggyBank.transform.position = kilometersPositions[0].position;
            
            
            woods.SetActive(true);
            fallingCoins.SetActive(false);                        
            Destroy(movingMoneyCart.GetComponent<DragObjectX>());    
            
            if (kilometersPositions[countCoins].position != piggyBank.transform.position) {                
                kilometersPositions[countCoins].position = Vector3.MoveTowards(kilometersPositions[countCoins].position, kilometersPositions[0].position, Time.deltaTime * speed);
                street.transform.Translate(Vector2.left * speed * Time.deltaTime);                               
            } else{
                Debug.Log("LLego a tocar el punto correcto");
                gameOver();

            }
        }
    }

    void OnTriggerEnter2D(Collider2D collisionObject)
    {
        if (collisionObject.name == OBJECT_NAME)
        {
            countCoins += 1;            
        }

    }
public void gameOver(bool fail = false)
{
    PlayerPrefs.SetFloat("score", 10);
    PlayerPrefs.SetString("sceneName", "InvestToProgress");

    PlayerPrefs.SetInt("fail", fail ? 1 : 0);
    SceneManager.LoadScene("GameOver");

    }
}
