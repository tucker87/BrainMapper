using UnityEngine;
using System.Collections;

public class upButton : MonoBehaviour {

	//Which wordSelect Object this button controls.
	public int controls;


	// Use this for initialization
	void Start () {
		GameObject[] WordSelect = GameObject.FindGameObjectsWithTag("WordSelector");

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseUpAsButton() {

	}
}
