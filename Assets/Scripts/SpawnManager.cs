using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private const float StartDelay = 1;
    private const float RepeatRate = 5;

    private Vector3 spawnPositionOffset = new Vector3(10, 0, (float)-1.000019);
    private PlayerController playerController;

    //public List<GameObject> obstacles;
    public GameObject[] obstacles;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", StartDelay, RepeatRate);
        this.playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnObstacle()
    {
        if (!this.playerController.wasCollisionResolved)
        {
            return;
        }

        var spawnPosition = new Vector3(
            this.player.transform.position.x + spawnPositionOffset.x,
            spawnPositionOffset.y,
            spawnPositionOffset.z);

        // Creates a clone or copy of our obstacle prefab.
        var randomObstacle = GetRandomObstacle();
        Instantiate(randomObstacle, spawnPosition, randomObstacle.transform.rotation);
    }

    private GameObject GetRandomObstacle()
    {
        var random = new System.Random();
        var randomIndex = random.Next(0, this.obstacles.Length);
        return this.obstacles[randomIndex];
    }
}
