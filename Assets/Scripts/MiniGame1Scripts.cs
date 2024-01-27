using UnityEngine;
using UnityEngine.UI;

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
            Recorridos[i] = Random.Range(0, gameObjectsButtons.Length);
            Debug.Log(Recorridos[i]);
        }
    }

    void Update()
    {
    }
}

