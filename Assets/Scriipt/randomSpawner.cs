using UnityEngine;

public class randomSpawner : MonoBehaviour
{
  public GameObject GameObject;
    public float a = 1, b = 10;
    public float interval = 7;

    void Start()
    {
        GameObject.SetActive(true);
        InvokeRepeating(nameof(Spawn), 0f, interval);
    }
    void Spawn()
    {

        Vector3 randomSpawnPosition = new Vector3(Random.Range(a,b),5, Random.Range(a, b));
        Instantiate(GameObject, randomSpawnPosition, Quaternion.identity);
        
    }
}
