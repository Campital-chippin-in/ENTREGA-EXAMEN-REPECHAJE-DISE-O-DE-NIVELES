using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject[] groundPrefabs;  // Prefabs, incluyendo el Torso en el índice 10
    public float spawnInterval = 2f;
    public float spawnXPosition = 10f;
    public float spawnYPosition = -2.5f;
    private float timer = 0f;

    public int spawnCount = 0;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnGround();
            timer = 0f;
        }
    }

    void SpawnGround()
    {
        if (spawnCount < 10)
        {
            int index = Random.Range(0, 10);  // Seleccionar aleatoriamente entre los primeros 10 prefabs
            GameObject groundPrefab = groundPrefabs[index];
            Instantiate(groundPrefab, new Vector3(spawnXPosition, spawnYPosition, 0), Quaternion.identity);
            spawnCount++;
        }
        else if (spawnCount == 10)
        {
            GameObject torsoPrefab = groundPrefabs[10];  // El prefab del Torso está en el índice 10
            Instantiate(torsoPrefab, new Vector3(spawnXPosition, 1, 0), Quaternion.identity); // Y = 1
            spawnCount++;
            CancelInvoke("SpawnGround");  // Detener la generación de prefabs
        }
    }
}
