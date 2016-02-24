using UnityEngine;
using System.Collections;

public class JumpAnimationScript : MonoBehaviour {

	public GameObject[] SplineRootGroup;
	public float[] SplineRootDurationGroup;
	SplineController otherScript;

	public int state;

	private Animator myAnimator;

	bool jump;

	// Use this for initialization
	void Start () {

		this.otherScript = this.GetComponent<SplineController>();
		state = -1;

		print (otherScript.SplineRoot);

		myAnimator = GetComponent<Animator> ();
		myAnimator.SetFloat ("VSpeed", 1.0f);
	}
	
	// Update is called once per frame
	void Update () {

		if(state == 0){
//			otherScript.setSplineObject (SplineRootGroup [0], SplineRootDurationGroup[0]);
			otherScript.FollowSpline ();
			print (otherScript.SplineRoot);
			myAnimator.SetFloat ("VSpeed", 1.0f);
		} else if(state == 1){
			//this.setPosition Make sure he doesn't sink
			myAnimator.SetFloat ("VSpeed", 0.0f);
		} else if(state == 2){
			otherScript.setSplineObject (SplineRootGroup [1], SplineRootDurationGroup[1]);
			otherScript.FollowSpline ();
			print (otherScript.SplineRoot);
			myAnimator.SetFloat ("VSpeed", 1.0f);
		} else if(state == 3){
			//this.setPosition Make sure he doesn't sink
			myAnimator.SetFloat ("VSpeed", 0.0f);
		} else if(state == 4){
			otherScript.setSplineObject (SplineRootGroup [2], SplineRootDurationGroup[2]);
			otherScript.FollowSpline ();
			print (otherScript.SplineRoot);
			myAnimator.SetFloat ("VSpeed", 1.0f);
		} else if(state == 5){
			//this.setPosition Make sure he doesn't sink
			myAnimator.SetFloat ("VSpeed", 0.0f);
		} else if(state == 6){
			otherScript.setSplineObject (SplineRootGroup [3], SplineRootDurationGroup[3]);
			otherScript.FollowSpline ();
			print (otherScript.SplineRoot);
			myAnimator.SetFloat ("VSpeed", 1.0f);
		} else if(state == 7){
			//this.setPosition Make sure he doesn't sink
			myAnimator.SetFloat ("VSpeed", 0.0f);
		} else if(state == 8){
			otherScript.setSplineObject (SplineRootGroup [4], SplineRootDurationGroup[4]);
			otherScript.FollowSpline ();
			print (otherScript.SplineRoot);
			myAnimator.SetFloat ("VSpeed", 1.0f);
		} else if(state == 9){
			//this.setPosition Make sure he doesn't sink
			myAnimator.SetFloat ("VSpeed", 0.0f);
		}



	}
}
