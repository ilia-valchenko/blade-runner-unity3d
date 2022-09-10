using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const double LeftBorder = -0.6;
    private const double RightBorder = -7;
    private const float LevelRightBorder = (float)134;

    private Rigidbody playerRigidbody;
    private bool isOnGround = true;
    private Vector3 playerStartPosition;

    // TODO: Mark them as const.
    public float Speed = (float)2.6;
    public float JumpForceValue = 6;
    public float GravityModifier = 1;
    public float leftRightModifier = (float)0.025;

    // Start is called before the first frame update
    void Start()
    {
        this.playerRigidbody = GetComponent<Rigidbody>();
        this.playerRigidbody.freezeRotation = true;
        this.playerStartPosition = transform.position;
        Physics.gravity *= GravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * this.Speed);

        if (transform.position.x > LevelRightBorder)
        {
            transform.position = this.playerStartPosition;
        }

        if (Input.GetKeyDown(KeyCode.Space) && this.isOnGround)
        {
            this.playerRigidbody.AddForce(Vector3.up * JumpForceValue, ForceMode.Impulse);
            this.isOnGround = false;
        }

        if (Input.GetKey(KeyCode.W)) // Input.GetKeyDown(KeyCode.W)
        {
            if (this.playerRigidbody.transform.position.z < LeftBorder)
            {
                this.playerRigidbody.transform.position = new Vector3(
                this.playerRigidbody.transform.position.x,
                this.playerRigidbody.transform.position.y,
                this.playerRigidbody.transform.position.z + this.leftRightModifier);
            }
        }
        else if (Input.GetKey(KeyCode.S)) // Input.GetKeyDown(KeyCode.S)
        {
            if (this.playerRigidbody.transform.position.z > RightBorder)
            {
                this.playerRigidbody.transform.position = new Vector3(
                this.playerRigidbody.transform.position.x,
                this.playerRigidbody.transform.position.y,
                this.playerRigidbody.transform.position.z - this.leftRightModifier);
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
        this.isOnGround = true;
    }
}
