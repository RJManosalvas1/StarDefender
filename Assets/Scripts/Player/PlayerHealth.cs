using UnityEngine;
using StarDefender.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Vida")]
    public int maxHealth = 5;
    private int currentHealth;

    [Header("Escudo")]
    public bool hasShield = false;

    private void Start()
    {
        currentHealth = maxHealth;

        if (UIManager.Instance != null)
        {
            UIManager.Instance.UpdatePlayerHealth(currentHealth, maxHealth);
            UIManager.Instance.UpdateShield(hasShield);
        }
    }

    public void TakeDamage(int amount)
    {
        // Si tiene escudo activo, por ahora no recibe daño
        if (hasShield)
            return;

        currentHealth -= amount;
        if (currentHealth < 0)
            currentHealth = 0;

        if (UIManager.Instance != null)
            UIManager.Instance.UpdatePlayerHealth(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void SetShield(bool active)
    {
        hasShield = active;

        if (UIManager.Instance != null)
            UIManager.Instance.UpdateShield(hasShield);
    }

    private void Die()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.GameOver();

        // Puedes destruir la nave si quieres:
        // Destroy(gameObject);
    }
}
