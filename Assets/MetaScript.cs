using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaScript : MonoBehaviour
{

    public GameObject panelGameWin;
    

    void OnCollisionEnter2D(Collision2D other)
    {
        //si el objeto cable colisiona con el objeto tuberia
        if (other.gameObject.CompareTag("Cables"))
        {
            panelGameWin.SetActive(true);
            Time.timeScale = 0;
        }

        // debug del objeto que colisiona
        Debug.Log(other.gameObject.name);
    }
}
