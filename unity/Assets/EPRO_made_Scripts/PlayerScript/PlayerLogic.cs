using UnityEngine;
using System.Collections;


public class PlayerLogic : MonoBehaviour {
	
	public Transform thingsThatMakePanic;
	public Transform player;
	public int triggerDistance = 5;
	public int panicCap = 100;
	
	int panikLevel;

	float distance;
	bool istNaheMonster;
	
	// Use this for initialization
	void Start () {
		panikLevel = panicCap;
		if(player == null) {
			Debug.LogError("Please assign a player object");
			
		}else if(thingsThatMakePanic.GetChild(0) == null){
			Debug.LogError("Please assign at least an enemy object");
		}else{
			
			
			
		}
		
		
	}
	
	
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < thingsThatMakePanic.childCount; i++){
		
			distance = Vector2.Distance(makeVector3To2(thingsThatMakePanic.GetChild(i)),makeVector3To2(player));
			//Debug.Log("Distance of Index " + i + " " + distance);
			if(distance < triggerDistance){

			istNaheMonster = true;
				break;

				//Debug.Log(istNaheMonster);
				
			}else{
				istNaheMonster = false;
			}
			
		}

		Debug.Log (istNaheMonster);
	
		
		
	}
	
	Vector2 makeVector3To2(Transform t){
	
	
			return new Vector2(t.position.x,t.position.y);

				
		}
		
		
		
		void decreaseSanity (int height){
		bool maxCapReached = (panikLevel - height > 100);
		bool minCapReached = (panikLevel - height < 0);
		if (!(maxCapReached | minCapReached)) {
					
						panikLevel = panikLevel - height;
				} else if (maxCapReached) {
			panikLevel = 100;

				} else if (minCapReached) {
			panikLevel = 0;
				}
			if (panikLevel == 0) {
				Debug.Log ("PANIK!!!");
		} else if (panikLevel == 100) {
				
					Debug.Log ("Vollständige Geistige Gesundheit!");


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
	
	

