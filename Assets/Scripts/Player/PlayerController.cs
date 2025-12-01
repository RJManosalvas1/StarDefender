using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Velocidades")]
    public float forwardSpeed = 4f;      // Avance automático hacia arriba (+Y)
    public float horizontalSpeed = 6f;   // Movimiento izquierda/derecha

    [Header("Límites en X (mundo)")]
    public float minX = -8f;
    public float maxX = 8f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;               // Muy importante en 2D
        rb.freezeRotation = true;           // Para que no gire por colisiones
    }

    private void FixedUpdate()
    {
        // 1) Solo leemos eje horizontal
        float h = Input.GetAxisRaw("Horizontal");   // A/D o flechas

        // 2) Calculamos nueva posición
        Vector2 pos = rb.position;

        // Movimiento horizontal controlado por el jugador
        pos.x += h * horizontalSpeed * Time.fixedDeltaTime;

        // Avance automático hacia adelante (eje Y)
        pos.y += forwardSpeed * Time.fixedDeltaTime;

        // 3) Limitar X para que no se salga de la pantalla
        pos.x = Mathf.Clamp(pos.x, minX, maxX);

        // 4) Aplicar movimiento
        rb.MovePosition(pos);
    }
}
