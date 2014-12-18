using UnityEngine;
using System.Collections;

public class CameraL : MonoBehaviour 
{
	public Transform Player;

	public Vector2
				Margin,
				Smoothing;

	public static BoxCollider2D Bounds;


	private Vector3
	_min,
	_max;

	public bool IsFollowing { get; set; }

	void Awake()
	{
		DontDestroyOnLoad (this);
		//DontDestroyOnLoad (this.thingsThatMakePanic);
	}

	public void Start()
	{
		Bounds = GameObject.Find (LevelChangeTemp.NextCameraLimitsTemp).GetComponent<BoxCollider2D>();
		_min = Bounds.bounds.min;
		_max = Bounds.bounds.max;
	}
	public void Update()
	{
		var x = transform.position.x;
		var y = transform.position.y;

		if (IsFollowing)
		{
			if (Mathf.Abs (x - Player.position.x) > Margin.x)
				x = Mathf.Lerp (x, Player.position.x, Smoothing.x * Time.deltaTime);

			if (Mathf.Abs(y - Player.position.y) > Margin.y)
				y = Mathf.Lerp (y, Player.position.x, Smoothing.x * Time.deltaTime);
		}

		var cameraHalfWidth = camera.orthographicSize * ((float)Screen.width / Screen.height);

		x = Mathf.Clamp (x, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);
		y = Mathf.Clamp (y, _min.y + camera.orthographicSize, _max.y - camera.orthographicSize);

		transform.position = new Vector3 (x, y, transform.position.z);
	}
}
