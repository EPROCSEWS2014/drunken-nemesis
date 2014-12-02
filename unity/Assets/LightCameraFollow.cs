using UnityEngine;
using System.Collections;

public class LightCameraFollow : MonoBehaviour {

	public float xPosition = -2;
	private Transform player;
	private Transform rota;
	private Transform rotb;


	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		rota = GameObject.FindGameObjectWithTag("rota").transform;
		rotb = GameObject.FindGameObjectWithTag("rotb").transform;
	}
	
	
	void Update () {
		Track();
		float scale = player.localScale.x;
	}

	void Track () {
		float targetX = player.position.x + xPosition;
		float targetY = player.position.y;

		float scale = player.localScale.x;

		if (scale > 0) {
			transform.rotation = rota.rotation;
			xPosition = -2;
		} 
		else {
			transform.rotation = rotb.rotation;
			xPosition = 2;
		}

		transform.position = new Vector3(targetX, targetY, transform.position.z);
	}

}
