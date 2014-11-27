using UnityEngine;


public class PlayerStamina : MonoBehaviour {
	
	//[SerializeField] KeyCode Running;
	
	private float normalSpeed;
	private float runningSpeed;
	private float speedUp = 1.5f;
	private int Stamina;
	private int maxStamina = 100;
	private int minStamina = 1;
	private float staminaDrain = 10;
	private float staminaRegenaration;
	private bool isCharacterRunning;
	
	//    public void runningStam () {
	//				isCharacterRunning = false;
	//				if (Input.GetKey ('V')) {
	//						isCharacterRunning = true;
	//						runningSpeed = normalSpeed * speedUp;
	//				}
	//				if (isCharacterRunning == true) {
	//						Stamina -= staminaDrain;
	//						if (Stamina -= staminaDrain < 1) {
	//								Stamina = minStamina;
	//						}
	//				} else {
	//						if (isCharacterRunning == false) {
	//								Stamina = staminaRegen ();
	//						}
	//				}
	//		}
	//	
	//	public int staminaRegen(){
	//	     staminaRegenaration = staminaDrain * Random.Range(0.3f,0.8f);
	//	     float new_Stamina = Stamina + staminaRegenaration;
	//	  if(new_Stamina > maxStamina){
	//	     new_Stamina = maxStamina;
	//	  }
	//	  return new_Stamina;
	//	}
	
	public int getExhaustion(){
		return (this.maxStamina - this.Stamina);
	}
	
	public int getStamina(){
		return this.Stamina;
	}
	
	public int getMaxStamina(){
		return this.maxStamina;
	}
}
