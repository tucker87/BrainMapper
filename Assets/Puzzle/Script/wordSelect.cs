using UnityEngine;
using System.Collections;

public class wordSelect : MonoBehaviour {

	//Set in Unity properties to determine which wordList is used.
	public int wordOrder;
	//Variables for rotation
	private float speed;
	private float targetAngle;
	private int step;

	void OnGUI() {
		//Gets objects position on the screen
		Vector3 screenPosition = Camera.main.WorldToScreenPoint (this.transform.position);

		//When button is pressed WordSelect rotates to reveal another word.
		if (GUI.Button (new Rect (screenPosition.x - 75, screenPosition.y - 125, 150, 50), "Test")) {
			targetAngle = targetAngle + step;
		}
		
	}

	void Start() {
		speed = 4;
		targetAngle = 0;

		//Word set will be defined be menus later. Hard coding for now.
		string[,] wordList = { { "This", "That", "The" }, { "is", "are", "was" }, { "Silly", "War", "Sparta" } };
		TextMesh[] wordObjects = (TextMesh[])GetComponentsInChildren<TextMesh>();
		step = 360 / wordObjects.Length;

		for (int i = 0; i < wordObjects.Length; i++) {
			wordObjects[i].text = wordList[wordOrder,i];

			//Attempt to force rotation around cylinder rather then repoitioning.
			Vector3 rotationMask = new Vector3(1,0,0);
			//wordObjects[i].transform.RotateAround(transform.position, rotationMask, step * Time.deltaTime);
			print(step);
			wordObjects[i].transform.RotateAround(transform.position, rotationMask, step * i);

		}
	}
	// Update is called once per frame
	void Update () {
		//Rotates cylinder to new angle
		float tiltAroundX = targetAngle;
		Quaternion target = Quaternion.Euler (tiltAroundX, 0, 90);
		transform.rotation = Quaternion.Slerp (transform.rotation, target, Time.deltaTime * speed);
	}
}
