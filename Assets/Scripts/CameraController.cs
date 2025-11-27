using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Player player;


    void Start()
    {
        player = FindFirstObjectByType<Player>();
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }
}
