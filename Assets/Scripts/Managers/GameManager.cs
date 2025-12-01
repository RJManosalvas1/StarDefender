using StarDefender.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Puntaje / Enemigos")]
    public int score = 0;
    public int enemiesKilled = 0;
    public int killsToBoss = 15;

    [Header("Jefe")]
    public GameObject bossPrefab;
    public Transform bossSpawnPoint;
    private bool bossSpawned = false;

    // ---------- ESTO FALTABA ----------
    private bool isGameOver = false;
    // ---------------------------------

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // Inicializar UI
        if (UIManager.Instance != null)
        {
            UIManager.Instance.UpdateScore(score);
            UIManager.Instance.UpdateKills(enemiesKilled, killsToBoss);
        }
    }

    // ===== SCORE =====
    public void AddScore(int amount)
    {
        score += amount;

        if (UIManager.Instance != null)
        {
            UIManager.Instance.UpdateScore(score);
        }
    }

    public void OnEnemyKilled()
    {
        enemiesKilled++;

        if (UIManager.Instance != null)
            UIManager.Instance.UpdateKills(enemiesKilled, killsToBoss);

        if (!bossSpawned && enemiesKilled >= killsToBoss)
        {
            SpawnBoss();
        }
    }


    void SpawnBoss()
    {
        if (bossSpawned) return;

        if (bossPrefab == null || bossSpawnPoint == null)
        {
            Debug.LogWarning("GameManager: falta bossPrefab o bossSpawnPoint");
            return;
        }

        Instantiate(bossPrefab, bossSpawnPoint.position, Quaternion.identity);
        bossSpawned = true;
        Debug.Log("Boss spawneado");
    }


    // ===== GAME OVER =====
    public void GameOver()
    {
       if (isGameOver) return;

        isGameOver = true;
        Time.timeScale = 0f;

        if (UIManager.Instance != null)
        {
            UIManager.Instance.ShowGameOverPanel(true);
        }
    }


    public void Restart()
    {
        Time.timeScale = 1f;
        isGameOver = false;

        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.buildIndex);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
