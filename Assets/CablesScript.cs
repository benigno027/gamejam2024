using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CablesScript : MonoBehaviour
{
    public GameObject Lives;
    public int lives = 3;

    public ErrorSonidosScript sonidosScript;

    void Start()
    {
        Lives = GameObject.FindGameObjectWithTag("Lives");
        sonidosScript = GameObject.FindGameObjectWithTag("ErrorSonidosScript").GetComponent<ErrorSonidosScript>();
    }

    // programar movimiento del objeto cable con las flechas del teclado
    void FixedUpdate()
    {
        //definir variable de velocidad de movimiento
        float speed = 10f;
        //definir variable de movimiento horizontal
        float moveHorizontal = Input.GetAxis("Horizontal");
        //definir variable de movimiento vertical
        float moveVertical = Input.GetAxis("Vertical");
        //definir variable de movimiento
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        //definir variable de movimiento
        transform.position = transform.position + movement * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Tuberia")
        {
            lives--;
            sonidosScript.PlayRandomSound();
            // buscar el primer hijo de Lives y destruirlo en base a la variable lives
            if(lives >= 0){
                Destroy(Lives.transform.GetChild(lives).gameObject);
            }
        }
    }

    void Update()
    {
        if (lives == 0)
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameTimerScript>().StopTimer();
        }
    }
}
