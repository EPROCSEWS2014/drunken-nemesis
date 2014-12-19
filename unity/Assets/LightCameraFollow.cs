using UnityEngine;
using System.Collections;

public class LightCameraFollow : MonoBehaviour {

	public float positionX;
	public float positionY;
	private Transform player;
	private bool boolean = true;

	void Awake() {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		//DontDestroyOnLoad (this);
	}
	
	void Update() {
		Track();
	}


	bool CheckRight() {
		return !(Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow));
	}

	bool CheckLeft() {
		return !(Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow));
	}

	void Track() {
		float targetX = player.position.x + positionX;
		float targetY = player.position.y - positionY;
		float scale = player.localScale.x;
		Vector3 vectora = new Vector3 (0, 240, 0);
		Vector3 vectorb = new Vector3 (0, 120, 0);

        if (CheckLeft() && !boolean) {
            transform.rotation = new Quaternion(0, 0.5f, 0, 0);
            transform.Rotate(vectorb);
            positionX = 2;
        } else {
            boolean = true;
        }
		if (CheckRight () && boolean) {
			transform.rotation = new Quaternion(0, 0.5f, 0, 0);
			transform.Rotate(vectora);
			positionX = -2;
		} else {
            boolean = false;
        }

		transform.position = new Vector3(targetX, targetY, transform.position.z);
	}
}
