﻿using UnityEngine;
using System.Collections;

public class LightFollow : MonoBehaviour
{
	private float lightPositionX = -2;

	private Transform player;

    private Transform lightT;
	private float b = 0.000000001f;
	private Quaternion leftPos = new Quaternion (0,0.5f,0,1);
	private Quaternion rightPos = new Quaternion (0,-0.5f,0,1);


	void Awake() 
    {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		lightT = gameObject.transform;
	}
	
	void Update() 
    {
		Track();
	}

	void Track()
    {
		Quaternion to;

		float targetX = player.position.x;
		float targetY = player.position.y;

        if (player.localScale.x >= 0)
        {
			to = leftPos;
			targetX += lightPositionX;
        }
        else
        {
			to = rightPos;
			targetX -= lightPositionX;
        }

<<<<<<< HEAD
		if (to.y >= 0 || to.y <= 0) {
=======
		if (Mathf.Abs(lightT.rotation.y-to.y) >= b) {
>>>>>>> origin/master
			lightT.rotation = Quaternion.Lerp (lightT.rotation, to, Time.deltaTime * 5);
		} 

		lightT.position = new Vector3(targetX, targetY, transform.position.z);
	}
}
