using UnityEngine;
using System.Collections;
using Scripts.MyLibs;

public class SwipeDetector : MonoBehaviour {


	// To recognize as swipe user should at lease swipe for this many pixels
	private const float minimumSwipeDistance = 0.15f;
	private const float allowedSwipeVariance = 1.5f;

	// To recognize as a swipe the velocity of the swipe
	// should be at least mMinVelocity
	// Reduce or increase to control the swipe speed
	private const float timeToSwipe  = 0.15f;



	// Use this for initialization
	void Start () {
		var swipeRecognizer = new TKSwipeRecognizer(TKSwipeDirection.All,minimumSwipeDistance,allowedSwipeVariance);
		swipeRecognizer.timeToSwipe = timeToSwipe;
		swipeRecognizer.gestureRecognizedEvent += (r) =>
        {

            if (r.completedSwipeDirection == TKSwipeDirection.Left )
			{
				swipe ("left", r.startPoint);
			
			}
			if (r.completedSwipeDirection == TKSwipeDirection.Right)
			{ 
				swipe ("right", r.startPoint);

			}
			if (r.completedSwipeDirection == TKSwipeDirection.Up)
			{
				swipe ("up", r.startPoint);

			}
			if (r.completedSwipeDirection == TKSwipeDirection.Down )
			{
                swipe("down", r.startPoint);

			}
		};
		TouchKit.addGestureRecognizer(swipeRecognizer);
	}


	private void swipe (string currentLocation, Vector2 mStartPosition){
		GameObject objectHit =  MyHelpers.getRaycastedGameObject(new Vector3(mStartPosition.x,mStartPosition.y,1f),Camera.current);
		if (objectHit != null ) {
			MyHandClass hand = objectHit.GetComponent<MyHandClass>();
			if (hand != null && hand.location.Equals (currentLocation)) {
				hand.OnSwipe ();
			}
		}
	}
}