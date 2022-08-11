using UnityEngine;

public class BlockSpawner : MonoBehaviour
{

    public GameObject groundTile;
    Vector3 nextSpawnPoint;

    void SpawnTile()
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnTile();
        SpawnTile();
        SpawnTile();
        SpawnTile();

    }

}
