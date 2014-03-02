using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public Texture backgroundTexture;

	void OnGUI() {
		//Display Background Texture
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);

		//Display Buttons

		if (GUI.Button (new Rect (Screen.width * .25f, Screen.height * .5f, Screen.width * .5f, Screen.height * .1f), "Play")) {
			print("Play game");
		}

	}
}
