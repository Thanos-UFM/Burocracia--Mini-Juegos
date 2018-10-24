using UnityEngine;
using System.Collections;
using Scripts.MyLibs;
using System.Collections.Generic;

public class TapEventNetworking : MonoBehaviour
{
	public Camera cam;
	bool isMouseDown = false;
    [HideInInspector]
	public TrailRenderer lineRenderer;
    NetworkingMainScript mainScript;
    bool goodStart = false;
    void Start () {
        mainScript = this.gameObject.GetComponentInParent<NetworkingMainScript>();


    }
	void Update()
	{
		if( (Input.touchCount> 0 && Input.GetTouch(0).phase == TouchPhase.Began)||Input.GetMouseButtonDown(0) ){

            if (lineRenderer == null) {
                var trailRendererGO = new GameObject("trailRenderer");
                lineRenderer = trailRendererGO.AddComponent<TrailRenderer>();
                lineRenderer.startWidth = 0.06f;
                lineRenderer.endWidth = 0.01f;
                lineRenderer.time = 2f;
                lineRenderer.material = Resources.Load<Material>("Materials/LineRenderer");
            }

			if(!isMouseDown){
				isMouseDown= true;

                var mousWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);
                var pos = new Vector3(mousWorldPos.x, mousWorldPos.y, this.transform.position.z);

                GameObject objectHit = MyHelpers.getRaycastedGameObject(new Vector3(Input.mousePosition.x, Input.mousePosition.y, this.transform.position.z), cam);
                if (objectHit != null)
                {
                    if (objectHit.name.Equals("StartPoint"))
                    {
                        //  GameObject.Find("leftEye").transform.localPosition;
                        Debug.Log("GOOD START");
                        goodStart = true;
                    }
                    else 
                    {

                        mainScript.gameOver(true);

                    }

                }
            }

        }
		if( (Input.touchCount> 0 && Input.GetTouch(0).phase == TouchPhase.Ended)||Input.GetMouseButtonUp(0) ){
			
			isMouseDown= false;

            Debug.Log("FINGER RELEASEE  :( ");
            mainScript.gameOver(true);

        }
        if (isMouseDown) {
			var mousWorldPos = cam.ScreenToWorldPoint (Input.mousePosition);
			var pos =  new Vector3(mousWorldPos.x, mousWorldPos.y,  this.transform.position.z);
           
            GameObject objectHit = MyHelpers.getRaycastedGameObject(new Vector3(Input.mousePosition.x, Input.mousePosition.y, this.transform.position.z), cam);
            if (objectHit != null && !objectHit.name.Equals("StartPoint"))
            {
                if (objectHit.name.Equals("FinalPoint") && goodStart) {
                    //  GameObject.Find("leftEye").transform.localPosition;
                    Debug.Log("WIIIIN");
                    mainScript.gameOver();
                } else {
                    Debug.Log("LOOSE");

                    mainScript.gameOver(true);

                }

            }
            lineRenderer.transform.localPosition = new Vector3(pos.x, pos.y, 0f) ;

        }
	}

}