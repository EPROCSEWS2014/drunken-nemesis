using UnityEngine;
using System.Collections;

public class SightScript : MonoBehaviour {
	private float duration = 3.0F;

    public int sanity;

	public float decreaseSpeed;
	public float increaseSpeed;
    private float sightFunction;
	private bool decrease = true;
	

	void Update() {
        sightFunction = sanity * 1.75f + 1;
        SightLevel();
	}

    void SightLevel() {
        if (light.intensity > sightFunction && decrease)
        {
            light.intensity -= decreaseSpeed;
        }
        else
        {
            decrease = false;
        }

        if (light.intensity <= 1 && sightFunction == 1)
        {
            pulsate();
        }


        if (light.intensity < sightFunction && !decrease)
        {
            light.intensity += increaseSpeed;
        }
        else
        {
            decrease = true;
        }
    }

	void pulsate() {
		float phi = Time.time / duration * 2 * Mathf.PI;
		float amplitude = Mathf.Cos(phi) * 0.3F + 0.6F;
		light.intensity = amplitude;
	}
}
