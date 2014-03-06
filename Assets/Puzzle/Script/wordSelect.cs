//Handles Word Selector's Word Lists, Buttons and Rotation.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class wordSelect : MonoBehaviour {

	//Word object to spawn
	public GameObject textObject;
	//Set in Unity properties to determine which wordList is used.
	public int wordOrder;
	//Variables for rotation
	private float speed;
	private float targetAngle;
	private int step;


	//Draw Up/Down buttons
	void OnGUI() {
		//Gets objects position on the screen
		Vector3 screenPosition = Camera.main.WorldToScreenPoint (transform.position);

		//When button is pressed WordSelect rotates to reveal another word.
		if (GUI.Button (new Rect (screenPosition.x - 47, Screen.height - screenPosition.y - 60, 100, 30), "Up")) {
			targetAngle += step;
		}

		if (GUI.Button (new Rect (screenPosition.x - 47, Screen.height - screenPosition.y + 30, 100, 30), "Down")) {
			targetAngle -= step;
		}
	}

	void Start() {
		//TODO: Word set will be defined be menus later. Hard coding for now.

		//Poorly coding in Lists just to learn how they work in C# TODO: Fix this
		List<List<string>> wordList = new List<List<string>>();
		List<string> words1 = new List<string>();
		List<string> words2 = new List<string>();
		List<string> words3 = new List<string>();

		words1.Add ("This");
		words1.Add ("That");
		words1.Add ("The");
		words1.Add ("They");

		words2.Add ("is");
		words2.Add ("are");
		words2.Add ("was");

		words3.Add ("Silly");
		words3.Add ("War");
		words3.Add ("Sparta");
		words3.Add("End");
		words3.Add ("What");

		wordList.Add (words1);
		wordList.Add (words2);
		wordList.Add (words3);
		//"This", "That", "The", "They"
		//"is", "are", "was"
		//"Silly", "War", "Sparta", "End", "What"

		speed = 4;
		targetAngle = 0;
		step = 360 / wordList[wordOrder].Count;

		//TODO: Change number of starting Text objects to match word lists. (Spawn from 0? Hide existing?)
		for (int i = 0; i < wordList[wordOrder].Count; i++) {
			GameObject Word = (GameObject)Instantiate (textObject, new Vector3 (transform.position.x, transform.position.y, transform.position.z - 0.35f), transform.rotation);
			Word.transform.parent = transform;
			print (wordOrder + " " + i + " " + wordList[wordOrder][i]);
			((TextMesh)Word.GetComponent(typeof(TextMesh))).text = wordList[wordOrder][i];
			Word.transform.Rotate (0, 0, 270);
			Word.transform.RotateAround(transform.position, new Vector3 (1,0,0), step * i);
			Word.name = "Word" + i;
		}
		//TODO: Randomize starting word? Or the list will always start the same. 
		//		Answers can be scrambled in the list to offset this for now.)

	}
	// Update is called once per frame
	void Update () {
		//Rotates cylinder to new angle
		float tiltAroundX = targetAngle;
		Quaternion target = Quaternion.Euler (tiltAroundX, 0, 90);
		transform.rotation = Quaternion.Slerp (transform.rotation, target, Time.deltaTime * speed);
	}
}
