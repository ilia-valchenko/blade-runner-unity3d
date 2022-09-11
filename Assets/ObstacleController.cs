using System;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private const float ObstacleFieldViewDistance = 15;

    private GameObject playerGameObject;

    // Start is called before the first frame update
    void Start()
    {
        this.playerGameObject = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        var diff = this.transform.position.x - this.playerGameObject.transform.position.x;

        if (Math.Abs(diff) > ObstacleFieldViewDistance)
        {
            Destroy(this.gameObject);
        }
    }
}
