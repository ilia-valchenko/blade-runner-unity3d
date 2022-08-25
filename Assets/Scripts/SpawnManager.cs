using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private const float StartDelay = 2;
    private const float RepeatRate = 2;

    private Vector3 spawnPosition = new Vector3(25, 0, 0);

    public GameObject obstaclePrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", StartDelay, RepeatRate);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnObstacle()
    {
        // Creates a clone or copy of our obstacle prefab.
        Instantiate(this.obstaclePrefab, this.spawnPosition, this.obstaclePrefab.transform.rotation);
    }
}
