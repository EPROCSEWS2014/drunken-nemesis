using UnityEngine;
using System.Collections;

public class HidingScript : MonoBehaviour 
{
	public string ObjectToHideString;
	static string ObjectToHideStringTemp;
	Transform player;
	Transform ObjectToHide;
	Transform Monster;
	BoxCollider2D colliderTriggerBox;
	BoxCollider2D EnemyBoxC;
	CircleCollider2D colliderTriggerCircle;
	CircleCollider2D EnemyCircleC;
	private Transform SpotLight;
	private float speedtemp;
	bool kleber=false;


	void Awake()
	{
		SpotLight = GameObject.Find("Spot light").transform;
	}

	void Update()
	{
		if (kleber) 
		{
			player.transform.position = ObjectToHide.transform.position;
		}
		if(GameObject.FindWithTag("Enemy"))
		{
			Monster = GameObject.FindWithTag ("Enemy").transform;
			EnemyBoxC = Monster.GetComponent<BoxCollider2D>();
			EnemyCircleC = Monster.GetComponent<CircleCollider2D>();
		}
	}

	void OnTriggerStay2D(Collider2D touchSensor) //Need to check, who is in front of 
	{ 
		if(touchSensor.tag=="Player") //If the "Player" is in front of..
		{ 
			ObjectToHideStringTemp = ObjectToHideString;
			Debug.Log(ObjectToHideStringTemp);
			player = GameObject.FindWithTag ("Player").transform;

			ObjectToHide = GameObject.Find(ObjectToHideStringTemp).transform;
			colliderTriggerBox = player.GetComponent<BoxCollider2D>();
			colliderTriggerCircle = player.GetComponent<CircleCollider2D>();
			if (Input.GetKeyDown(KeyCode.Return))
			{
				switch (PlayerLogic.HiddenTrigger)
				{
				case false:
					PlayerLogic.HiddenTrigger=true;
					ObjectToHide.gameObject.renderer.sortingLayerID=4;
					SpotLight.gameObject.SetActive(false);
					speedtemp=PlatformerCharacter2D.walkSpeed;
					PlatformerCharacter2D.walkSpeed = 0f;
					EnemyBoxC.enabled=false;
					colliderTriggerCircle.enabled=false;
					kleber=true;
					break;
				case true:
					PlayerLogic.HiddenTrigger=false;
					player.transform.position = ObjectToHide.transform.position;
					ObjectToHide.gameObject.renderer.sortingLayerID=0;
					SpotLight.gameObject.SetActive(true);
					PlatformerCharacter2D.walkSpeed=speedtemp;
					EnemyBoxC.enabled=true;
					colliderTriggerCircle.enabled=true;
					kleber=false;
					break;
				}
			}
		}
	}
}
