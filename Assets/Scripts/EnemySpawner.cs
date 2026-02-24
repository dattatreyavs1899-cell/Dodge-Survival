using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject enemyPrefab;
    public int maxEnemies = 10;
    public float spawnInterval = 7f;

    [Header("Player Settings")]
    public Transform player;
    public float minDistanceFromPlayer = 15f;

    [Header("Organization")]
    public Transform enemyParent;

    private NavMeshTriangulation navMeshData;

    void Start()
    {
        if (enemyParent == null)
        {
            enemyParent = new GameObject("--- ENEMIES ---").transform;
        }

        navMeshData = NavMesh.CalculateTriangulation();

        InvokeRepeating(nameof(Spawn), 0f, spawnInterval);
    }

    void Spawn()
    {
        if (enemyParent.childCount >= maxEnemies || player == null) return;

        Vector3 spawnPoint = Vector3.zero;
        bool foundValidSpot = false;

        for (int i = 0; i < 30; i++)
        {
            int randomIndex = Random.Range(0, navMeshData.vertices.Length);
            Vector3 randomPoint = navMeshData.vertices[randomIndex];

            if (Vector3.Distance(randomPoint, player.position) >= minDistanceFromPlayer)
            {
                spawnPoint = randomPoint;
                foundValidSpot = true;
                break;
            }
        }

        if (foundValidSpot)
        {
            Instantiate(enemyPrefab, spawnPoint, Quaternion.identity, enemyParent);
        }
        else
        {
            Debug.LogWarning("Could not find a spawn point far enough from the player. Try a smaller distance!");
        }
    }
}