using UnityEngine;
using System.Collections;

public class MainNarrative : MonoBehaviour {
	public bool experienceHasStarted = false;
	private AudioSource[] intialAudio;

	// Use this for initialization
	void Start () {
		intialAudio = GetComponents<AudioSource>();

	}

	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Fire1") && !experienceHasStarted){
			experienceHasStarted = true;
			intialAudio[1].Play();

		}
	}
}
