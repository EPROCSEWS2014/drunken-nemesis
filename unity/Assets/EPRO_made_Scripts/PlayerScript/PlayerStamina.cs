using UnityEngine;
using System.Collections;

public class PlayerStamina : MonoBehaviour {

    // Running : UnityEngine.KeyCode

	public float normalSpeed;
	public float runningSpeed;
	public float speedUp = 1.5f;
	public int Stamina;
	public int maxStamina = 100;
	public int minStamina = 1;
	public float staminaDrain = 10;
	public float staminaRegenaration;
	public bool isCharacterRunning;

	// public static void runningStam () {
	// normalSpeed = getWalkSpeed();
	// isCharacterRunning = false;
	// if(Input.GetKey(Running){
	//    isCharacterRunning = true;
	//    runningSpeed = normalSpeed * speedUp;
	//}
	// if(isCharacterRunning == true){
	//    Stamina -= staminaDrain;
	//    if(Stamina -= staminaDrain < 1){
	//       Stamina = minStamina;
	//    }
	// } else {
	// if(isCharacterRunning == false){
	//    Stamina = staminaRegen();
	//}
	//}
	//
	//public static int staminaRegen(){
	//     staminaRegenaration = staminaDrain * Math.Random(0.3f, 0.8f);
	//     float new_Stamina = Stamina + staminaRegenaration;
	//  if(new_Stamina > maxStamina){
	//     new_Stamina = maxStamina;
	//  }
	//  return new_Stamina;
	//}

	public int getStamina(){
				return Stamina;
		}

	public int getMaxStamina(){
				return maxStamina;
		}
}
