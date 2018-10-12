using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chunkLoader : MonoBehaviour {

    Transform _camera;
    [SerializeField]
    GameObject[] chunksEasy;
    [SerializeField]
    GameObject[] chunksMedium;
    [SerializeField]
    GameObject[] chunksHard;
    bool donnur;

    private void Awake()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        donnur = false;
    }
    private void Update()
    {
        LoadChunk();
        DestroyThis();
    }
    void LoadChunk()
    {
        //checks if a new chunk should be created
        if(_camera.position.x >= transform.position.x && donnur == false)
        {
            Vector3 spawnLocation = new Vector3(transform.position.x + 26, transform.position.y, 0);
            int ods = Random.Range(1, 100);
            if(ods >= 1 && ods <= 40)
            {
                Instantiate(chunksEasy[Random.Range(0,chunksEasy.Length)], spawnLocation, Quaternion.identity);
            }
            if (ods >= 41 && ods <= 80)
            {
                Instantiate(chunksMedium[Random.Range(0, chunksMedium.Length)], spawnLocation, Quaternion.identity);
            }
            if (ods >= 81 && ods <= 100)
            {
                Instantiate(chunksHard[Random.Range(0, chunksHard.Length)], spawnLocation, Quaternion.identity);
            }
            donnur = true;
        }
    }
    void DestroyThis()
    {
        //if object is behind camera it dies.
        if(transform.position.x <= _camera.position.x - 40)
        {
            Destroy(this.gameObject);
        }
    }

}
