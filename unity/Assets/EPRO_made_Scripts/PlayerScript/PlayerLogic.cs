﻿using UnityEngine;



public class PlayerLogic : MonoBehaviour {

	private Transform player; // The player object 


	//Everything relating to the panicMethods

		private float 	sanityLevel;  // The sanity level
		public  	int 	maximumSanity = 1000;	
		public  	int 	minimumSanity = 0;
		public 	float 	sanityDrain = 100;
		private	float 	sanityRegen;
		public	int 	divisor = 10;
		private	bool 	isNearToMonster;
		private float 	exhaustion;
		

		//For the switch-case statement which triggers at specific panic levels
			
		private  int secondWorst;
		private  int thirdWorst;
		private  int forthWorst;
		private  int fithWorst;




			
		//Attributes only concerning the EnemyFinding Algorithm
			private	Transform 	thingsThatMakePanic; 	 	// A tranform Father, which contains all the monsters
			public 	int 		triggerDistance = 5;		// The Distance where the Algorithm searches for Enemies
			private float 		distance;					// The calculated distance to the monster

		//End Algorithm

	//End panicMethods



	// Use this for initialization
	void Start () {
			secondWorst = maximumSanity/5;
			thirdWorst = secondWorst *2;
			forthWorst = secondWorst *3;
			fithWorst = secondWorst * 4;
		this.sanityLevel = maximumSanity; 
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

		if (minCapReached) {
			this.sanityLevel = minimumSanity;}
		else{

			this.sanityLevel -= height;

		}




			if (sanityLevel == minimumSanity) {
				Debug.Log ("PANIK!!!");
		} else if (sanityLevel == maximumSanity) {
				
					Debug.Log ("Vollständige Geistige Gesundheit!");


				}

			
			
			
//			switch (Mathf.RoundToInt(sanityLevel)) {
//			case maximumSanity: //Veränderte Sicht , Blur
//				break;
//			case fithWorst: //Einschränkungen in der Bewegung
//				break;
//			case forthWorst: //Schwere Atmung, Geräusche
//				break;
//			case thirdWorst: //Halluzinationen , Scheinmonster
//				break;
//			case secondWorst: //Verfolgungswahn, Kontrollverlust
//				break;
//			case minimumSanity: //Absolute Panik
//				break;
//			}
		}
		
		
		
		public void regainSanity (float height){
		bool maxCapReached = ((sanityLevel + (height)) > maximumSanity);
		if(maxCapReached){

			this.sanityLevel = this.maximumSanity;

		}else{
			this.decreaseSanity(-(height));

		}
		}

	public float getPanicLevel(){

		return this.sanityLevel;
	}
	public void setPanicLevel(float newPanicLevel){

		this.sanityLevel = newPanicLevel;


	}
		
	}
	
	

