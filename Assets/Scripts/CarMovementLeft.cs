using UnityEngine;

public class CarMovementLeft : MonoBehaviour
{
    public float speed = 2;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * this.speed);
    }
}
