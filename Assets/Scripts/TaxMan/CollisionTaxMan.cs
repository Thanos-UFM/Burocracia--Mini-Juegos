using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionTaxMan : MonoBehaviour {

    public GameObject gameObject;
    public string tagName;

    void OnTriggerEnter2D(Collider2D collisionObject)
    {        
        if (collisionObject.tag == tagName)
        {
            PlayerPrefs.SetFloat("score", 0);
            PlayerPrefs.SetString("sceneName", "TaxMan");

            PlayerPrefs.SetInt("fail",1);
            SceneManager.LoadScene("GameOver");
        }

    }
}
