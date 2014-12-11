using UnityEngine;
using System.Collections;

public class NewGame : MonoBehaviour {

	//public GameObject player;
	// Use this for initialization
	GameObject StartPosition;
	static int PlayerSet = 0;

	void Start () {
		if (PlayerSet == 0) 
		{
			Transform player = (Instantiate (Resources.Load ("2DCharacter")) as GameObject).transform;
			StartPosition = GameObject.Find ("StartPosition");
			player.transform.position = StartPosition.transform.position;
			player.transform.position = player.transform.position;

			PlayerSet = 1;
		}
	}
}
