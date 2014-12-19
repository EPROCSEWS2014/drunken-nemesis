using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {
	
	float fadeSpeed = 0.01f;
	int sceneStarting = 0;
	
	void Awake()
	{
		guiTexture.pixelInset = new Rect (0f, 0f, Screen.width, Screen.height);
		//Destroy (GameObject.FindWithTag ("Player"));
		//Destroy (GameObject.FindWithTag ("MainCamera"));
		//Destroy (GameObject.FindWithTag ("EnemyC"));
	}
	
	void Update () 
	{
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
		
		
		if (sceneStarting==1) // Check if the scene is ending and..
		{
			guiTexture.enabled = true; // .. enable the fader.png
			guiTexture.color = Color.Lerp (guiTexture.color, Color.black, fadeSpeed); // Set down the transparency..
			if (guiTexture.color.a >= 0.40f) //.. until 40% and..
			{
				Application.LoadLevel("MainMenu");
			}
		}
	}
}
