using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 3;
    public int scoreValue = 10;   // 👈 esto arregla el error de scoreValue

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddScore(scoreValue);
            GameManager.Instance.OnEnemyKilled();
        }

        Destroy(gameObject);
    }
}
