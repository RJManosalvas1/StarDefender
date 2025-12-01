using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Referencias")]
    public Transform player;          
    public GameObject enemyPrefab;    

    [Header("Área de aparición")]
    public float distanceAhead = 15f; 
    public float minX = -8f;          
    public float maxX = 8f;          

    public void Spawn(int amount)
    {
        if (player == null || enemyPrefab == null)
        {
            Debug.LogWarning("EnemySpawner: falta asignar player o enemyPrefab");
            return;
        }

        for (int i = 0; i < amount; i++)
        {
            float x = Random.Range(minX, maxX);
            float y = player.position.y + distanceAhead;  

            Vector3 spawnPos = new Vector3(x, y, 0f);
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }
}
