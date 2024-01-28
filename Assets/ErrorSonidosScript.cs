using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorSonidosScript : MonoBehaviour
{
    public AudioClip[] sonidos;
    
    // funcion para reproducir sonidos aleatorios
    public void PlayRandomSound()
    {
        // reproducir sonido aleatorio
        int index = Random.Range(0, sonidos.Length);
        AudioSource.PlayClipAtPoint(sonidos[index], transform.position, 1f);
    }

}
