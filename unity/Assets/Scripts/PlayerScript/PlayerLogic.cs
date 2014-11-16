using UnityEngine;
using System.Collections;


public class PlayerLogic : MonoBehaviour {

	public Transform[] thingsThatMakePanic;
	public Transform player;
	public int triggerDistance;

	float[] distance;
	int panikLevel = 100;
	int panikLevelmax = 100;
	bool istNaheMonster;

	// Use this for initialization
	void Start () {



		if(player == null) {
			Debug.LogError("Please assign a player object");

		}else if(thingsThatMakePanic[0] == null){
			Debug.LogError("Please assign at least an enemy object");
		}else{
			distance = new float[thingsThatMakePanic.Length];


		}



	}


	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < thingsThatMakePanic.Length; i++){
			distance[i] = Vector2.Distance(makeVector3To2(thingsThatMakePanic[i]),makeVector3To2(player));
			
			
			if(distance[i] <= triggerDistance){
				
				istNaheMonster = true;
				
			}else if(i+1 == thingsThatMakePanic.Length){
				
				istNaheMonster = false;
			}


	
	}
  
		}

	Vector2 makeVector3To2(Transform t){

		return new Vector2(t.position.x,t.position.y);

	}



	void doPanic (int height){
		if (istNaheMonster == true) {
			panikLevel = panikLevel - height;
			
		} else {
			if (panikLevel == panikLevelmax) {
				Debug.Log("Vitality Full");
				
			} else {
				panikLevel = panikLevel + height;
				
				
				
			}
		}

		switch (panikLevel){
		case 100 : //Keine Änderung
			break;
		case 50 : //Veränderte Sicht , Blur
			break;
		case 40 : //
			break;
		case 30 : //
			break;
		case 20 : //
			break;
		case 10 : //
			break;
		case 0 : //
			break;
		}




		}

	}





