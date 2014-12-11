using UnityEngine;
using System.Collections;

public class LevelChangeTemp : MonoBehaviour {
	public string LevelToChange; //String to choose the Level you want to teleport to
	public string LoadLevelOnTouch; //String to teleport with a simple touch
	public string LoadLevelOnReturn; // String to teleport with the return-button
	public string DoorTagToTeleport;
	static string DoorTagTemp;
	Transform Door;
	Transform player;
	int CharWasHere = 0;

    public AudioClip doorOpen;

	void Awake()
	{
		if (CharWasHere == 1) {
						GameObject.Find ("2DCharacter").SetActive (false);
				}
		if (DoorTagTemp!=null)
		{
			player = GameObject.FindWithTag ("Player").transform;
			Door = GameObject.Find(DoorTagTemp).transform;
			player.transform.position = Door.transform.position;
		}else{
			if(GameObject.Find ("StartPosition")){

			}else{
			player = GameObject.FindWithTag ("Player").transform;
			player.transform.position = player.transform.position;
			}
		}

	}

	void OnTriggerStay2D(Collider2D touchSensor) //Need to check, who is in front of 
	{ 
		if(touchSensor.tag=="Player") //If the "Player" is in front of..
		{ 
			if (LoadLevelOnReturn!="" && Input.GetKeyDown(KeyCode.Return)) //.. check if string LoadLevelOnReturn is not empty and return is pressed to..
			{
				DoorTagTemp = DoorTagToTeleport;
				FadeInOut.sceneStarting = false; // set sceneStarting to false to fade out
				Application.LoadLevel(LevelToChange); //.. change the Level to "LeveltoChange". Name "LeveltoChange" in Unity.
                AudioSource.PlayClipAtPoint(doorOpen, transform.position, 1f);
				CharWasHere=1;

				//Debug.Log(DoorTagTemp);
			}

			if (LoadLevelOnTouch!="") //Check if string LoadLevelOnTouch is not empty to..
			{
				FadeInOut.sceneStarting = false; // set sceneStarting to false to fade out
				Application.LoadLevel(LevelToChange); //.. teleport on a simple touch like a warpgate
			}
		}
	}
}
