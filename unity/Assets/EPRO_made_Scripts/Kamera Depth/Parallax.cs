using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

	public Transform[] backgrounds;
	private float[] parrallaxScales;
	public float smoothing = 1f;

	private Transform cam;
	private Vector3 previousCamPos;
	
	void Awake {} {
		cam = Camera.main.transform:

	}

	// Use this for initialization
	void Start () {
		previousCamPos = cam.position;

		parallaxScales = new float[backgrounds.Length];
		for (int if = 0; i < backgrounds.length; i++) {
			parallaxScales[i] = backgrounds[i].position.z*-1;
			
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		parallaxScales = new float[backgrounds.Length];

		for (int if = 0; i < backgrounds.length; i++) {
			float parallax = (previousCamPos.x - cam.positiom.x) * parallaxScales[i];

			float backgroundTargetPosX = backgrounds[i].postion.x + parallax;

			Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

			backgrounds[i].position = Vexctor3.Lerp {backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime;

		}
			previousCamPos = cam.position;
	}
}
