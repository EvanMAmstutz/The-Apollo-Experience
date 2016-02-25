using UnityEngine;
using System.Collections;

public class MainNarrative : MonoBehaviour {
    public int numOfRocksDelivered = 0;
    public bool hasRock = false;
    public AudioSource deliveredRock;
	public bool experienceHasStarted = false;
	public bool weDontSeeStars = false;
	public bool weDontSeeStarsHasPlayed = false;
	public AudioSource intialAudio;
    public AudioSource weDontSeeStarsAudio;
    public AudioSource whereAreTheStarsAudio;
	
    public bool youCanBunnyHop = false;
    public bool youCanBunnyHopPlayed = false;
    public GameObject referenceToNeil;
    public GameObject referenceToLunarModule;
    
    public bool startAudioStarted = false;

	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Fire1") && !experienceHasStarted){
			experienceHasStarted = true;
			intialAudio.Play();
			youCanBunnyHop = true;
			

		}

		if(youCanBunnyHop && !intialAudio.isPlaying && !youCanBunnyHopPlayed){
			referenceToNeil.GetComponent<JumpAnimationScript>().state = 0;
			youCanBunnyHopPlayed = true;
		}
        
        if(startAudioStarted && !whereAreTheStarsAudio.isPlaying){
            weDontSeeStarsAudio.Play(66150);
            startAudioStarted = false;
        }
	}
    
    public void TurnInRock(){
            
            //what we wish this assignment was...
            float distance = Vector3.Distance(gameObject.transform.position, referenceToLunarModule.transform.position );
            
            if(distance < 8.0 && hasRock){
                
                if(numOfRocksDelivered == 0){
                    referenceToNeil.GetComponent<JumpAnimationScript>().state = 2;
                    deliveredRock.Play();
                }
                
                if(numOfRocksDelivered == 1 ){
                    referenceToNeil.GetComponent<JumpAnimationScript>().state = 4;
                    whereAreTheStarsAudio.Play();
                    startAudioStarted = true;
                    
                }
                
                hasRock = false;
                numOfRocksDelivered++;
            }
            
        }
}
