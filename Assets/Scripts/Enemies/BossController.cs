using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BossController : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed = 2f;
    public float moveRangeX = 6f;   // cuánto se mueve a izquierda y derecha

    [Header("Daño por contacto")]
    public int contactDamage = 2;

    private Rigidbody2D rb;
    private Vector3 startPos;
    private float direction = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.freezeRotation = true;

        startPos = transform.position;
    }

    void FixedUpdate()
    {
        // movimiento horizontal de jefe clásico
        Vector2 pos = rb.position;
        pos.x += direction * moveSpeed * Time.fixedDeltaTime;

        // si llega muy lejos de la posición inicial, cambia de lado
        if (Mathf.Abs(pos.x - startPos.x) > moveRangeX)
        {
            direction *= -1f;
        }

        rb.MovePosition(pos);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth ph = collision.gameObject.GetComponent<PlayerHealth>();
            if (ph != null)
            {
                ph.TakeDamage(contactDamage);
            }
        }
    }
}
