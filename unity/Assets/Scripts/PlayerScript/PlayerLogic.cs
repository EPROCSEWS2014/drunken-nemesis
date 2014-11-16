using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Transform))]
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
<<<<<<< HEAD
		int panikLevel = 100;
		int panikLevel_max = 100;
		boolean istNaheMonster;
	
=======


>>>>>>> origin/master

		if(player == null) {
			Debug.LogError("Please assign a player object");

		}else if(thingsThatMakePanic[0] == null){
			Debug.LogError("Please assign at least an enemy object");
		}
		distance = new float[thingsThatMakePanic.Length];
<<<<<<< HEAD
		
=======


>>>>>>> origin/master
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

	int doPanic (int height){
		if (istNaheMonster == true) {
			panikLevel = panikLevel - height;
			
		} else {
			if (panikLevel == panikLevelmax) {
				Debug.Log("Vitality Full");
				
			} else {
				panikLevel = panikLevel + height;
				
				
				
			}
		}
<<<<<<< HEAD
		for(int i = 0; i < thingsThatMakePanic.Length; i++){
			distance[i] = Vector2.Distance(thingsThatMakePanic[i],player);
=======
>>>>>>> origin/master

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

<<<<<<< HEAD
=======

>>>>>>> origin/master



