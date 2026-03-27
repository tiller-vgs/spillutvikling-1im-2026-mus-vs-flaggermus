using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    
    public int enemiesPerWave = 10;// Number of enemies to spawn in each wave
    public float spawnSpacing = 1.5f;// Spacing between each enemy in the wave

  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnWave();
        }
    }
        

    void SpawnWave()
    {   
        for (int i = 0; i < enemiesPerWave; i++)
        {   // Calculate the spawn position for each enemy based on the index and spacing
            Vector3 spawnPosition = gameObject.transform.position + new Vector3(i * spawnSpacing, 0, 0);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
