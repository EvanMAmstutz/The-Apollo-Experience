using UnityEngine;
using System.Collections;

public class JumpAnimationScript : MonoBehaviour {

	public GameObject[] SplineRootGroup;
	SplineController otherScript;

	private Animator myAnimator;

	bool jump;

	// Use this for initialization
	void Start () {

		this.otherScript = this.GetComponent<SplineController>();

		print (otherScript.SplineRoot);

		myAnimator = GetComponent<Animator> ();
		jump = false;

		myAnimator.SetFloat ("VSpeed", 1);
	}
	
	// Update is called once per frame
	void Update () {

		int i = 0;
		if(Input.GetKeyDown (KeyCode.Alpha1)){
			otherScript.setSplineObject (SplineRootGroup [0]);
			print (otherScript.SplineRoot);
		} else if(Input.GetKeyDown (KeyCode.Alpha2)){
			otherScript.setSplineObject (SplineRootGroup [1]);
			print (otherScript.SplineRoot);
		} else if(Input.GetKeyDown (KeyCode.Alpha3)){
			otherScript.setSplineObject (SplineRootGroup [2]);
			print (otherScript.SplineRoot);
		}

		if(Input.GetKeyDown (KeyCode.Alpha4)){
			otherScript.FollowSpline ();
		}
//
//		if(Input.GetKeyDown (KeyCode.W) == true){
//			jump = !jump;
//		}
//
//		if (jump) {
//			myAnimator.SetFloat ("VSpeed", 1.0f);
//		} else {
//			myAnimator.SetFloat ("VSpeed", 0.0f);
//		}
//

		myAnimator.SetFloat ("VSpeed", 1);

	}
}
