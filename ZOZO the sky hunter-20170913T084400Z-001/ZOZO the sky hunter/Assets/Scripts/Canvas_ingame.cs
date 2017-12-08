using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Canvas_ingame : MonoBehaviour {

    public GameObject PauseMenu;
    public PLayerMovement Pm;

    void Start()
    {
        Pm = FindObjectOfType<PLayerMovement>();
    }

	public void Onpause()
    {

        Time.timeScale = 0;
        PauseMenu.SetActive(true);
        Pm.Thememusic.Pause();
    }

    public void  OnResume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale =1;
        Pm.Thememusic.Play();
    }

    public void OnRestart()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        SceneManager.LoadScene("Game");
    }
    public void OnMainMenu()
    {
        PauseMenu.SetActive(false);
        SceneManager.LoadScene("Mainmenu");
        Time.timeScale = 1;
    }
}
