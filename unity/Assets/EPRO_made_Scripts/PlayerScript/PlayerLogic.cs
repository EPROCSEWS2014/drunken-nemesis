using UnityEngine;
using System.Collections;


public class PlayerLogic : MonoBehaviour
{
	//Hidden Trigger Variable
	public static bool HiddenTrigger=false;


    Transform player; // The player object 
    PlayerStamina ps;

    //Everything relating to the panicMethods

    float sanityLevel;  // The sanity level
    public int maximumSanity = 1000;
    public int minimumSanity = 0;
    public float sanityDrain = 100;
    float sanityRegen;
    public int divisor = 10;
    bool isNearToMonster;
    float exhaustion;



    //For the switch-case statement which triggers at specific panic levels

    int secondWorst;
    int thirdWorst;
    int forthWorst;
    int fithWorst;




    //Attributes only concerning the EnemyFinding Algorithm
    Transform thingsThatMakePanic; 	 	// A tranform Father, which contains all the monsters
    public int triggerDistance = 5;		// The Distance where the Algorithm searches for Enemies
    float distance;					// The calculated distance to the monster

    //End Algorithm

    //End panicMethods

	void Awake()
	{
		DontDestroyOnLoad (this);
		DontDestroyOnLoad (GameObject.Find ("EnemyContainer"));
		/*if (GameObject.Find ("EnemyContainer")==null) {
			Destroy (GameObject.Find ("EnemyContainer"));
				}*/
	}

    // Use this for initialization
    void Start()
    {
        ps = GetComponent<PlayerStamina>();
        secondWorst = maximumSanity / 5;
        thirdWorst = secondWorst * 2;
        forthWorst = secondWorst * 3;
        fithWorst = secondWorst * 4;
        this.sanityLevel = maximumSanity;
       // Debug.Log(this.sanityLevel);
        this.sanityRegen = (sanityDrain / divisor); // Calculates the Regeneration of the Sanity
        this.player = this.transform; // Returns the Player Transform
		if (GameObject.Find ("EnemyContainer")) {
						this.thingsThatMakePanic = GameObject.FindWithTag ("EnemyC").transform;
				

		
						if (player == null) {
								Debug.LogError ("Please assign a player object");

						} else if (thingsThatMakePanic.GetChild (0) == null) {
								Debug.LogError ("Please assign at least an enemy object");
						}
				
				}
    }



    // Update is called once per frame
    void Update()
    {

        detectionAlgorithm();

	


		//Debug.Log(this.sanityLevel);
		//Debug.Log(ps.getExhaustion());


    }

void detectionAlgorithm()
{
if (GameObject.Find ("EnemyContainer")) {
for (int i = 0; i < this.thingsThatMakePanic.childCount; i++)
{
this.distance = Vector2.Distance(makeVector3To2(thingsThatMakePanic.GetChild(i)), makeVector3To2(player));
if (distance < triggerDistance)
{
this.isNearToMonster = true;
break;
}
else
{
this.isNearToMonster = false;
}
}
if (isNearToMonster) {
this.decreaseSanity (sanityDrain);
} else {
this.regainSanity (sanityRegen);
}
}
}

    /**
    Transforms a Vector3 into a Vector2
     */
    public Vector2 makeVector3To2(Transform t)
    {


        return new Vector2(t.position.x, t.position.y);


    }



    public void decreaseSanity(float height)
    {
        bool minCapReached = ((sanityLevel - height) < minimumSanity);

        if (minCapReached)
        {
            this.sanityLevel = minimumSanity;
        }
        else
        {

            this.sanityLevel -= height;

        }




        if (sanityLevel == minimumSanity)
        {
           // Debug.Log("PANIK!!!");
        }
        else if (sanityLevel == maximumSanity)
        {

         //   Debug.Log("Vollständige Geistige Gesundheit!");


        }

        int round = Mathf.RoundToInt(sanityLevel);

        //Do something fancy at given sanity level

        if (round == minimumSanity)
        {

        }
        else if (round <= secondWorst)
        {


        }
        else if (round <= thirdWorst)
        {


        }
        else if (round <= fithWorst)
        {


        }
        else if (round <= maximumSanity)
        {


        }



    }



    public void regainSanity(float height)
    {
        bool maxCapReached = ((sanityLevel + (height) /*- ps.getExhaustion()*/) > maximumSanity);
        if (maxCapReached)
        {

            this.sanityLevel = this.maximumSanity;

        }
        else
        {
            this.decreaseSanity(-((height) /*- ps.getExhaustion()*/));

        }
    }

    public float getPanicLevel()
    {

        return this.sanityLevel;
    }
    public void setPanicLevel(float newPanicLevel)
    {

        this.sanityLevel = newPanicLevel;


    }



}



