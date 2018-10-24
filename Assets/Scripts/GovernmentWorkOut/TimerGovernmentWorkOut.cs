using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerGovernmentWorkOut : MonoBehaviour {

  
    float timer = 0f;
  
   

    public float dificultad = 1f;
    [HideInInspector]
    public int quantityOfFails = 0;
    [HideInInspector]
    public float score = 0f;
    [HideInInspector]
    public bool isPlaying = true;


    UnityEngine.UI.Slider mySlider;

    // Use this for initialization
    void Start () {
        mySlider = this.gameObject.GetComponentInChildren<UnityEngine.UI.Slider>();
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (mySlider != null)
            mySlider.value = timer / 8f;

        if (timer > 8f && isPlaying)
        {
            isPlaying = false;
            //if (quantityOfFails == 0 && score != 0)
            gameOver();
            //gameOver();
            //else
        }
    }

    public void gameOver() {
        isPlaying = false;
        //  GameOverPanel.SetActive(true);
        PlayerPrefs.SetFloat("score", 10);
        PlayerPrefs.SetString("sceneName", "GovermentWorkOut");
        PlayerPrefs.SetInt("fail", 0);
        SceneManager.LoadScene("GameOver");
    }
}
