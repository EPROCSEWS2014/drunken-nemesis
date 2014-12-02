using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public float speed = 10;
    Vector2 playerPosition;
    float distance;
    LayerMask whatIsGround;
    Transform groundCheck;
    float groundedRadius = .2f;
    bool grounded = false;
    bool facingRight = true;
    Transform ceilingCheck;
    float ceilingRadius = .01f;
    Animator anim;
    RestartScript restart;

    void Awake()
    {
        groundCheck = transform.Find("GroundCheck");
        ceilingCheck = transform.Find("CeilingCheck");
        anim = GetComponent<Animator>();
        restart = GetComponent<RestartScript>();
    }
    
    void Update()
    {
        playerPosition = GameObject.Find("2D Character").transform.position;
        distance = playerPosition.x - transform.position.x;
        if (distance > 0)
        {
            rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
            if (!facingRight)
                Flip();
        } else
        {
            rigidbody2D.velocity = new Vector2(-speed, rigidbody2D.velocity.y);
            if (facingRight)
                Flip();
        }
        anim.SetFloat("Speed", speed);

    }
    
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
        anim.SetBool("Ground", grounded);
        anim.SetFloat("vSpeed", rigidbody2D.velocity.y);
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Spawn(Vector2 Position)
    {
        gameObject.SetActive(true);
        transform.position = Position;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "2D Character")
        {
            restart.Restart();
        }
    }
}
