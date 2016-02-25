using UnityEngine;
using System.Collections;

public class GoneTooFar : MonoBehaviour {
    
    public AudioSource goneTooFarAudio;
    public GameObject referencePointObject;
    public bool reachedMaxedDistance = false;
    public float maxDistance;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        float distance = Vector3.Distance(gameObject.transform.position, referencePointObject.transform.position);
        //print(distance);
        if(distance > maxDistance && !reachedMaxedDistance ){
            goneTooFarAudio.Play();
            reachedMaxedDistance = true;
            
        }
        
	
	}
}
