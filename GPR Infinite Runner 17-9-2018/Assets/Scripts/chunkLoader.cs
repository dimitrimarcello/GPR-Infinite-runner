using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chunkLoader : MonoBehaviour {

    Transform _player;
    [SerializeField]
    Transform spawnLocation;
    GameObject[] chunksEasy;
    GameObject[] chunksMedium;
    GameObject[] chunksHard;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        chunksEasy = GameObject.FindGameObjectsWithTag("ChunksEasy");
        chunksMedium = GameObject.FindGameObjectsWithTag("ChunksMedium");
        chunksHard = GameObject.FindGameObjectsWithTag("ChunksHard");
    }
    private void Update()
    {
        
    }
    void LoadChunk()
    {
        if(transform.position.x >= _player.position.x)
        {
            
            //Instantiate(chunksEasy[1],);
        }
    }

}
