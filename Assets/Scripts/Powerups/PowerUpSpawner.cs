using UnityEngine;

// Spawner simple de power-ups en posiciones aleatorias dentro de un área.
public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] powerUpPrefabs;
    public float spawnInterval = 10f;
    public Vector2 areaSize = new Vector2(8f, 4f);

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private System.Collections.IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnPowerUp();
        }
    }

    private void SpawnPowerUp()
    {
        if (powerUpPrefabs.Length == 0) return;

        Vector2 randomPos = new Vector2(
            Random.Range(-areaSize.x, areaSize.x),
            Random.Range(-areaSize.y, areaSize.y)
        );

        GameObject prefab = powerUpPrefabs[Random.Range(0, powerUpPrefabs.Length)];
        Instantiate(prefab, randomPos, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(areaSize.x * 2f, areaSize.y * 2f, 0f));
    }
}
