using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverBalanceTheworld : MonoBehaviour
{

    //public GameObject CanvasFinal;


    void Start()
    {
       // CanvasFinal.SetActive(false);
    }

    void OnTriggerStay(Collider baseCollider)
    {

        if (baseCollider.tag == "LadrillosFall")
        {
            baseCollider.tag = "DestroyLadrillos";
        }

    }




}
