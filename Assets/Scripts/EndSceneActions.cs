using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneActions : MonoBehaviour
{
    public void ImtiazButtonClicked()
    {
        Application.OpenURL("https://www.imtiazkhaled.com");
    }

    public void SumataiButtonClicked()
    {
        Application.OpenURL("https://www.instagram.com/sumaita.s/");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
