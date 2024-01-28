using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MiniGame1Scripts : MonoBehaviour
{
    public GameObject canvasGame;
    public GameObject Lives;
    public int lives = 3;
    public GameObject[] gameObjectsButtons;
    public List<int> IndiceSeleccionados = new List<int>();
    public int [] Recorridos;

    void Start()
    {
        Lives = GameObject.FindGameObjectWithTag("Lives");
        gameObjectsButtons = GameObject.FindGameObjectsWithTag("Foco");
        CargarEventosDeBotones();
        IniciarJuego(); 
    }

    void Update()
    {
        if (lives == 0)
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameTimerScript>().StopTimer();
            canvasGame.SetActive(false);
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

    // crear funcion para iteral el arreglo de gameObjectsButtons y asinar el evento OnClick con la funcion ComprobarFoco y pasar el indice como parametro  
    void CargarEventosDeBotones()
    {
        for (int i = 0; i < gameObjectsButtons.Length; i++)
        {
            Button button = gameObjectsButtons[i].GetComponent<Button>();
            button.onClick.AddListener(() => ComprobarFoco(i));
        }
    }

    public void ComprobarFoco(int indice)
    {
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
                    canvasGame.SetActive(false);
                }
            } else {
                Debug.Log("Incorrecto");
                lives--;
                if (lives >= 0)
                {
                    Destroy(Lives.transform.GetChild(lives).gameObject);
                    StartCoroutine(ButtonSignal());
                }
            }

        } else {
            Debug.Log("No existe");
            lives--;
            if (lives >= 0)
            {
                Destroy(Lives.transform.GetChild(lives).gameObject);
                StartCoroutine(ButtonSignal());
            }
        }
    }

    IEnumerator ButtonSignal()
    {
        
        IndiceSeleccionados = new List<int>();

        for (int i = 0; i < Recorridos.Length; i++)
        {
            int idx = Recorridos[i];

            SetButtonColor(idx, Color.red);
            yield return new WaitForSeconds(0.5f);

            SetButtonColor(idx, Color.white);
            yield return new WaitForSeconds(0.5f);
        }
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