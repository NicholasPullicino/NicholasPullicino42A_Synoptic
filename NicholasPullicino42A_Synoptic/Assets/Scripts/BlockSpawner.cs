using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] blocks;
    GameObject randomBlock;
    Vector2 blockPosition, startingPosition;

    void Start()
    {
        LoadBlocksFromResources();
        startingPosition = transform.position;
        PrintBlocksOnXandY();
    }

    void LoadBlocksFromResources()
    {
        blocks = Resources.LoadAll<GameObject>("Blocks");

        blockPosition = transform.position;
    }

    void GetRandomBlock()
    {
        int randomNumber = Random.Range(0, blocks.Length);

        randomBlock = blocks[randomNumber];
    }

    void SpawnBlocks()
    {
        Instantiate(randomBlock, blockPosition, transform.rotation);
    }

    void PrintBlocksOnXandY()
    {
        for (int y = 5; y > 1; y--)
        {
 
            for (int x = 1; x < 15; x += 2)
            {
                GetRandomBlock();
                SpawnBlocks();
                blockPosition.x += 2;
            }
            blockPosition.x = startingPosition.x;
            blockPosition.y -= 2;
        }
    }
}
