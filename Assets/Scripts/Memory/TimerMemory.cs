using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerMemory : MonoBehaviour {

  
    float timer = 0f;
  
   

    public float dificultad = 1f;
    [HideInInspector]
    public int quantityOfFails = 0;
    [HideInInspector]
    public float score = 0f;
    [HideInInspector]
    public bool isPlaying = true;
    float difficulty = 1f;
    float timedifficulty = 1f;

    UnityEngine.UI.Slider mySlider;

    // Use this for initialization
    void Start () {
        mySlider = this.gameObject.GetComponentInChildren<UnityEngine.UI.Slider>();
        if (PlayerPrefs.GetInt("Lvl").Equals(0))
        {
            PlayerPrefs.SetInt("Lvl", 1);
        }
        
        difficulty = PlayerPrefs.GetInt("Lvl");
        Debug.Log(">>>> " + PlayerPrefs.GetInt("Lvl"));
        timedifficulty = 10f - (difficulty/1.5f);
        Debug.Log("NIVEL DE DIFICULTAD " + difficulty + " tiempo nivel  " + timedifficulty);
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (mySlider != null)
            mySlider.value = timer / timedifficulty;

        if (timer > timedifficulty && isPlaying)
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
        PlayerPrefs.SetFloat("score", 0);
        PlayerPrefs.SetString("sceneName", "Memory");
        PlayerPrefs.SetInt("fail", 1);
        SceneManager.LoadScene("GameOver");
    }
}
