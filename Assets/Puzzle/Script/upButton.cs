using UnityEngine;
using System.Collections;

public class upButton : MonoBehaviour {

	public float speed = 0.1f;
	public float targetAngle = 0;
	public int step = 90;
	private bool rotating = false;



	// Use this for initialization
	void Start () {
		GameObject WordSelect = GameObject.Find ("WordSelect1");
	}
	
	// Update is called once per frame
	void Update () {
		GameObject WordSelect = GameObject.Find ("WordSelect1");
		//float tiltAroundX = Input.GetAxis ("Vertical") * step;
		float tiltAroundX = targetAngle;
		Quaternion target = Quaternion.Euler (tiltAroundX, 0, 90);
		WordSelect.transform.rotation = Quaternion.Slerp (WordSelect.transform.rotation, target, Time.deltaTime * speed);
	}

	void OnMouseUpAsButton() {
		//When button is pressed WordSelect rotates to reveal another word.
		targetAngle = targetAngle + step;
	}
}
