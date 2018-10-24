using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionsButtons : MonoBehaviour {

	public void PushedResetButton() {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
          SceneManager.LoadScene("MenuGamesMain");
    }
}
