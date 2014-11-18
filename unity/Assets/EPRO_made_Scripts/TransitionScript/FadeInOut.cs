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
			guiTexture.color = Color.Lerp (guiTexture.color, Color.clear, fadeSpeed); 
			if (guiTexture.color.a <= 0.0f) 
			{
				guiTexture.color = Color.clear;
				guiTexture.enabled = false;
			}
		} 

		if (!sceneStarting)
		{
			guiTexture.enabled = true;
			guiTexture.color = Color.Lerp (guiTexture.color, Color.black, fadeSpeed);
			if (guiTexture.color.a >= 0.40f)
			{
				sceneStarting = true;
			}
		}
	}
}
