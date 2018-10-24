using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Data;
using System.Linq;
using Scripts.MyLibs;

public class MyHandClass : MonoBehaviour {
    [HideInInspector]
	public string location { get; set; }
    [HideInInspector]
    public Vector3 initialPositionV3 { get; set; }


    MainScript mainScript;
   
    // Use this for initialization
    Vector3 leftEyePos, rightEyePos, rightEarPos, leftEarPos, nosePos, mouthPos;

    public void create (bool firstTime = false) {
        leftEyePos = GameObject.Find("leftEye").transform.localPosition;
        rightEyePos = GameObject.Find("rightEye").transform.localPosition;
        leftEarPos = GameObject.Find("leftEar").transform.localPosition;
        rightEarPos = GameObject.Find("rightEar").transform.localPosition;
        nosePos = GameObject.Find("nose").transform.localPosition;
        mouthPos = GameObject.Find("mouth").transform.localPosition;


            if (this.gameObject.name.Contains("LeftHand"))
            {
                this.location = "left";
                initialPositionV3 = this.gameObject.transform.localPosition;

            }
            else if (this.gameObject.name.Contains("RightHand"))
            {
                this.location = "right";
                initialPositionV3 = this.gameObject.transform.localPosition;
            }
            else if (this.gameObject.name.Contains("UpperHand"))
            {
                this.location = "up";
                initialPositionV3 = this.gameObject.transform.localPosition;
            }
            else if (this.gameObject.name.Contains("DownHand"))
            {
                this.location = "down";
                initialPositionV3 = this.gameObject.transform.localPosition;
            }

            mainScript = this.gameObject.GetComponentInParent<MainScript>();

        if (firstTime)
        {
            Coroutiner.StartCoroutine(StartAnimation(2f , 3f));
        }
        else {
            Coroutiner.StartCoroutine(StartAnimation(2f / mainScript.myGameDifficulty, 6f / mainScript.myGameDifficulty));
        }



    }
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator StartAnimation( float startRangeTime , float endRangeTime )
	{
      

        yield return new WaitForSeconds(UnityEngine.Random.Range (startRangeTime, endRangeTime));
        if (this.location.Equals ("left")){
            var positionRandom = UnityEngine.Random.Range(0f, 600f);

            Vector3 movePos;
            if (positionRandom < 150) {
                movePos = leftEyePos;
                mainScript.countLeftEye++;       
            }
            else if (positionRandom >= 150f && positionRandom < 300f) {
                movePos = leftEarPos;
                mainScript.countLeftEar++;
            }
            else if (positionRandom >= 300f && positionRandom < 450f)
            {
                movePos = nosePos;
                mainScript.countNose++;
            }
            else {
                movePos = mouthPos;
                mainScript.countMouth++;
            }
              if (((mainScript.countLeftEye == 1 && movePos == leftEyePos) || (mainScript.countLeftEar == 1 && movePos == leftEarPos) || (mainScript.countNose == 1 && movePos == nosePos) || (mainScript.countMouth == 1 && movePos == mouthPos)))
                {
                    
                    this.gameObject.transform.localRotation = Quaternion.identity;
                
                

                }
                else if (((mainScript.countLeftEye == 2 && movePos == leftEyePos) || (mainScript.countLeftEar == 2 && movePos == leftEarPos) ||(mainScript.countNose == 2 && movePos == nosePos) || (mainScript.countMouth == 2 && movePos == mouthPos)))
                {

                    this.gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, -20f);
                     movePos.y = movePos.y + 0.2f;

                }
                else if (((mainScript.countLeftEye == 3 && movePos == leftEyePos) || (mainScript.countLeftEar == 3 && movePos == leftEarPos) || (mainScript.countNose == 3 && movePos == nosePos) || (mainScript.countMouth == 3 && movePos == mouthPos)) )
                {

                    this.gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, -40f);
                    movePos.y = movePos.y + 0.45f;

                }
                else if (((mainScript.countLeftEye == 4 && movePos == leftEyePos) || (mainScript.countLeftEar == 4 && movePos == leftEarPos) || (mainScript.countNose == 4 && movePos == nosePos) || (mainScript.countMouth == 4 && movePos == mouthPos)))
                {

                    this.gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 40f);
                    movePos.y = movePos.y - 0.45f;

                }
                else if (((mainScript.countLeftEye == 5 && movePos == leftEyePos) || (mainScript.countLeftEar == 5 && movePos == leftEarPos) || (mainScript.countNose == 5 && movePos == nosePos) || (mainScript.countMouth == 5 && movePos == mouthPos)) )
                {

                    this.gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 20f);
                    movePos.y = movePos.y - 0.2f;

                }


            iTween.Stop (this.gameObject);
            var movex = movePos.x - this.gameObject.GetComponent<BoxCollider>().bounds.size.x / 2.5f;

            iTween.MoveTo (this.gameObject, iTween.Hash (
				"x", movex,
                "y", movePos.y ,
                "time", UnityEngine.Random.Range (1f, 3f),
				"oncomplete", "OnCompleteAnimation",
				"oncompletetarget", gameObject,

                "oncompleteparams", this.gameObject,
				"islocal", true
			));
		}else if (this.location.Equals ("right")){
            var positionRandom = UnityEngine.Random.Range(0f, 600f);

            Vector3 movePos;
              if (positionRandom < 150)
              {
                  movePos = rightEyePos;
                  mainScript.countRightEye++;
              }
              else if (positionRandom >= 150f && positionRandom < 300f)
              {
                  movePos = rightEarPos;
                  mainScript.countRightEar++;
              }
              else if (positionRandom >= 300f && positionRandom < 450f)
              {
                  movePos = nosePos;
                  mainScript.countNose++;
              }
              else
              {
                  movePos = mouthPos;
                  mainScript.countMouth++;
              }
            if (((mainScript.countRightEye == 1 && movePos == rightEyePos) || (mainScript.countRightEar == 1 && movePos == rightEarPos) || (mainScript.countNose == 1 && movePos == nosePos) || (mainScript.countMouth == 1 && movePos == mouthPos)) )
              {
                  this.gameObject.transform.localRotation = Quaternion.identity;

              }
              else if (((mainScript.countRightEye == 2 && movePos == rightEyePos) || (mainScript.countRightEar == 2 && movePos == rightEarPos) || (mainScript.countNose == 2 && movePos == nosePos) || (mainScript.countMouth == 2 && movePos == mouthPos)))
              {
                  this.gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, -20f);
                  movePos.y = movePos.y - 0.2f;

              }
              else if (((mainScript.countRightEye == 3 && movePos == rightEyePos) || (mainScript.countRightEar == 3 && movePos == rightEarPos) || (mainScript.countNose == 3 && movePos == nosePos) || (mainScript.countMouth == 3 && movePos == mouthPos)))
              {
                  this.gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, -40f);
                  movePos.y = movePos.y - 0.45f;

              }
              else if (((mainScript.countRightEye == 4 && movePos == rightEyePos) || (mainScript.countRightEar == 4 && movePos == rightEarPos) || (mainScript.countNose == 4 && movePos == nosePos) || (mainScript.countMouth == 4 && movePos == mouthPos)))
              {
                  this.gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 40f);
                  movePos.y = movePos.y + 0.45f;

              }
              else if (((mainScript.countRightEye == 5 && movePos == rightEyePos) || (mainScript.countRightEar == 5 && movePos == rightEarPos) || (mainScript.countNose == 5 && movePos == nosePos) || (mainScript.countMouth == 5 && movePos == mouthPos)))
              {
                  this.gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 20f);
                  movePos.y = movePos.y + 0.2f;

              }
             


            iTween.Stop (this.gameObject);
            var movex = movePos.x + this.gameObject.GetComponent<BoxCollider>().bounds.size.x / 2.5f;

            iTween.MoveTo (this.gameObject, iTween.Hash (
                "x", movex ,
                "y", movePos.y,
                "time", UnityEngine.Random.Range (1f, 3f),
				"oncomplete", "OnCompleteAnimation",
				"oncompletetarget", gameObject,
				"oncompleteparams", this.gameObject,
                "islocal", true
			));

		}else if (this.location.Equals ("up") )
        {
            var positionRandom = UnityEngine.Random.Range(0f, 600f);


            iTween.Stop (this.gameObject);
            var movePos = positionRandom < 150 ? rightEyePos : positionRandom >= 150f && positionRandom < 300f ? leftEyePos : nosePos;
            var movey = movePos.y + this.gameObject.GetComponent<BoxCollider>().bounds.size.y / 2.5f;

            iTween.MoveTo (this.gameObject, iTween.Hash (
                "x", movePos.x ,
                "y", movey,
                "time", UnityEngine.Random.Range (1f, 3f),
				"oncomplete", "OnCompleteAnimation",
				"oncompletetarget", gameObject,
				"oncompleteparams", this.gameObject,
                 "easetype", iTween.EaseType.easeInOutSine,
                "islocal", true
			));

		}else if (this.location.Equals ("down") )
        {
            var positionRandom = UnityEngine.Random.Range(0f, 600f);


            iTween.Stop (this.gameObject);
            var movePos = positionRandom < 150 ? rightEyePos : positionRandom >= 150f && positionRandom < 300f ? leftEyePos : mouthPos;
            var movey = movePos.y - this.gameObject.GetComponent<BoxCollider>().bounds.size.y / 2.5f;

            iTween.MoveTo (this.gameObject, iTween.Hash (
                "x", movePos.x,
                "y", movey,
                "time", UnityEngine.Random.Range (1f, 3f),
				"oncomplete", "OnCompleteAnimation",
				"oncompletetarget", gameObject,
				"oncompleteparams", this.gameObject,
                "islocal", true
			));

		}

        mainScript.countLeftEye = mainScript.countLeftEye >= 5 ? 0 : mainScript.countLeftEye;
        mainScript.countLeftEar = mainScript.countLeftEar >= 5 ? 0 : mainScript.countLeftEar;
        mainScript.countMouth = mainScript.countMouth >= 5 ? 0 : mainScript.countMouth;
        mainScript.countNose = mainScript.countNose >= 5 ? 0 : mainScript.countNose;
        mainScript.countRightEar = mainScript.countRightEar >= 5 ? 0 : mainScript.countRightEar;
        mainScript.countRightEye = mainScript.countRightEye >= 5 ? 0 : mainScript.countRightEye;
    }

    public void OnCompleteAnimation(){
		iTween.Stop (this.gameObject);
		iTween.MoveTo (this.gameObject, iTween.Hash (
			"x", this.transform.localPosition.x,
			"time", 3f,
			"oncomplete", "OnCompleteLooseGame",
			"oncompletetarget", gameObject,
			"oncompleteparams", this.gameObject,
            "islocal", true
		));
	}
	public void OnSwipe(){

        iTween.Stop (this.gameObject);

		iTween.MoveTo (this.gameObject, iTween.Hash (
			"position",  this.initialPositionV3,
			"time", 1f,
			"oncomplete", "onStartAnimation",
			"oncompletetarget", gameObject,
			"oncompleteparams", this.gameObject,
            "islocal", true
		));
		mainScript.score++;
	}
    public void onStartAnimation()
    {
        if (location.Equals("up"))
            mainScript.quantityOfUpperHands = 0;
        else if (location.Equals("down"))
            mainScript.quantityOfDownHands = 0;


        DestroyImmediate(this.gameObject);
        mainScript.generateNewHand(1);

    }
	public void OnCompleteLooseGame(){
		mainScript.quantityOfFails += 1;
		Debug.Log ("FINISHED TIME IN FACE: " + mainScript.score);
		mainScript.isPlaying = false;
		mainScript.gameOver (true);
	}
	public void tapEvent(){
		OnSwipe ();
	}
}

