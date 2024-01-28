using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MiniGame1Scripts : MonoBehaviour
{
    public GameObject Lives;
    public int lives = 3;
    public GameObject[] gameObjectsButtons;
    public List<int> IndiceSeleccionados = new List<int>();
    public int [] Recorridos;
    public ErrorSonidosScript sonidosScript;

    public PlayerReactionScript playerReactionScript;


    private bool BlockButtons = false;

    void Awake()
    {
        Lives = GameObject.FindGameObjectWithTag("Lives");
        playerReactionScript = GameObject.FindGameObjectWithTag("PlayerReaction").GetComponent<PlayerReactionScript>();
    }

    void Start()
    {
        IniciarJuego(); 
        sonidosScript = GameObject.FindGameObjectWithTag("ErrorSonidosScript").GetComponent<ErrorSonidosScript>();
    }

    void Update()
    {
        if (lives == 0)
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameTimerScript>().StopTimer();
        }
    }

    public void IniciarJuego()
    {
        Recorridos = new int[3];

        for (int i = 0; i < Recorridos.Length; i++)
        {
            Recorridos[i] = UnityEngine.Random.Range(0, gameObjectsButtons.Length);
            Debug.Log(Recorridos[i]);

        }
        StartCoroutine(ButtonSignal());
    }

    public void ComprobarFoco(int indice)
    {
        if (BlockButtons)
        {
            return;
        }
        //verificar si el indice existe en el array de recorridos
        int existe = System.Array.IndexOf(Recorridos, indice);

        if(existe != -1){
            Debug.Log("Existe");
            IndiceSeleccionados.Add(indice);
            // verificar la ultima posicion de IndiceSeleccionados es igual a la ultima posicion de Recorridos
            if(IndiceSeleccionados[IndiceSeleccionados.Count - 1] == Recorridos[IndiceSeleccionados.Count - 1]){
                Debug.Log("Correcto");
                if(IndiceSeleccionados.Count == Recorridos.Length){
                    Debug.Log("Ganaste");
                    GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameTimerScript>().WinGame();
                }
            } else {
                Debug.Log("Incorrecto");
                lives--;
                if (lives >= 0)
                {
                    playerReactionScript.ChangeSprite();
                    sonidosScript.PlayRandomSound();
                    Destroy(Lives.transform.GetChild(lives).gameObject);
                    StartCoroutine(ButtonSignal());
                }
            }
        } 
        else
        {
            Debug.Log("No existe");
            sonidosScript.PlayRandomSound();
            lives--;
            if (lives >= 0)
            {
                playerReactionScript.ChangeSprite();
                Destroy(Lives.transform.GetChild(lives).gameObject);
                StartCoroutine(ButtonSignal());
            }
        }
    }

    IEnumerator ButtonSignal()
    {
        BlockButtons = true;

        for (int i = 0; i < Recorridos.Length; i++)
        {
            int idx = Recorridos[i];

            SetButtonColor(idx, Color.red);
            yield return new WaitForSeconds(0.5f);

            SetButtonColor(idx, Color.white);
            yield return new WaitForSeconds(0.5f);
        }

        
        IndiceSeleccionados = new List<int>();

        BlockButtons = false;
    }

    void SetButtonColor(int idx, Color color)
    {
        Debug.Log("idx");
        Debug.Log(idx);
        Button button = gameObjectsButtons[idx].GetComponent<Button>();
        ColorBlock colors = button.colors;
        colors.normalColor = color;
        button.colors = colors;
    }
}