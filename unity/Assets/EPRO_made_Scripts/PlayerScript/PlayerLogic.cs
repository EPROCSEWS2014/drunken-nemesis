using UnityEngine;
using System.Collections;


public class PlayerLogic : MonoBehaviour
{
	//Hidden Trigger Variable
	public static bool HiddenTrigger=false;


    Transform player; // The player object 
    PlayerStamina ps;

    //Everything relating to the panicMethods

    public float sanityLevel;  // The sanity level
    public int maximumSanity = 1000;
    public int minimumSanity = 0;
    public float sanityDrain = 100;
    float sanityRegen;
    public int divisor = 10;
    bool isNearToMonster;
    float exhaustion;

    public AudioClip[] audioClip;       
    private AudioSource[] audioSource;  


    //For the switch-case statement which triggers at specific panic levels

    int secondWorst;
    int thirdWorst;
    int forthWorst;
    int fithWorst;

    public float staminaVol1 = 1.0f;
    public float staminaVol2 = 1.0f;
    public float staminaVol3 = 1.0f;
    public float staminaVol4 = 1.0f;


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
        getSounds();
    }



    // Update is called once per frame
    void Update()
    {

        detectionAlgorithm();

		//Debug.Log(this.sanityLevel);
		//Debug.Log(ps.getExhaustion());

        audioSource[0].volume = staminaVol1;
        audioSource[1].volume = staminaVol2;
        audioSource[2].volume = staminaVol3;
        audioSource[3].volume = staminaVol4;

    }

    private void getSounds()
    {
       
        audioSource = new AudioSource[audioClip.Length];
        for (int i = 0; i < audioSource.Length; i++)
        {
            audioSource[i] = gameObject.AddComponent<AudioSource>();
            audioSource[i].clip = audioClip[i];
            audioSource[i].loop = true;
            audioSource[i].volume = 0.0f;
        }
    }



    void detectionAlgorithm()
    {
        if (GameObject.Find("EnemyContainer"))
        {
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
            if (isNearToMonster)
            {
                this.decreaseSanity(sanityDrain);
            }
            else
            {
                this.regainSanity(sanityRegen);
            }
        }

        if (sanityLevel < 250)
        {
            if (!audioSource[3].isPlaying)
                audioSource[3].Play();
            audioSource[2].Stop();
            audioSource[1].Stop();
            audioSource[0].Stop();
        }
        else if (sanityLevel < 500)
        {
            audioSource[3].Stop();
            if (!audioSource[2].isPlaying)
                audioSource[2].Play();
            audioSource[1].Stop();
            audioSource[0].Stop();
        }
        else if (sanityLevel < 750)
        {  
            audioSource[3].Stop();
            audioSource[2].Stop();
            if (!audioSource[1].isPlaying)
                audioSource[1].Play();
            audioSource[0].Stop();
        }
        else if (sanityLevel <= 1000)
        {
            audioSource[3].Stop();
            audioSource[2].Stop();
            audioSource[1].Stop();
            if (!audioSource[0].isPlaying)
                audioSource[0].Play();
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



