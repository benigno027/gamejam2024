using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelPauseScript : MonoBehaviour
{
    public void PauseGame(GameObject panelPause)
    {
        //reanudar el tiempo
        Time.timeScale = 0;

        //activar el panel de pausa
        panelPause.SetActive(true);
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
