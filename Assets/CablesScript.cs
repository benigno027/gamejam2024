using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CablesScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
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
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameTimerScript>().StopTimer();
        }
    }
}
