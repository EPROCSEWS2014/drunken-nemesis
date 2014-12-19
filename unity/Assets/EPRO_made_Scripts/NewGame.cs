using UnityEngine;
using System.Collections;

public class NewGame : MonoBehaviour {

	float fadeSpeed = 0.01f;
	int sceneStarting = 0;
	Transform TitelS;
	Transform Keys;

	void Awake()
	{
		guiTexture.pixelInset = new Rect (0f, 0f, Screen.width, Screen.height);
		TitelS = GameObject.Find ("Titelbild").transform;
		Keys = GameObject.Find ("Keys").transform;
		Keys.renderer.sortingLayerID = 2;
	}

	void Update () {
		if (sceneStarting==0) // Check if the scene is starting and..
		{
			guiTexture.color = Color.Lerp (guiTexture.color, Color.clear, fadeSpeed); // Set up the transparency..
			if (guiTexture.color.a <= 0.0f) //.. until 0%,..
			{
				guiTexture.color = Color.clear; //.. clear the color and..
				guiTexture.enabled = false; //.. disable the fader.png.
			}
		} 

		if (Input.GetKeyDown (KeyCode.Return)) 
		{
			sceneStarting += 1;
		}

		if (sceneStarting == 1) 
		{
			TitelS.gameObject.SetActive(false);
			Keys.renderer.sortingLayerID = 0;
		}

		if (sceneStarting==2) // Check if the scene is ending and..
		{
			guiTexture.enabled = true; // .. enable the fader.png
			guiTexture.color = Color.Lerp (guiTexture.color, Color.black, fadeSpeed); // Set down the transparency..
			if (guiTexture.color.a >= 0.40f) //.. until 40% and..
			{
				Application.LoadLevel("alpha");
			}
		}
	}
}
