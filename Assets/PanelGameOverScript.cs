using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelGameOverScript : MonoBehaviour
{
    public GameObject image1; 
    public GameObject image2;
    public GameObject image3;
    public Transform UbicionFinal1;
    public Transform UbicionFinal2;
    public Transform UbicionFinal3;
    
    public float movespeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        MoveImage(image1, UbicionFinal1);
        MoveImage(image2, UbicionFinal2);
        MoveImage(image3, UbicionFinal3);

    }
    void MoveImage(GameObject image , Transform target)
    {
        float step =  movespeed * Time.deltaTime; // calculate distance to move
        image.transform.position = Vector3.MoveTowards(image.transform.position, target.position, step);
        
    }
}
