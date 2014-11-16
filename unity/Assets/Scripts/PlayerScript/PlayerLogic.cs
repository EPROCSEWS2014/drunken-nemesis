using UnityEngine;
using System.Collections;

public class PlayerLogic : MonoBehaviour {

	public Transform[] thingsThatMakePanic;
	float[] distance;
	public Transform player;
	public int triggerDistance;

	// Use this for initialization
	void Start () {
		int panikLevel = 100;
		int panikLevel_max = 100;
		boolean istNaheMonster;
	

		if(player == null) {
			Debug.LogError("Please assign a player object");

		}else if(thingsThatMakePanic[0] == null){
			Debug.LogError("Please assign at least a enemy object");
		}
		distance = new float[thingsThatMakePanic.Length];
		
	}
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD


	
	}
    int doPanic (int height){
				if (istNaheMonster == true) {
						panikLevel = panikLevel - height;

				} else {
						if (panikLevel == panikLevel_max) {
								Debug.Log ("Vitality Full");
			            
						} else {
								panikLevel = panikLevel + height;
				     
				            
			            
						}
				}
		}
		switch (panikLevel){
			case 100 : //Keine Änderung

			case 50 : //Veränderte Sicht , Blur

			case 40 : //

			case 30 : //

			case 20 : //

			case 10 : //

			case 0 : //

		}
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
