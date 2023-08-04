using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGaul : MonoBehaviour
{
    public GameObject spawn;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 2, 2);
    }

    // Update is called once per frame
    void Spawn()
    {
        Instantiate(spawn, this.transform.position, Quaternion.Euler(0, 180, 0));
    }
}
