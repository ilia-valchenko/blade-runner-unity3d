using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const double LeftBorder = -0.6;
    private const double RightBorder = -7;
    private const float LevelRightBorder = (float)134;
    private const float JumpForceValue = 6;
    private const float GravityModifier = 1;
    private const float LeftRightModifier = (float)0.025;
    private const float InitialPlayerSpeed = (float)2.6;

    private Rigidbody playerRigidbody;
    private Animator playerAnimator;
    private bool isOnGround = true;
    private Vector3 playerStartPosition;
    private float speed;

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
            this.playerRigidbody.AddForce(Vector3.up * JumpForceValue, ForceMode.Impulse);
            this.isOnGround = false;
        }

        if (Input.GetKey(KeyCode.W)) // Input.GetKeyDown(KeyCode.W)
        {
            this.playerAnimator.Play("male_move_run_jogging_strafing_front_left");
            this.speed = InitialPlayerSpeed;

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
            this.playerAnimator.Play("male_move_run_jogging_strafing_front_right");
            this.speed = InitialPlayerSpeed;

            if (this.playerRigidbody.transform.position.z > RightBorder)
            {
                this.playerRigidbody.transform.position = new Vector3(
                this.playerRigidbody.transform.position.x,
                this.playerRigidbody.transform.position.y,
                this.playerRigidbody.transform.position.z - LeftRightModifier);
            }
        }
        
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.Space))
        {
            this.playerAnimator.Play("male_move_run_jogging_strafing_front");
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
        //if (collision.gameObject.CompareTag("sidewalk"))
        //{
        //    this.isOnGround = true;
        //}

        if (collision.gameObject.CompareTag("obstacle"))
        {
            //this.playerAnimator.enabled = false;
            this.playerAnimator.Play("BasicMotions@Idle01");
            this.speed = 0;
        }
        else {
            this.isOnGround = true;
        }
    }

    //private void OnCollisionExit(Collision collision)
    //{
        
    //}
}
