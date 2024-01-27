using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelPauseScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //detener el tiempo
        Time.timeScale = 0;
    }

    // cargar escena
    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void ResumeGame()
    {
        //reanudar el tiempo
        Time.timeScale = 1;
        //desactivar el panel de pausa
        gameObject.SetActive(false);
    }
}
