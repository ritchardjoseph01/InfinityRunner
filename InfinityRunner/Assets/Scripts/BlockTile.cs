using UnityEngine;

public class BlockTile : MonoBehaviour
{
    BlockSpawner blockSpawner;


    // Start is called before the first frame update
    void Start()
    {
        blockSpawner = GameObject.FindObjectOfType<BlockSpawner>(); // Referencing BlockSpawner Script
        SpawnObstacle();
        SpawnCoin();
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

    public GameObject coinPrefab;

    void SpawnCoin()
    {
        int coinsToSpawn = 10;
        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider (Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );

        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }

}
