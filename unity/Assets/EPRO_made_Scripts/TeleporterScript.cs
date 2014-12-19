using UnityEngine;
using System.Collections;

public class TeleporterScript : MonoBehaviour {

	bool TimerStart = false;
	float Timer = 0f;
	void Awake()
	{
		guiTexture.pixelInset = new Rect (0f, 0f, Screen.width, Screen.height);
	}

	void OnTriggerStay2D(Collider2D touchSensor)
	{
		if (touchSensor.tag == "Player") 
		{			
			TimerStart=true;
		}
				
	}

	void Update()
	{
		if (TimerStart == true) 
		{
			guiTexture.enabled = true;
			guiTexture.color = Color.Lerp (guiTexture.color, Color.white, 0.01f);
			Timer += Time.deltaTime;
			//Time.timeScale=0;
			if (Timer >= 2f) 
			{
				//Time.timeScale=1;
				Application.LoadLevel ("EndGame");
			}
		} else {
			guiTexture.enabled = false;
		}
	}

	IEnumerator Waiting()
	{
		yield return new WaitForSeconds (5);
	}

}