using UnityEngine;
using System.Collections;

public class PlayerLogic : MonoBehaviour {

	public Transform[] thingsThatMakePanic;
	float[] distance;
	public Transform player;
	public int triggerDistance;

	// Use this for initialization
	void Start () {

		if(player == null) {
			Debug.LogError("Please assign a player object");

		}else if(thingsThatMakePanic[0] == null){
			Debug.LogError("Please assign at least a enemy object");
		}
		distance = new float[thingsThatMakePanic.Length];

	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < thingsThatMakePanic.Length; i++){
			distance[i] = Vector2.Distance(thingsThatMakePanic[i],player);


			if(distance[i] <= triggerDistance){

				istNaheMonster = true;

			}else if(i+1 == thingsThatMakePanic.Length){

				istNaheMonster = false;
			}

		}

	}



}
