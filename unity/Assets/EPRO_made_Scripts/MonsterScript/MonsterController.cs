using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public float speed = 10;
    public int detectionRange = 5;

    Vector2 playerPosition;
    float distance;
    double deltaTime = 0;

    bool grounded = false;
    bool facingRight = true;
    bool moving = false;
    Vector2 moveTo;
    bool lostPlayer = false;

    Animator anim;
    RestartScript restart;

    LayerMask whatIsGround;
    Transform groundCheck;
    float groundedRadius = .2f;
    Transform ceilingCheck;
    float ceilingRadius = .01f;

    void Awake()
    {
        groundCheck = transform.Find("GroundCheck");
        ceilingCheck = transform.Find("CeilingCheck");
        anim = GetComponent<Animator>();
        restart = GetComponent<RestartScript>();
    }
    
    void Update()
    {

    }
    
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
        anim.SetBool("Ground", grounded);
        anim.SetFloat("vSpeed", rigidbody2D.velocity.y);
        anim.SetFloat("Speed", speed);

        playerPosition = GameObject.Find("2DCharacter").transform.position;
        lostPlayer = false;
        if (System.Math.Abs(playerPosition.x - transform.position.x) > detectionRange)
        {
            lostPlayer = true;
        }

        if (moving)
        {
            distance = moveTo.x - transform.position.x;
            if (distance < speed)
                moving = false;
        } else if (lostPlayer)
        {
            System.Random rnd = new System.Random();
            if(deltaTime > 2)
            {
                distance = 1 + 2*rnd.Next(-1,1);
                deltaTime = 0;
            }
            deltaTime += Time.deltaTime;
        }else
        {
            distance = playerPosition.x - transform.position.x;
        }

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

    void MoveTo(Vector2 destination){
        moveTo = destination;
        moving = true;
    }
}
