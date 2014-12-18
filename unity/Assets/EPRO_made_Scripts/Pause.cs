using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	// Use this for initialization
    private bool isPause = false;
    private Rect butRect;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
            ToggleTime();
	}

    void ToggleTime()
    {
        if (!isPause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        isPause = !isPause;
    }
}
