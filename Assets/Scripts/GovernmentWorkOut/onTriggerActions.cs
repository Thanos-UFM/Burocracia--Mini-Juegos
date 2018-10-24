using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onTriggerActions : MonoBehaviour {


    void OnTriggerEnter(Collider baseCollider)
    {
        Debug.Log("TERMINO");
        PlayerPrefs.SetFloat("score", 0);
        PlayerPrefs.SetString("sceneName", "GovermentWorkOut");
        PlayerPrefs.SetInt("fail",1);
        SceneManager.LoadScene("GameOver");
    }
}
