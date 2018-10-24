using System.Collections;
using System.Collections.Generic;
using Scripts.MyLibs;
using UnityEngine;

public class PersonForce : MonoBehaviour {

    public float myGameDifficulty = 1f;
    public Rigidbody rb;
    BureaucracyMainScript mainScript;
    public GameObject lineRendererGO0, lineRendererGO1, lineRendererGO2, lineRendererGO3;
    LineRenderer lineRenderer0, lineRenderer1, lineRenderer2, lineRenderer3;
    void Start()
    {
        myGameDifficulty = (float)PlayerPrefs.GetInt("Lvl");

        lineRenderer0 = lineRendererGO0.GetComponent<LineRenderer>();
        lineRenderer0.startWidth = 0.05f;
        lineRenderer0.positionCount = 2;
        lineRenderer0.useWorldSpace = false;
        lineRenderer0.SetPosition(0, new Vector3(-1.5f, -2f, this.transform.position.z));

        lineRenderer1 = lineRendererGO1.GetComponent<LineRenderer>();
        lineRenderer1.startWidth = 0.05f;
        lineRenderer1.positionCount = 2;
        lineRenderer1.useWorldSpace = false;
        lineRenderer1.SetPosition(0, new Vector3(-0.8f, -2f, this.transform.position.z));

        lineRenderer2 = lineRendererGO2.GetComponent<LineRenderer>();
        lineRenderer2.startWidth = 0.05f;
        lineRenderer2.positionCount = 2;
        lineRenderer2.useWorldSpace = false;
        lineRenderer2.SetPosition(0, new Vector3(0.8f, -2f, this.transform.position.z));

        lineRenderer3 = lineRendererGO3.GetComponent<LineRenderer>();
        lineRenderer3.startWidth = 0.05f;
        lineRenderer3.positionCount = 2;
        lineRenderer3.useWorldSpace = false;
        lineRenderer3.SetPosition(0, new Vector3(1.5f, -2f, this.transform.position.z));

        mainScript = this.gameObject.GetComponentInParent<BureaucracyMainScript>();

        rb = GetComponent<Rigidbody>();
    }
    float tempTimer = 0f;
    void FixedUpdate()
    {
        if (tempTimer > 1.4f)
        {
            rb.AddForce(0f, -myGameDifficulty * 6f * Time.deltaTime, 0f, ForceMode.Force);
            lineRenderer0.SetPosition(1, new Vector3(this.transform.position.x - 0.13f, this.transform.position.y - 0.16f, this.transform.position.z));
            lineRenderer1.SetPosition(1, new Vector3(this.transform.position.x - 0.1f, this.transform.position.y - 0.17f, this.transform.position.z));
            lineRenderer2.SetPosition(1, new Vector3(this.transform.position.x + 0.1f, this.transform.position.y - 0.17f, this.transform.position.z));
            lineRenderer3.SetPosition(1, new Vector3(this.transform.position.x + 0.13f, this.transform.position.y - 0.16f, this.transform.position.z));

        } else{
            lineRenderer0.SetPosition(1, new Vector3(this.transform.position.x - 0.13f, this.transform.position.y - 0.16f, this.transform.position.z));
            lineRenderer1.SetPosition(1, new Vector3(this.transform.position.x - 0.1f, this.transform.position.y - 0.17f, this.transform.position.z));
            lineRenderer2.SetPosition(1, new Vector3(this.transform.position.x + 0.1f, this.transform.position.y - 0.17f, this.transform.position.z));
            lineRenderer3.SetPosition(1, new Vector3(this.transform.position.x + 0.13f, this.transform.position.y - 0.16f, this.transform.position.z));
        }
        tempTimer += Time.deltaTime;

    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Win")
        {
            Debug.Log("WINN");
            mainScript.gameOver();
        }
        else if(col.gameObject.name == "Loose") {
            Debug.Log("Loose");
            mainScript.gameOver(true);
        }
    }
}
