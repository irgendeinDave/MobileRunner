using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    private GameObject player;
    private float height;
    private float depth;
    [SerializeField] float offset = 0;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        height = transform.position.y;
        depth = transform.position.z;
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + offset, height, depth);
    }
}
