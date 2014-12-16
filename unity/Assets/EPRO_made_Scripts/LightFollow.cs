using UnityEngine;
using System.Collections;

public class LightFollow : MonoBehaviour {
    
	private float lightPositionX = -2;
	public float lightPositionY;

	private Transform player;

    private Transform rota;
    private Transform rotb;

	private Transform lightT;

	private Quaternion leftPos = new Quaternion (0f,0.5f,0f,1f);
	private Quaternion rightPos = new Quaternion (0f,-0.5f,0f,1f);


	void Awake() {
		player = GameObject.FindGameObjectWithTag("Player").transform;
        rota = GameObject.FindGameObjectWithTag("rota").transform;
        rotb = GameObject.FindGameObjectWithTag("rotb").transform;
		lightT = gameObject.transform;


	}
	
	void Update() {
	

		Track();

	}


	bool CheckRight() {
		return (player.localScale.x >= 0);
	}


	void Track() {

		Quaternion to;
		float targetX = player.position.x;
		float targetY = player.position.y - lightPositionY;

        if (CheckRight())
        {

			to = leftPos;
		//	from = leftPos;
			targetX += lightPositionX;
     		
        }
        else
        {
			to = rightPos;
		//	from = rightPos;
			targetX -= lightPositionX;


        }
		Debug.Log (to.y);
		if (!(Mathf.Abs(lightT.rotation.y-to.y) <= 0.1 && to.y >= 0)) {
						lightT.rotation = Quaternion.Lerp (lightT.rotation, to, Time.deltaTime * 5);
		} 



		lightT.position = new Vector3(targetX, targetY, transform.position.z);


	}




}
