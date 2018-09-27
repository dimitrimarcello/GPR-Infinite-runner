using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        DestroyObject();
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
