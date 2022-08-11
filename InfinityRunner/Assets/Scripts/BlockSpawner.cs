using UnityEngine;

public class BlockSpawner : MonoBehaviour
{

    [SerializeField] GameObject blockTile;
    Vector3 nextSpawnPoint;

    public void SpawnTile(bool spawnItems)
    {
        GameObject temp = Instantiate(blockTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

        if (spawnItems)
        {
            temp.GetComponent<BlockTile>().SpawnObstacle();
            temp.GetComponent<BlockTile>().SpawnCoin();
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            if (i < 3)
            {
                SpawnTile(false); // 3 blocks will be empty
            }
            else
            {
               SpawnTile(true);
            }
        }
    }

}
