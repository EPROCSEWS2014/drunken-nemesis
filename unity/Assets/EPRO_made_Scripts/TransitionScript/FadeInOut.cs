using UnityEngine;
using System.Collections;

public class FadeInOut : MonoBehaviour 
{
	public float fadeSpeed = 0.05f; //The fade in and out speed. Can be changed in Unity.
	public static bool sceneStarting = true; //Bool to start fade in (true) or out (false).
	
	void Awake()
	{
		guiTexture.pixelInset = new Rect (0f, 0f, Screen.width, Screen.height);
	}

	void Update()
	{
		if (sceneStarting) // Check if the scene is starting and..
		{
			guiTexture.color = Color.Lerp (guiTexture.color, Color.clear, fadeSpeed); // Set up the transparency..
			if (guiTexture.color.a <= 0.0f) //.. until 0%,..
			{
				guiTexture.color = Color.clear; //.. clear the color and..
				guiTexture.enabled = false; //.. disable the fader.png.
			}
		} 

		if (!sceneStarting) // Check if the scene is ending and..
		{
			guiTexture.enabled = true; // .. enable the fader.png
			guiTexture.color = Color.Lerp (guiTexture.color, Color.black, fadeSpeed); // Set down the transparency..
			if (guiTexture.color.a >= 0.40f) //.. until 40% and..
			{
				sceneStarting = true; //.. set sceneStarting to true to set up the transparency.
			}
		}
	}
}
