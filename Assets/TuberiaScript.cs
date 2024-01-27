using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuberiaScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        //si el objeto cable colisiona con el objeto tuberia
        if (other.gameObject.CompareTag("Cables"))
        {
            // buscar el objeto con el el tab "GameManager" y ejecutar la funcion "StopTimer"
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameTimerScript>().StopTimer();
        }

        // debug del objeto que colisiona
        Debug.Log(other.gameObject.name);
    }
}
