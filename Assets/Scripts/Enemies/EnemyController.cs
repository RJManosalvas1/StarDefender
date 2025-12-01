using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 1f;
    Transform player;

    void Start() => player = GameObject.FindGameObjectWithTag("Player")?.transform;

    void Update()
    {
        if (!player) return;
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}