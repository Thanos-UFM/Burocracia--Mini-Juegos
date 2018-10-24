using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeSlideTradeBarriers : MonoBehaviour
{
    UnityEngine.UI.Slider mySlider;
    float timer = 0f;
    // Use this for initialization
    void Start()
    {

        Instantiate(Resources.Load<Canvas>("Prefab/TimerSlide"), new Vector3(-255, -255, 1), Quaternion.identity);

        GameObject tempSlider = GameObject.Find("Slider");
        if (tempSlider != null)
        {
            mySlider = tempSlider.GetComponent<UnityEngine.UI.Slider>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (mySlider != null)
            mySlider.value = timer / 10f;

        if (timer > 10f)
        {
            gameOver();
        }
    }
    public void gameOver(bool fail = false)
    {
        //DestroyImmediate(mySlider.gameObject,true);
        PlayerPrefs.SetFloat("score", 10);
        PlayerPrefs.SetString("sceneName", "JumpTheTradeBarriers");

        PlayerPrefs.SetInt("fail", 1);

        SceneManager.LoadScene("GameOver");
    }
}