using UnityEngine;
using System.Collections;

public class RestartScript : MonoBehaviour {

	GameObject Monster;
	GameObject Player;
	void Start () {
	
	}

	public void Restart(){
		RestartMonster ();
		RestartPlayer();
	}

	public void RestartMonster(){
		Monster = GameObject.Find ("Monster");
		Monster.SetActive (false);
	}

	public void RestartPlayer(){
		Player = GameObject.Find ("2D Character");
		Player.transform.position = new Vector2 (0, 0);
	}
}
