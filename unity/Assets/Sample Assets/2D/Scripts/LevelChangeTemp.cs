using UnityEngine;
using System.Collections;

public class LevelChangeTemp : MonoBehaviour {
	public string LeveltoChange; //String to choose the Level you want to teleport to

	void OnTriggerStay2D(Collider2D touchSensor) //Need to check, who is in front of 
	{ 
		if(touchSensor.tag=="Player") //If the "Player" is in front of..
		{ 
			if (Input.GetKeyDown(KeyCode.Return)) //.. check if return is pressed to..
			{
				Application.LoadLevel(LeveltoChange); //.. change the Level to "LeveltoChange". Name "LeveltoChange" in Unity.
			}
		}
	}
}
