using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlarGaul : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer rbSprite;
    Vector2 movendo;

    public GameObject ataque;
    private bool ataca;
    private bool atacar;
    private int conta;

    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    float tempoValor = 60f;
    public TextMeshProUGUI temporizador;
    public GameObject textoDerrota;
    private bool vitoria;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rbSprite = GetComponent<SpriteRenderer>();

        ataque.gameObject.SetActive(false);
        winTextObject.SetActive(false);
        textoDerrota.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (tempoValor > 0)
        {
            tempoValor -= Time.deltaTime;
        }
        else
        {
            tempoValor = 0;
            if (vitoria == false)
            {
                textoDerrota.gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
        }

        MostrarTempo(tempoValor);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movendo = context.ReadValue<Vector2>();
        rb.velocity = context.ReadValue<Vector2>() * 20;

        switch (context.phase)
        {
            case InputActionPhase.Performed: //Enquanto a segurar o clique, ative
                animator.SetTrigger("Mover");
                break;
            case InputActionPhase.Started: //Quando clicar, ative
                animator.SetTrigger("Mover");
                break;
            case InputActionPhase.Canceled: //Quando não estiver clicando, desative
                animator.SetTrigger("Idle");
                break;
        }

        float movxx = movendo.x;
        if (movxx > 0)
        {
            rbSprite.flipX = false;
        }
        else if (movxx < 0)
        {
            rbSprite.flipX = true;
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed: //Enquanto a segurar o clique, ative
                animator.SetTrigger("Atacar");
                ataque.gameObject.SetActive(true);
                break;
            case InputActionPhase.Started: //Quando clicar, ative
                animator.SetTrigger("Atacar");
                ataque.gameObject.SetActive(true);
                break;
            case InputActionPhase.Canceled: //Quando não estiver clicando, desative
                animator.SetTrigger("Idle");
                ataque.gameObject.SetActive(false);
                break;
        }

        ataca = context.performed;
        atacar = context.started;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("Roman") && ataca) || (other.gameObject.CompareTag("Roman") && ataca)) 
        {
            other.gameObject.SetActive(false);
            conta++;
            countText.text = "Derrotados: " + conta.ToString() + " / 35";
        }

        if ((other.gameObject.CompareTag("RomanDoor") && ataca) || (other.gameObject.CompareTag("RomanDoor") && atacar))
        {
            if (conta >= 35)
            {
                other.gameObject.SetActive(false);
                winTextObject.SetActive(true);
                vitoria = true;
                Time.timeScale = 0f;
            }
        }
    }

    void MostrarTempo(float tempoMostrar)
    {
        if (tempoMostrar < 0)
        {
            tempoMostrar = 0;
        }

        float minutos = Mathf.FloorToInt(tempoMostrar / 60);
        float segundos = Mathf.FloorToInt(tempoMostrar % 60);

        temporizador.text = "Tempo: " + string.Format("{0:00}:{1:00}", minutos, segundos);
    }
}
