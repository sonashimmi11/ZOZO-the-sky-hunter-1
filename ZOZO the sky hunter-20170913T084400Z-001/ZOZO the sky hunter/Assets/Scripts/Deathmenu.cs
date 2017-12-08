using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Deathmenu : MonoBehaviour {

    public void Restart()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void Mainmenu()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("Mainmenu");
        Time.timeScale = 1;
    }

}
