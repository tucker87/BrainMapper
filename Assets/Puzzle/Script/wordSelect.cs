using UnityEngine;
using System.Collections;

public class wordSelect : MonoBehaviour {

	void Start() {
		print ("Start");
		TextMesh Word1 = (TextMesh)this.GetComponentInChildren (typeof(TextMesh));
		Word1.text = "Test";
	}

	int speed;
	float friction, lerpSpeed;
	private float xDeg;
	private float yDeg;
	private Quaternion fromRotation;
	private Quaternion toRotation;

	
	// Update is called once per frame
	void Update () {
//		Vector3 mousePosition = Input.mousePosition;
//		Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint (mousePosition);
//		float targetPosition = Mathf.Clamp (worldMousePosition.y,-360,360);
//		Vector3 currentPosition = transform.rotation;
//		currentPosition.y = Mathf.MoveTowards (currentPosition.y, targetPosition, maxUnitsPerSecond);
//		transform.rotation = currentPosition;
		lerpSpeed = 1;

		if (Input.GetMouseButton (0)) {
			xDeg -= Input.GetAxis ("Mouse X");
			yDeg += Input.GetAxis ("Mouse Y");
			fromRotation = transform.rotation;
			toRotation = Quaternion.Euler (yDeg, 0, 0);
			transform.Rotate(5,0,0,Space.World);
			//transform.Rotate = Quaternion.Lerp (fromRotation, toRotation, Time.deltaTime * lerpSpeed);
		}
	}
}
