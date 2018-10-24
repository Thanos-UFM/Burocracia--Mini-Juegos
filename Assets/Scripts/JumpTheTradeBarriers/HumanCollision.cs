using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HumanCollision : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collisionObject)
    {

        if (collisionObject.tag == "Obstacle")
        {
            PlayerPrefs.SetFloat("score", 10);
            PlayerPrefs.SetString("sceneName", "JumpTheTradeBarriers");
            PlayerPrefs.SetInt("fail",  1);

            SceneManager.LoadScene("GameOver");
        }

    }
}
