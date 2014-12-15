using UnityEngine;
using System.Collections;

public class LightFollow : MonoBehaviour {
    private float positionX = -2;
	public float positionY;
	private Transform player;
	private bool boolean = true;
    private Transform rota;
    private Transform rotb;

	void Awake() {
		player = GameObject.FindGameObjectWithTag("Player").transform;
        rota = GameObject.FindGameObjectWithTag("rota").transform;
        rotb = GameObject.FindGameObjectWithTag("rotb").transform;
	}
	
	void Update() {
		Track();
	}


	bool CheckRight() {
		return !(Input.GetKey (KeyCode.A));
	}

	bool CheckLeft() {
		return !(Input.GetKey (KeyCode.D));
	}

	void Track() {
		float targetX = player.position.x + positionX;
		float targetY = player.position.y - positionY;
        Vector3 vectora = new Vector3(0, 240, 0);
		Vector3 vectorb = new Vector3 (0, 120, 0);
        Quaternion to;
        Quaternion from = transform.rotation;
        if (CheckLeft() && !boolean)
        {
            to = rotb.rotation;
            //transform.rotation = new Quaternion(0, 0.5f, 0, 0);
            //transform.Rotate(vectorb);
            positionX = 2;
        }
        else
        {
            boolean = true;
            to = rota.rotation;
        }
        if (CheckRight() && boolean)
        {
            to = rota.rotation;
            //transform.rotation = new Quaternion(0, 0.5f, 0, 0);
            //transform.Rotate(vectora);
            //positionX = -2;
        }
        else
        {
            boolean = false;
            to = rotb.rotation;
        }

        transform.rotation = Quaternion.Lerp(from, to, Time.deltaTime * 1);
		transform.position = new Vector3(targetX, targetY, transform.position.z);
	}
}
