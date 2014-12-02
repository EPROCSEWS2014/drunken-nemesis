using UnityEngine;
using System.Collections;

public class LightCameraFollow : MonoBehaviour {

	public float positionX;
	public float positionY;
	private Transform player;
	private bool boolean = true;


	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	
	void Update () {
		Track();
	}

	bool CheckRight () {
		return Input.GetKeyDown (KeyCode.D) && !boolean;
	}
	bool CheckLeft () {
		return Input.GetKeyDown (KeyCode.A) && boolean;
	}

	void Track () {
		float targetX = player.position.x + positionX;
		float targetY = player.position.y - positionY;
		float scale = player.localScale.x;
		Vector3 vectora = new Vector3 (0, 240, 0);
		Vector3 vectorb = new Vector3 (0, 120, 0);

		if (CheckRight ()) {
			transform.rotation = new Quaternion(0,0.5f,0,0);
			transform.Rotate(vectora);
			positionX = -2;
			boolean = true;
		} 
		if (CheckLeft ()) {
			transform.rotation = new Quaternion(0,0.5f,0,0);;
			transform.Rotate(vectorb);
			positionX = 2;
			boolean = false;
		}

		transform.position = new Vector3(targetX, targetY, transform.position.z);
	}

}
