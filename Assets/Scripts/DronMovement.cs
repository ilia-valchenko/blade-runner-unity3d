using UnityEngine;

public class DronMovement : MonoBehaviour
{
    public float speed = 2;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 20)
        {
            transform.Translate(Vector3.up * Time.deltaTime * this.speed);
        }
    }
}
