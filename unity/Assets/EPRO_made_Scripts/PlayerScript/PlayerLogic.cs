using UnityEngine;
using System.Collections;


public class PlayerLogic : MonoBehaviour {

	private Transform player; // The player object 


	//Everything relating to the panicMethods

		private float 	sanityLevel;  // The sanity level
		public 	int 	maximumSanity = 1000;	
		public 	int 	minimumSanity = 0;
		public 	float 	sanityDrain = 100;
		private	float 	sanityRegen;
		public	int 	divisor = 10;
		private	bool 	isNearToMonster;
			
		//Attributes only concerning the EnemyFinding Algorithm
			private	Transform 	thingsThatMakePanic; 	 	// A tranform Father, which contains all the monsters
			public 	int 		triggerDistance = 5;		// The Distance where the Algorithm searches for Enemies
			private float 		distance;					// The calculated distance to the monster

		//End Algorithm

	//End panicMethods



	// Use this for initialization
	void Start () {
		this.sanityLevel = this.maximumSanity; 
		this.sanityRegen = (sanityDrain/divisor); // Calculates the Regeneration of the Sanity
		this.player = this.transform; // Returns the Player Transform
		this.thingsThatMakePanic = GameObject.FindWithTag("EnemyC").transform;


		if(player == null) {
				Debug.LogError("Please assign a player object");
				
		}			else if(thingsThatMakePanic.GetChild(0) == null){
						Debug.LogError("Please assign at least an enemy object");
							}

		
	}
	
	
	
	// Update is called once per frame
	void Update () {

		detectionAlgorithm();
		
		
		
	}

	private void detectionAlgorithm(){

		
		for(int i = 0; i < this.thingsThatMakePanic.childCount; i++){
			
			this.distance = Vector2.Distance(makeVector3To2(thingsThatMakePanic.GetChild(i)),makeVector3To2(player));
			
			if(distance < triggerDistance){
				
				this.isNearToMonster = true;
				break;
				
				
			}else{
				this.isNearToMonster = false;
			}
			
		}
		
		if(isNearToMonster){
			this.decreaseSanity(sanityDrain);
		}else{
			
			this.regainSanity(sanityRegen);
		}

	}

	/**
	Transforms a Vector3 into a Vector2
	 */
	public Vector2 makeVector3To2(Transform t){
	
	
			return new Vector2(t.position.x,t.position.y);

				
		}
		
		
		
		public void decreaseSanity (float height){
		bool minCapReached = ((sanityLevel - height) < minimumSanity);
		Debug.Log(sanityLevel);
		if (minCapReached) {
			this.sanityLevel = minimumSanity;}
		else{

			this.sanityLevel -= height;

		}

	//	Debug.Log(panicLevel);


			if (sanityLevel == minimumSanity) {
				Debug.Log ("PANIK!!!");
		} else if (sanityLevel == maximumSanity) {
				
					Debug.Log ("Vollständige Geistige Gesundheit!");


				}

			
			
			
			switch (Mathf.RoundToInt(sanityLevel)) {
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
		
		
		
		public void regainSanity (float height){
		bool maxCapReached = ((sanityLevel + height) > maximumSanity);
		if(maxCapReached){

			this.sanityLevel = this.maximumSanity;

		}else{
			this.decreaseSanity(-height);

		}
		}

	public float getPanicLevel(){

		return this.sanityLevel;
	}
	public void setPanicLevel(float newPanicLevel){

		this.sanityLevel = newPanicLevel;


	}
		
	}
	
	

