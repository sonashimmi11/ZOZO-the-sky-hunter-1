using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Canvas : MonoBehaviour {

    public GameObject flyanim;


   public  void OnclickPlay()
    {
        //StartCoroutine("Fly");
        SceneManager.LoadScene("Game");

        Time.timeScale = 1;
    }

     IEnumerator Fly()
    {
        flyanim.SetActive(true);
        yield return new WaitForSeconds(10f);
        flyanim.SetActive(false);
    }

    public void OnclickStory()
    {
        SceneManager.LoadScene("Story");
    }

    public void OnclickTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Exit()
    {
        Application.Quit();
    }

}
