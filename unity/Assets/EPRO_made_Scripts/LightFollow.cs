using UnityEngine;
using System.Collections;

public class LightFollow : MonoBehaviour {
    
	private float lightPositionX = -2;
	public float lightPositionY;

	private Transform player;
//	private bool boolean = true;
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
		return (player.localScale.x >= 0);
		//return !(Input.GetKey (KeyCode.A));
	}
	/*
	bool CheckLeft() {

		return !(Input.GetKey (KeyCode.D));
	}*/

	void Track() {
		float targetX = player.position.x + lightPositionX;
		float targetY = player.position.y - lightPositionY;
//      Vector3 vectora = new Vector3(0, 240, 0);
//		Vector3 vectorb = new Vector3 (0, 120, 0);
        Quaternion to;
        Quaternion from;
        
	/*	if (!CheckRight())
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
        }*/
        if (CheckRight())
        {
            to = rota.rotation;
			from = rotb.rotation;
            //transform.rotation = new Quaternion(0, 0.5f, 0, 0);
            //transform.Rotate(vectora);
            //positionX = -2;
        }
        else
        {
           // boolean = false;
            to = rotb.rotation;
			from = rota.rotation;
        }

        transform.rotation = Quaternion.Lerp(from, to, Time.deltaTime * 1);
		transform.position = new Vector3(targetX, targetY, transform.position.z);
	}
}
