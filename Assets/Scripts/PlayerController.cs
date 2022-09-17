using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const double LeftBorder = -0.6;
    private const double RightBorder = -7;
    private const float LevelRightBorder = (float)134;
    private const float JumpForceValue = (float)6;
    private const float GravityModifier = 1;
    private const float LeftRightModifier = (float)0.025;
    private const float InitialPlayerSpeed = (float)2.45;
    private const float SlowPlayerSpeed = (float)1.9;
    private const float FloorPositionY = (float)0.25;

    private Rigidbody playerRigidbody;
    private Animator playerAnimator;
    private bool isOnGround = true;
    private Vector3 playerStartPosition;
    private float speed;

    public bool wasCollisionResolved = true;

    // Start is called before the first frame update
    void Start()
    {
        this.playerRigidbody = GetComponent<Rigidbody>();
        this.playerAnimator = GetComponent<Animator>();
        this.playerRigidbody.freezeRotation = true;
        this.playerStartPosition = transform.position;
        this.speed = InitialPlayerSpeed;
        Physics.gravity *= GravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * this.speed);

        if (transform.position.x > LevelRightBorder)
        {
            transform.position = this.playerStartPosition;
        }

        if (Input.GetKeyDown(KeyCode.Space) && this.isOnGround)
        {
            this.speed = InitialPlayerSpeed;
            this.playerAnimator.Play("Running_Jump");
            this.playerRigidbody.AddForce(Vector3.up * JumpForceValue, ForceMode.Impulse);
            this.isOnGround = false;
        }

        if (Input.GetKey(KeyCode.W)) // Input.GetKeyDown(KeyCode.W)
        {
            this.speed = SlowPlayerSpeed;
            this.playerAnimator.Play("male_move_run_jogging_strafing_front_left");

            if (this.playerRigidbody.transform.position.z < LeftBorder)
            {
                this.playerRigidbody.transform.position = new Vector3(
                this.playerRigidbody.transform.position.x,
                this.playerRigidbody.transform.position.y,
                this.playerRigidbody.transform.position.z + LeftRightModifier);
            }
        }
        
        if (Input.GetKey(KeyCode.S)) // Input.GetKeyDown(KeyCode.S)
        {
            this.speed = SlowPlayerSpeed;
            this.playerAnimator.Play("male_move_run_jogging_strafing_front_right");

            if (this.playerRigidbody.transform.position.z > RightBorder)
            {
                this.playerRigidbody.transform.position = new Vector3(
                this.playerRigidbody.transform.position.x,
                this.playerRigidbody.transform.position.y,
                this.playerRigidbody.transform.position.z - LeftRightModifier);
            }
        }

        this.isOnGround = this.playerRigidbody.transform.position.y <= FloorPositionY;

        if (this.isOnGround && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.Space))
        {
            if (this.wasCollisionResolved)
            {
                this.speed = InitialPlayerSpeed;
                this.playerAnimator.Play("male_move_run_jogging_strafing_front");
            }
            else
            {
                this.speed = 0;
                this.playerAnimator.Play("BasicMotions@Idle01");
            }
        }
    }

    //void FixedUpdate()
    //{
    //    if (Input.GetKey(KeyCode.W)) // Input.GetKeyDown(KeyCode.W)
    //    {
    //        if (this.playerRigidbody.transform.position.z < LeftBorder)
    //        {
    //            this.playerRigidbody.transform.position = new Vector3(
    //            this.playerRigidbody.transform.position.x,
    //            this.playerRigidbody.transform.position.y,
    //            this.playerRigidbody.transform.position.z + this.leftRightModifier);
    //        }
    //    }
    //    else if (Input.GetKey(KeyCode.S)) // Input.GetKeyDown(KeyCode.S)
    //    {
    //        if (this.playerRigidbody.transform.position.z > RightBorder)
    //        {
    //            this.playerRigidbody.transform.position = new Vector3(
    //            this.playerRigidbody.transform.position.x,
    //            this.playerRigidbody.transform.position.y,
    //            this.playerRigidbody.transform.position.z - this.leftRightModifier);
    //        }
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.StartsWith("obstacle"))
        {
            this.speed = 0;
            this.wasCollisionResolved = false;
            this.playerAnimator.Play("BasicMotions@Idle01");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.StartsWith("obstacle"))
        {
            this.speed = InitialPlayerSpeed;
            this.wasCollisionResolved = true;
        }
    }
}
