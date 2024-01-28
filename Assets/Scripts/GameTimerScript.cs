using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimerScript : MonoBehaviour
{
    public float maxTime = 10f;

    private float countDown = 0f;

    public TMPro.TextMeshProUGUI timerText;

    public GameObject panelGameOver;

    public GameObject panelGameWin;

    private bool gameOver = false;

    void Awake()
    {
        //buscar gameobject con el tag "TextTimer" TMPro;
        timerText = GameObject.FindGameObjectWithTag("TextTimer").GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    // actualizar tiempo de juego
    public void UpdateTimer()
    {
        if (!gameOver)
        {
            //actualizar tiempo de juego
            countDown += Time.deltaTime;
            //actualizar texto de tiempo
            timerText.text = "Time: " + Mathf.Round(maxTime - countDown);
        }

        //si el tiempo de juego es mayor al tiempo maximo de juego
        if (countDown >= maxTime)
        {
            StopTimer();
        }
    }

    // funcion para detener el juego
    public void StopTimer()
    {
        //activar el objeto con el tag "PanelGameOver"
        panelGameOver.SetActive(true);
        gameOver = true;
        
    }

    public void WinGame()
    {
        //activar el objeto con el tag "PanelGameWin"
        panelGameWin.SetActive(true);
        gameOver = true;
    }
}
