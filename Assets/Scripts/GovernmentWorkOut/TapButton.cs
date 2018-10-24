using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TapButton : MonoBehaviour {
    public float speed = 7;
    public GameObject Character;

    Rigidbody rb;
    public float forceMult = 500;
    public float LevelGame;

    public void Start()
    {
        Debug.Log("FORCEMULT " + forceMult);
        if (PlayerPrefs.GetInt("Lvl").Equals(0))
        {
            PlayerPrefs.SetInt("Lvl", 1);
        }

        Debug.Log("Dificultad PlayerPrefabs " + PlayerPrefs.GetInt("Lvl"));
        LevelGame = PlayerPrefs.GetInt("Lvl");
        Debug.Log("LeveGame " + LevelGame);
        rb = Character.GetComponent<Rigidbody>();
        forceMult = forceMult - (LevelGame * 50); // Formula de Dificultad
        
        Debug.Log("INDICE DE FUERZA DIFICULTAD " + forceMult);
    }

    public void MoveCharacter()
    {
        float inputXMoveLeft = -1;
        float velocity = inputXMoveLeft * speed;
        // Character.transform.Translate(Vector2.right * velocity * 0.01656565f);
        rb.AddForce(-(forceMult * 0.01656565f), 0, 0, ForceMode.Impulse);
    }

    public void ResetGame() {
        SceneManager.LoadScene("MenuGamesMain");
//        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
