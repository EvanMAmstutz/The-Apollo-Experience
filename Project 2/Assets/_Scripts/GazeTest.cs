using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class GazeTest : MonoBehaviour {

	public Material mat1;
	public Material mat2;
	public GameObject gazeCube;
	private int currentMaterial = 0;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void stareAtCube(){
		switch(currentMaterial){
				case(0):
					gazeCube.GetComponent<Renderer>().material = mat2;
					currentMaterial++;
					break;
				case(1):
					gazeCube.GetComponent<Renderer>().material = mat1;
					currentMaterial = 0;
					break;

		}

	}
}
