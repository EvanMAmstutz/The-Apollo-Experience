using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class RockDestroyer : MonoBehaviour {

public GameObject referenceToBuzz;
public GameObject referenceToNeil;
public AudioSource pickupRock;

	// This is written from the perspective of the rock



	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void destroyRock(){

			float distance = Vector3.Distance(this.transform.position, referenceToBuzz.transform.position);
			print("distance from rock: " + distance);
			if(distance < 5.0 &&  (referenceToNeil.GetComponent<JumpAnimationScript>().state == 1 || referenceToNeil.GetComponent<JumpAnimationScript>().state == 3  || referenceToNeil.GetComponent<JumpAnimationScript>().state == 5 )){
					pickupRock.Play();
					gameObject.GetComponent<MeshRenderer>().enabled = false;
					(referenceToBuzz.GetComponent<MainNarrative>()).hasRock=true;
			}


	}


}
