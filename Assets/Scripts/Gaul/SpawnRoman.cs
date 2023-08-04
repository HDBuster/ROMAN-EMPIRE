using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoman : MonoBehaviour
{
    public GameObject spawn;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 2, 2);
    }

    private void Update()
    {
    }

    // Update is called once per frame
    void Spawn()
    {
        Instantiate(spawn, this.transform.position, Quaternion.identity);
    }
}
