using UnityEngine;
using System.Collections;

public class SnapAPhoto : MonoBehaviour {

	public AudioSource snapSound;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
			if(Input.GetButton("Fire2") && !snapSound.isPlaying){
					snapSound.Play();

			}

	}
}
