using UnityEngine;

public class MonsterController : MonoBehaviour 
{
	public float speed = 10;

	private PlatformerCharacter2D monster;
	private Vector2 playerPosition;
	private float distance;
	
	Transform groundCheck;								
	float groundedRadius = .2f;							
	bool grounded = false;								
	Transform ceilingCheck;								
	float ceilingRadius = .01f;							
	Animator anim;	

	void Awake()
	{
		monster = GetComponent<PlatformerCharacter2D>();
		groundCheck = transform.Find("GroundCheck");
		ceilingCheck = transform.Find("CeilingCheck");
		anim = GetComponent<Animator>();
	}
	
	void Update ()
	{
		playerPosition = GameObject.Find("2D Character").transform.position;
		distance = playerPosition.x - transform.position.x;

		if (distance >= 0)
			rigidbody2D.velocity = new Vector2(speed, 0);
		else
			rigidbody2D.velocity = new Vector2(-speed, 0);

	}
	
	void FixedUpdate()
	{
		anim.SetBool("Ground", grounded);
		anim.SetFloat("vSpeed", rigidbody2D.velocity.y);

	}
}
