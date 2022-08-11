using UnityEngine;

public class BlockTile : MonoBehaviour
{
    BlockSpawner blockSpawner;


    // Start is called before the first frame update
    void Start()
    {
        blockSpawner = GameObject.FindObjectOfType<BlockSpawner>(); // Referencing BlockSpawner Script
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
}
