using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const double LeftBorder = -0.5;
    private const double RightBorder = -7;

    private Rigidbody playerRigidbody;
    private bool isOnGround = true;

    public float JumpForceValue = 6;
    public float GravityModifier = 0;
    public float leftRightModifier = 1;

    // Start is called before the first frame update
    void Start()
    {
        this.playerRigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= GravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
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

        //if (Input.GetKey(KeyCode.D))
        //{
        //    this.playerRigidbody.transform.rotation = new Quaternion(0, 90, 0);
        //}
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
