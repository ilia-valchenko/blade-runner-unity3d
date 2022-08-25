using UnityEngine;

public class MoveRight : MonoBehaviour
{
    public float speed = 3;

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
