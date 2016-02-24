using UnityEngine;
using System.Collections;

public class JumpAnimationScript : MonoBehaviour {

	public GameObject player;
	public int turnSpeed = 5;

	public GameObject[] SplineRootGroup;
	public float[] SplineRootDurationGroup;
	SplineController otherScript;

	public int state;
	private bool splineIsRunning;
	private float timePast;

	private Animator myAnimator;

	bool jump;

	// Use this for initialization
	void Start () {

		this.otherScript = this.GetComponent<SplineController>();
		state = 0;
		splineIsRunning = false;
		timePast = 0.0f;

		print (otherScript.SplineRoot);

		myAnimator = GetComponent<Animator> ();
		myAnimator.SetFloat ("VSpeed", 1.0f);
	}
	
	// Update is called once per frame
	void Update () {

		if(state == 0){
			if (!splineIsRunning) {

//				otherScript.setSplineObject (SplineRootGroup [0], SplineRootDurationGroup[0]);
				otherScript.FollowSpline ();
				print (otherScript.SplineRoot);
				myAnimator.SetFloat ("VSpeed", 1.0f);

				splineIsRunning = true;
				timePast = Time.realtimeSinceStartup;

			} else {
				if(Time.realtimeSinceStartup - timePast >= SplineRootDurationGroup[0]){
					splineIsRunning = false;
					timePast = 0;
					state = 1;
				}
			}
		} else if(state == 1){
			//this.setPosition Make sure he doesn't sink
			myAnimator.SetFloat ("VSpeed", 0.0f);

			var targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

			//Just for Testing
			if (!splineIsRunning) {
				splineIsRunning = true;
				timePast = Time.realtimeSinceStartup;

			} else {
				if(Time.realtimeSinceStartup - timePast >= SplineRootDurationGroup[0]){
					splineIsRunning = false;
					timePast = 0;
					state = 2;
				}
			}
			////////////
		} else if(state == 2){
			if (!splineIsRunning) {

				otherScript.setSplineObject (SplineRootGroup [1], SplineRootDurationGroup[1]);
				otherScript.FollowSpline ();
				print (otherScript.SplineRoot);
				myAnimator.SetFloat ("VSpeed", 1.0f);

				splineIsRunning = true;
				timePast = Time.realtimeSinceStartup;

			} else {
				if(Time.realtimeSinceStartup - timePast >= SplineRootDurationGroup[1]){
					splineIsRunning = false;
					timePast = 0;
					state = 3;
				}
			}
		} else if(state == 3){
			//this.setPosition Make sure he doesn't sink
			myAnimator.SetFloat ("VSpeed", 0.0f);

			var targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

			//Just for Testing
			if (!splineIsRunning) {
				splineIsRunning = true;
				timePast = Time.realtimeSinceStartup;

			} else {
				if(Time.realtimeSinceStartup - timePast >= SplineRootDurationGroup[0]){
					splineIsRunning = false;
					timePast = 0;
					state = 2;
				}
			}
			////////////
		} else if(state == 4){
			if (!splineIsRunning) {

				otherScript.setSplineObject (SplineRootGroup [2], SplineRootDurationGroup[2]);
				otherScript.FollowSpline ();
				print (otherScript.SplineRoot);
				myAnimator.SetFloat ("VSpeed", 1.0f);

				splineIsRunning = true;
				timePast = Time.realtimeSinceStartup;

			} else {
				if(Time.realtimeSinceStartup - timePast >= SplineRootDurationGroup[2]){
					splineIsRunning = false;
					timePast = 0;
					state = 5;
				}
			}
		} else if(state == 5){
			//this.setPosition Make sure he doesn't sink
			myAnimator.SetFloat ("VSpeed", 0.0f);

			var targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

			//Just for Testing
			if (!splineIsRunning) {
				splineIsRunning = true;
				timePast = Time.realtimeSinceStartup;

			} else {
				if(Time.realtimeSinceStartup - timePast >= SplineRootDurationGroup[0]){
					splineIsRunning = false;
					timePast = 0;
					state = 2;
				}
			}
			////////////
		} else if(state == 6){
			if (!splineIsRunning) {

				otherScript.setSplineObject (SplineRootGroup [3], SplineRootDurationGroup[3]);
				otherScript.FollowSpline ();
				print (otherScript.SplineRoot);
				myAnimator.SetFloat ("VSpeed", 1.0f);

				splineIsRunning = true;
				timePast = Time.realtimeSinceStartup;

			} else {
				if(Time.realtimeSinceStartup - timePast >= SplineRootDurationGroup[3]){
					splineIsRunning = false;
					timePast = 0;
					state = 7;
				}
			}
		} else if(state == 7){
			//this.setPosition Make sure he doesn't sink
			myAnimator.SetFloat ("VSpeed", 0.0f);

			var targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

			//Just for Testing
			if (!splineIsRunning) {
				splineIsRunning = true;
				timePast = Time.realtimeSinceStartup;

			} else {
				if(Time.realtimeSinceStartup - timePast >= SplineRootDurationGroup[0]){
					splineIsRunning = false;
					timePast = 0;
					state = 2;
				}
			}
			////////////
		}
	}
}
