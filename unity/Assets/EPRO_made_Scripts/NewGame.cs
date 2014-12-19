using UnityEngine;
using System.Collections;

public class NewGame : MonoBehaviour {

	float fadeSpeed = 0.01f;
	int sceneStarting = 0;
	Transform TitelS;
	Transform TitelS1;
	Transform Keys;

	void Awake()
	{
		guiTexture.pixelInset = new Rect (0f, 0f, Screen.width, Screen.height);
		TitelS = GameObject.Find ("Titelbild").transform;
		//TitelS1 = GameObject.Find ("TitelbildSchrift").transform;
		Keys = GameObject.Find ("Keys").transform;
		Keys.renderer.sortingLayerID = 2;
		Keys.gameObject.SetActive (false);
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
			TitelS.renderer.material.color=new Color(1f,1f,1f,0f);
			//TitelS1.renderer.material.color=new Color(1f,1f,1f,0f);
			Keys.renderer.sortingLayerID = 0;
			Keys.gameObject.SetActive (true);
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
