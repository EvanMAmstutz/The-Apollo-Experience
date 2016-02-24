using UnityEngine;
using System.Collections;

public class MainNarrative : MonoBehaviour {
	public bool experienceHasStarted = false;
	public bool weDontSeeStars = false;
	public bool weDontSeeStarsHasPlayed = false;
	public AudioSource intialAudio;
	public AudioSource weDontSeeStarsAudio;

	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Fire1") && !experienceHasStarted){
			experienceHasStarted = true;
			intialAudio.Play();
			weDontSeeStars = true;
			

		}

		if(weDontSeeStars && !intialAudio.isPlaying && !weDontSeeStarsHasPlayed){
			weDontSeeStarsAudio.Play();
			weDontSeeStarsHasPlayed = true;


		}
	}
}
