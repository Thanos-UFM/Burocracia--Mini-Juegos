using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingRocks : MonoBehaviour
{

    public Vector2 speedMinMax;
    public float speed;
    public float tamano;
    public float tamanopositiony;
    Rigidbody rBody;

    float visibleHeightThreshold;
    GameObject gameoverpoint;
    bool firsttime = false;

    void Start()
    {
        gameoverpoint = GameObject.Find("GameOverPoint2");
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());
        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
        //tamanopositiony = transform.position.y;
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.Self);
        if (transform.position.y < visibleHeightThreshold + 2.8)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "DestroyLadrillos")
        {


            foreach (ContactPoint contact in collision.contacts)
            {
                FixedJoint fixedJoint = gameObject.AddComponent<FixedJoint>();
                fixedJoint.anchor = contact.point;
                fixedJoint.connectedBody = collision.rigidbody;
            }

        }

        if (collision.gameObject.name == "Ladrillos4(Clone)" && collision.gameObject.tag == "DestroyLadrillos")
        {

            var colisionador = gameoverpoint.GetComponent<BoxCollider>().bounds.size.y / 2;
            var posicionlocalgameover = gameoverpoint.transform.localPosition.y - colisionador;

            var colisionadorladrillo = this.GetComponent<BoxCollider>().bounds.size.y / 2;
            var posicionfinalladrillo = this.transform.localPosition.y - colisionadorladrillo;


            var posicionfinalladrilloY = this.transform.localPosition.y + colisionadorladrillo;


            if (posicionfinalladrillo >= posicionlocalgameover || posicionfinalladrilloY >= posicionlocalgameover)
            {

                PlayerPrefs.SetFloat("score", 0);
                PlayerPrefs.SetString("sceneName", "TheWorldBalance");
                PlayerPrefs.SetInt("fail", 1);
                SceneManager.LoadScene("GameOver");


            }



        }
    }
}
