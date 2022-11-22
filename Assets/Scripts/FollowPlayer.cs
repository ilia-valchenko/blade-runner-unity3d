using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, (float)2.6, (float)-10);

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void LateUpdate()
    {
        //transform.position = this.player.transform.position + this.offset;
        transform.position = new Vector3(this.player.transform.position.x, offset.y, offset.z);
    }
}
