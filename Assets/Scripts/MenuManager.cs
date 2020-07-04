using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{


    public void Load(int index)
    {
        SceneManager.LoadScene(index);
        PlayerPrefs.SetInt("Sitatus", 0);

    }

    public void Continue(int index)
    {
        SceneManager.LoadScene(index);
        PlayerPrefs.SetInt("Sitatus", 1);
    }


    public void Quit()
    {
        Application.Quit();
    }
}
