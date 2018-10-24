using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Scripts.MyLibs;
using Scripts.Data;
using System.Linq;

public class GameOverScript : MonoBehaviour
{
    List<string> minigames = new List<string>();
    List<string> minigamesRandomList = new List<string>();
    List<string> playedGamesList = new List<string>();

    string nameGame = "";
    string MENUGAME_NAME = "MenuGamesMain";
    string GAMEOVER_NAME = "GameOver";

    // Use this for initialization
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        minigames.Add("TaxMan");
        minigames.Add("Networking");
        minigames.Add("InvestToProgress");
        minigames.Add("GovermentWorkOut");
        minigames.Add("Censorship");
        minigames.Add("TheWorldBalance");
        minigames.Add("Bureaucracy");
        minigames.Add("JumpTheTradeBarriers");
        minigames.Add("Memory");


        FillRandomList();

        playedGamesList.Add("TaxManPlayed");
        playedGamesList.Add("NetworkingPlayed");
        playedGamesList.Add("InvestToProgressPlayed");
        playedGamesList.Add("GovermentWorkOutPlayed");
        playedGamesList.Add("CensorshipPlayed");
        playedGamesList.Add("TheWorldBalancePlayed");
        playedGamesList.Add("BureaucracyPlayed");
        playedGamesList.Add("JumpTheTradeBarriersPlayed");
        playedGamesList.Add("MemoryPlayed");

        var totalScore = PlayerPrefs.GetFloat("totalScore");
        var score = PlayerPrefs.GetFloat("score");
        var sceneName = PlayerPrefs.GetString("sceneName");
        var fail = PlayerPrefs.GetInt("fail");

      
        Transform mylabel = transform.Find("Score");
        Text t = mylabel.GetComponent<Text>();

        totalScore += score;
        PlayerPrefs.SetFloat("totalScore", totalScore);
        t.text = totalScore.ToString();

        Transform levelComplete = transform.Find("LevelComplete");
        Text lvlComplete = levelComplete.GetComponent<Text>();
        lvlComplete.text = "LEVEL COMPLETE: " + score.ToString();

        PlayerPrefs.SetInt(sceneName+"Played",1); //last scene played
        foreach (var playedGameName in playedGamesList) { //remove all used scenes
            if (PlayerPrefs.GetInt(playedGameName) == 1) {
                var sceneNameTemp = playedGameName.Substring(0, playedGameName.Length - 6);
                minigamesRandomList.Remove(sceneNameTemp);
            }
        }

        if (minigamesRandomList.Count == 0)
        {
            FillRandomList();
            PlayerPrefs.SetInt("Lvl", PlayerPrefs.GetInt("Lvl")+1);
        }
        minigamesRandomList.Shuffle();
        Debug.Log(fail+"GO LEVEL" + PlayerPrefs.GetInt("Lvl"));

        var lives = PlayerPrefs.GetInt("Lives");
        var goHeart = GameObject.Find("heart0");
        var goHeart1 = GameObject.Find("heart1");
        var goHeart2 = GameObject.Find("heart2");


        if (lives <= 0) //END GAME
        {
            Coroutiner.StartCoroutine(finishGame());
        }
        else {
            if (lives == 2)
            {
                DestroyImmediate(goHeart2.gameObject);
            }
            else if (lives == 1)
            {
                DestroyImmediate(goHeart2.gameObject);
                DestroyImmediate(goHeart1.gameObject);
            }

            if (fail == 1)
            {
                lives -= 1;
                Debug.Log("***Lives: " + lives);

                var heart = GameObject.Find("heart" + lives);
                PlayerPrefs.SetInt("Lives", lives);
                iTween.FadeTo(heart.gameObject, iTween.Hash(
                   "alpha", 0,
                   "time", 0.5f,
                   "oncomplete", "OnCompleteHeartAnimation",
                   "oncompletetarget", gameObject,
                   "oncompleteparams", heart.gameObject,
                   "islocal", true
               ));
            }
            Debug.Log("Lives: " + PlayerPrefs.GetInt("Lives"));

        }


    }
    public void OnCompleteHeartAnimation(GameObject heart)
    {
        DestroyImmediate(heart);

        var lives = PlayerPrefs.GetInt("Lives");

        if (lives <= 0) //END GAME
        {
            Coroutiner.StartCoroutine(finishGame());
        }
    }
    public void FillRandomList() {
        minigames.Shuffle();
        foreach (var game in minigames) {
            minigamesRandomList.Add(game);
        }
        foreach (var playedGameName in playedGamesList)
        {
            PlayerPrefs.SetInt(playedGameName,0);// not played
        }
    }
    public void retry()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("sceneName"));
        PlayerPrefs.SetInt("Lvl", PlayerPrefs.GetInt("Lvl") + 1);

    }

    public void nextGame()
    {
        SceneManager.LoadScene(minigamesRandomList[0]);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MenuGamesMain");
    }
    public IEnumerator finishGame()
    {
        yield return new WaitForSeconds(0.02f);
        mainMenu();
    }
    public IEnumerator changeGame()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(nameGame);
    }
    // Update is called once per frame
    void Update()
    {

    }

}