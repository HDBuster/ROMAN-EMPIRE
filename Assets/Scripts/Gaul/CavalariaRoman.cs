using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CavalariaRoman : MonoBehaviour
{

    private Rigidbody2D rb;
    private Vector2 direcao;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direcao = Vector2.left;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.Translate(Vector2.left * 10 * Time.fixedDeltaTime);
        rb.velocity = direcao * 10;
    }
}
