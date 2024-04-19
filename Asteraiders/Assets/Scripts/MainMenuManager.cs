using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TMP_Text easterEggDisplay;

    public void Play()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void EasterEgg()
    {
        easterEggDisplay.text = "Bárbara te amo S2";
    }
}
