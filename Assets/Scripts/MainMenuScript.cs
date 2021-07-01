using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void Freeplay()
    {
        SceneManager.LoadScene("FreePlay");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
