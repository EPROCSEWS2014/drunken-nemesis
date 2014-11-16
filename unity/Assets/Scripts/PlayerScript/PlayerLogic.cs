using UnityEngine;
using System.Collections;

public class PlayerLogic : MonoBehaviour {

	public Transform[] testing;


	// Use this for initialization
	void Start () {
		int panikLevel = 100;
		int panikLevel_max = 100;
		boolean istNaheMonster;
	
	}
	
	// Update is called once per frame
	void Update () {


	
	}
    int doPanic (int height){
				if (istNaheMonster == true) {
						panikLevel = panikLevel - height;

				} else {
						if (panikLevel == panikLevel_max) {
								Debug.Log ("Vitality Full");
			            
						} else {
								panikLevel = panikLevel + height;
				     
				            
			            
						}
				}
		}
		switch (panikLevel){
			case 100 : //Keine Änderung

			case 50 : //Veränderte Sicht , Blur

			case 40 : //

			case 30 : //

			case 20 : //

			case 10 : //

			case 0 : //

		}


}
