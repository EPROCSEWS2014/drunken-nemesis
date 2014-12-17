using UnityEngine;
using System.Collections;

public class HidingScript : MonoBehaviour 
{
	public string ObjectToHideString;
	static string ObjectToHideStringTemp;
	Transform player;
	Transform ObjectToHide;
	//int HiddenTrigger = 0;
	//public BoxCollider2D[] colliderTriggers;
	private Transform SpotLight;
	private float speedtemp;

	void Awake()
	{
		SpotLight = GameObject.Find("Spot light").transform;
	}

	void OnTriggerStay2D(Collider2D touchSensor) //Need to check, who is in front of 
	{ 
		if(touchSensor.tag=="Player") //If the "Player" is in front of..
		{ 
			ObjectToHideStringTemp = ObjectToHideString;
			Debug.Log(ObjectToHideStringTemp);
			player = GameObject.FindWithTag ("Player").transform;
			ObjectToHide = GameObject.Find(ObjectToHideStringTemp).transform;
			//colliderTriggers = ObjectToHide.GetComponentsInChildren<BoxCollider2D>();
			if (Input.GetKeyDown(KeyCode.Return))
			{
				switch (PlayerLogic.HiddenTrigger)
				{
				case false:
					PlayerLogic.HiddenTrigger=true;
					player.transform.position = ObjectToHide.transform.position;
					/*foreach(BoxCollider2D a in colliderTriggers)
					{
						a.collider2D.enabled=true;
					}*/
					ObjectToHide.gameObject.renderer.sortingLayerID=4;
					SpotLight.gameObject.SetActive(false);
					speedtemp=PlatformerCharacter2D.walkSpeed;
					PlatformerCharacter2D.walkSpeed = 0f;
					break;
				case true:
					PlayerLogic.HiddenTrigger=false;
					player.transform.position = ObjectToHide.transform.position;
					/*foreach(BoxCollider2D a in colliderTriggers)
					{
						a.collider2D.enabled=false;
					}*/
					ObjectToHide.gameObject.renderer.sortingLayerID=0;
					SpotLight.gameObject.SetActive(true);
					PlatformerCharacter2D.walkSpeed=speedtemp;
					break;
				}
			}
		}
	}
}
