using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerReactionScript : MonoBehaviour
{
    //arreglo de source img del player
    public Sprite[] playerSprites;
    private int index = 1;
    
    // crear una funcion que cambie el sprite del player siempre a la siguiente imagen del arreglo hasta llegar al final
    public void ChangeSprite()
    {
        // si el index del arreglo es menor al largo del arreglo
        if (index < playerSprites.Length)
        {
            // cambiar el source img del gameobject al index del arreglo
            GetComponent<Image>().sprite = playerSprites[index];
            // aumentar el index en 1
            index++;
        }
    }
}
