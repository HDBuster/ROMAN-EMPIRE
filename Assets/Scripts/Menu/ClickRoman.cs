using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickRoman : MonoBehaviour
{
    public Button botao;

    void Start()
    {
        Button botao = GetComponent<Button>();
        botao.onClick.AddListener(Cena);
    }

    private void Cena()
    {
        SceneManager.LoadScene(2);
    }
}
