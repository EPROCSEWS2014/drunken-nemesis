using UnityEngine;
using System.Collections;

public class HidingScript : MonoBehaviour 
{
	public string ObjectToHideString;
	static string ObjectToHideStringTemp;
	Transform player;
	Transform ObjectToHide;
	int HiddenTrigger = 0;
	public BoxCollider2D[] colliderTriggers;
	private Transform SpotLight;

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
			colliderTriggers = ObjectToHide.GetComponentsInChildren<BoxCollider2D>();
			if (Input.GetKeyDown(KeyCode.Return))
			{
				switch (HiddenTrigger)
				{
				case 0:
					HiddenTrigger=1;
					player.transform.position = ObjectToHide.transform.position;
					foreach(BoxCollider2D a in colliderTriggers)
					{
						a.collider2D.enabled=true;
					}
					ObjectToHide.gameObject.renderer.sortingLayerID=4;
					SpotLight.gameObject.SetActive(false);
					break;
				case 1:
					HiddenTrigger=0;
					player.transform.position = ObjectToHide.transform.position;
					foreach(BoxCollider2D a in colliderTriggers)
					{
						a.collider2D.enabled=false;
					}
					ObjectToHide.gameObject.renderer.sortingLayerID=0;
					SpotLight.gameObject.SetActive(true);
					break;
				}
			}
		}
	}
}
