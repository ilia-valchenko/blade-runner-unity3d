using System;
using System.Linq;
using UnityEngine;

public class RobotAntagonistController : MonoBehaviour
{
    private const float JumpForceValue = (float)6;
    private const float GravityModifier = 1;
    private const float LevelRightBorder = (float)134;
    private const float InitialPlayerSpeed = (float)2.25;
    private const float FloorPositionY = (float)0.25;
    private const float JumpPreparationDistance = (float)2.028134;

    private Rigidbody robotAntagonistRigidbody;
    private Animator robotAntagonistAnimator;
    private bool isOnGround = true;
    private Vector3 playerStartPosition;
    private float speed;

    public bool wasCollisionResolved = true;

    // Start is called before the first frame update
    void Start()
    {
        this.robotAntagonistRigidbody = GetComponent<Rigidbody>();
        this.robotAntagonistAnimator = GetComponent<Animator>();
        this.robotAntagonistRigidbody.freezeRotation = true;
        this.playerStartPosition = transform.position;
        this.speed = InitialPlayerSpeed;
        Physics.gravity *= GravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * this.speed);

        // Teleports the robot antagonist to the start point if he reached the end of map.
        if (transform.position.x > LevelRightBorder)
        {
            transform.position = this.playerStartPosition;
        }

        var nearestObstacle = this.FindNearestObstacle();

        if (Math.Abs(this.robotAntagonistRigidbody.position.x - nearestObstacle.transform.position.x) <= JumpPreparationDistance)
        {
            this.robotAntagonistAnimator.Play("Running_Jump");
            this.robotAntagonistRigidbody.AddForce(Vector3.up * JumpForceValue, ForceMode.Impulse);
            this.isOnGround = false;
        }

        this.isOnGround = this.robotAntagonistRigidbody.transform.position.y <= FloorPositionY;

        if (this.isOnGround)
        {
            this.robotAntagonistAnimator.Play("male_move_run_jogging_strafing_front");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.StartsWith("obstacle"))
        {
            this.speed = 0;
            this.wasCollisionResolved = false;
            this.robotAntagonistAnimator.Play("BasicMotions@Idle01");
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

    private GameObject FindNearestObstacle()
    {
        var obstacles = GameObject.FindGameObjectsWithTag("obstacle");
        var frontObstacles = obstacles.Where(o => o.transform.position.x > this.robotAntagonistRigidbody.position.x);
        return obstacles.OrderBy(o => Math.Abs(o.transform.position.x - this.robotAntagonistRigidbody.position.x))
            .FirstOrDefault();
    }
}
