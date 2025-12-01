using UnityEngine;
using TMPro;

// Namespace para evitar choques con otros UIManager
namespace StarDefender.UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;

        [Header("Textos")]
        public TextMeshProUGUI killsText;    // "Enemigos: X / 15"
        public TextMeshProUGUI scoreText;    // "Puntos: X"
        public TextMeshProUGUI healthText;   // "Vida: current/max"
        public TextMeshProUGUI shieldText;   // "Escudo: ..."

        [Header("Paneles")]
        public GameObject gameOverPanel;     // Panel de Game Over (opcional)

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            if (gameOverPanel != null)
                gameOverPanel.SetActive(false);
        }

        public void UpdateKills(int current, int target)
        {
            if (killsText != null)
                killsText.text = $"Enemigos: {current} / {target}";
        }

        public void UpdateScore(int score)
        {
            if (scoreText != null)
                scoreText.text = $"Puntos: {score}";
        }

        public void UpdatePlayerHealth(int current, int max)
        {
            if (healthText != null)
                healthText.text = $"Vida: {current}/{max}";
        }

        public void UpdateShield(bool active)
        {
            if (shieldText != null)
                shieldText.text = active ? "Escudo: ACTIVO" : "Escudo: ---";
        }

        public void ShowGameOverPanel(bool show)
        {
            if (gameOverPanel != null)
                gameOverPanel.SetActive(show);
        }
    }
}
