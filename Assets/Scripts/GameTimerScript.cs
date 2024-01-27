using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimerScript : MonoBehaviour
{
    //definir variable de tiempo maximo de juego
    public float maxTime = 10f;
    //definir variable de tiempo actual de juego
    private float countDown = 0f;
    //definir variable de texto de tiempo
    public TMPro.TextMeshProUGUI timerText;
    //definir variable de texto de tiempo

    // gameobject panelGameOver
    public GameObject panelGameOver;

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
        //actualizar tiempo de juego
        countDown += Time.deltaTime;
        //actualizar texto de tiempo
        timerText.text = "Time: " + Mathf.Round(maxTime - countDown);
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

        //detener el tiempo de juego
        Time.timeScale = 0;
    }
}
