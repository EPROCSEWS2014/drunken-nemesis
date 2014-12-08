using UnityEngine;
using System.Collections;

public class LevelChangeTemp : MonoBehaviour {
	public string LevelToChange; //String to choose the Level you want to teleport to
	public string LoadLevelOnTouch; //String to teleport with a simple touch
	public string LoadLevelOnReturn; // String to teleport with the return-button

    public AudioClip doorOpen;

	void OnTriggerStay2D(Collider2D touchSensor) //Need to check, who is in front of 
	{ 
		if(touchSensor.tag=="Player") //If the "Player" is in front of..
		{ 
			if (LoadLevelOnReturn!="" && Input.GetKeyDown(KeyCode.Return)) //.. check if string LoadLevelOnReturn is not empty and return is pressed to..
			{
				FadeInOut.sceneStarting = false; // set sceneStarting to false to fade out
				Application.LoadLevel(LevelToChange); //.. change the Level to "LeveltoChange". Name "LeveltoChange" in Unity.
                AudioSource.PlayClipAtPoint(doorOpen, transform.position, 1f);
			}

			if (LoadLevelOnTouch!="") //Check if string LoadLevelOnTouch is not empty to..
			{
				FadeInOut.sceneStarting = false; // set sceneStarting to false to fade out
				Application.LoadLevel(LevelToChange); //.. teleport on a simple touch like a warpgate
			}
		}
	}
}
