using UnityEngine;
using System.Collections;


public class PlayerLogic : MonoBehaviour {

	public Transform[] thingsThatMakePanic;
	public Transform player;
	public int triggerDistance = 5;

	float distance;
	int panikLevel = 100;
	bool istNaheMonster;

	// Use this for initialization
	void Start () {

		if(player == null) {
			Debug.LogError("Please assign a player object");

		}else if(thingsThatMakePanic[0] == null){
			Debug.LogError("Please assign at least an enemy object");
		}else{
		


		}


	}


	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < thingsThatMakePanic.Length; i++){
			distance = Vector2.Distance(makeVector3To2(thingsThatMakePanic[i]),makeVector3To2(player));
			
			if( (i+1) == thingsThatMakePanic.Length  & distance >= triggerDistance){

				istNaheMonster = false;
				Debug.Log(istNaheMonster);

			}else if(distance <= triggerDistance){

				istNaheMonster = true;

				//Debug.Log(istNaheMonster);
				
			}

	
	}

  
		}

	Vector2 makeVector3To2(Transform t){

<<<<<<< HEAD
		for(int i = 0; i < thingsThatMakePanic.Length; i++){
			distance[i] = Vector2.Distance(thingsThatMakePanic[i],player);

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
=======
		return new Vector2(t.position.x,t.position.y);
>>>>>>> origin/Player

	}



	void decreaseSanity (int height){
				panikLevel = panikLevel - height;
				if (panikLevel == 0) {
						Debug.Log ("PANIK!!!");
				} else {
						if (panikLevel == 100) {
								Debug.Log ("Vollständige Vitalität!");
						} else {
								if (panikLevel + height > 100 || panikLevel - height < 0) {
										Debug.LogError ("Geht nicht, gibts nicht!");
								}
						}
				}

		
				switch (panikLevel) {
				case 50: //Veränderte Sicht , Blur
						break;
				case 40: //Einschränkungen in der Bewegung
						break;
				case 30: //Schwere Atmung, Geräusche
						break;
				case 20: //Halluzinationen , Scheinmonster
						break;
				case 10: //Verfolgungswahn, Kontrollverlust
						break;
				case 0: //Absolute Panik
						break;
				}
		}

		

	void regainSanity (int height){
			decreaseSanity(-height);
		}

	}



}
