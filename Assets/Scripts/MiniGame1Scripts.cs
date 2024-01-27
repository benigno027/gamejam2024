using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MiniGame1Scripts : MonoBehaviour
{
    
    public GameObject[] gameObjectsButtons = new GameObject[9];
    public int [] IndiceSeleccionados;
    public int [] Recorridos;

    void Start()
    {
        IndiceSeleccionados = new int[3];
        Recorridos = new int[3];

        for (int i = 0; i < Recorridos.Length; i++)
        {
            Recorridos[i] = UnityEngine.Random.Range(0, gameObjectsButtons.Length) - 1;
            Debug.Log(Recorridos[i]);

        }
        StartCoroutine(ButtonSignal());
    }

    public void ComprobarFoco(int indice)
    {
        //verificar si el indice existe en el array de recorridos
        int existe = System.Array.IndexOf(Recorridos, indice);

        if(existe != -1){
            Debug.Log("Existe");
        }
        else{
            Debug.Log("No existe");
        }
    }

    IEnumerator ButtonSignal()
    {
        
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

