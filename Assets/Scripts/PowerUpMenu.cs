using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMenu : MonoBehaviour
{
    public GameObject powerupUi;

    public void CloseMenu()
    {
        powerupUi.SetActive(false);
        Time.timeScale = 1f;  
    }
    public void BringUpMenu()
    {
        powerupUi.SetActive(true);
        Time.timeScale = 0f;
    }
}
