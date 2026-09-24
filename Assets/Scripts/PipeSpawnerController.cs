using UnityEngine;

public class PipeSpawnerController : MonoBehaviour
{
    [SerializeField]
    private GameObject pipePrefab;

    [SerializeField]
    private float spawnInterval = 2f;

    private float timer = 0f;

    private float spawnHeightOffset = 10f;
    
    void Start()
    {
        if(pipePrefab == null)
        {
            Debug.LogError("Pipe Prefab is not assigned in the inspector.");
        }
        else
        {
            SpawnPipe();
        }
    }

    void Update()
    {
        if(BirdScript.isBirdAlive)
        {
            if(timer < spawnInterval)
            {
                timer += Time.deltaTime;
            }
            else
            {
                SpawnPipe();
                timer = 0f;
            }
        }
    }

    void SpawnPipe()
    {
        float lowestPoint = transform.position.y - spawnHeightOffset;
        float highestPoint = transform.position.y + spawnHeightOffset;

        Instantiate(pipePrefab, transform.position + Vector3.up * Random.Range(lowestPoint, highestPoint), Quaternion.identity);
    }
}
