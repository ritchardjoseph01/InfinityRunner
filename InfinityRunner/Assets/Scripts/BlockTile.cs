using UnityEngine;

public class BlockTile : MonoBehaviour
{
    BlockSpawner blockSpawner;


    // Start is called before the first frame update
    void Start()
    {
        blockSpawner = GameObject.FindObjectOfType<BlockSpawner>(); // Referencing BlockSpawner Script
        SpawnObstacle();
    
    }

    private void OnTriggerExit (Collider other)
    {
        blockSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject obstaclePrefab;

    void SpawnObstacle()
    {
        // Choose random point for obstacle spawn
        int obstacleSpawnIndex = Random.Range(2, 5); //choosing randomly between indexes 
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }
}
