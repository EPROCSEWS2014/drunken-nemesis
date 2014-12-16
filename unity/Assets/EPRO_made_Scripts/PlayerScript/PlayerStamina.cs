using UnityEngine;
using System.Collections;

public class PlayerStamina : MonoBehaviour {

	public float maxStamina = 100;
	private float Stamina;
	public float minStamina = 1;
	public float staminaDrain = 0.5f;
	private float staminaRegenaration;
	private bool isCharacterRunning;


	void Awake (){
		Stamina = maxStamina;
		}

	    public void runningStam () {
					isCharacterRunning = false;
					if (Input.GetKey(KeyCode.V)) {
							isCharacterRunning = true;
					}

					if (isCharacterRunning == true) {
							Stamina -= staminaDrain;

			                if ((Stamina -= staminaDrain) < 1) {
									Stamina = minStamina;
							}
					} else {
							if (isCharacterRunning == false) {
									Stamina = staminaRegen ();
							}
					}
			}
		
	public float staminaRegen(){
			staminaRegenaration = staminaDrain * 0.8f;
		     float new_Stamina = Stamina + staminaRegenaration;
		  if(new_Stamina > maxStamina){
		     new_Stamina = maxStamina;
		  }
    return new_Stamina;
	}
	
	public float getExhaustion(){
		return (this.maxStamina - this.Stamina);
	}
	
	public float getStamina(){
		return this.Stamina;
	}
	
	public float getMaxStamina(){
		return this.maxStamina;
	}
	void Update() {
				runningStam();
				//Debug.Log (Stamina);
		}


}
