using UnityEngine;
using System.Collections;

public class WaveSystem : MonoBehaviour
{
    public EnemySpawner spawner;
    int wave = 1;

    void Start()
    {
        StartCoroutine(Loop());
    }

    IEnumerator Loop()
    {
        while (true)
        {
            spawner.Spawn(wave * 3);   
            wave++;
            yield return new WaitForSeconds(8f);
        }
    }
}
