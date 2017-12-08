using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CanvasStorymode : MonoBehaviour {


    public GameObject Firstpage;

    public GameObject secondpage;

    public GameObject Thirdpage;

   // public GameObject[] Pages;



    public void Backtomenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }

    public void Nextbutton()
    {
        if(Firstpage.activeInHierarchy)
        {
            Firstpage.SetActive(false);
            secondpage.SetActive(true);
            return;
        }
        if (secondpage.activeInHierarchy)
        {
            secondpage.SetActive(false);
            Thirdpage.SetActive(true);
            return;
        }

        

    }
    public void Backbutton()
    {

        if (Thirdpage.activeInHierarchy)
        {
            Thirdpage.SetActive(false);
            secondpage.SetActive(true);
            return;
        }
        if (secondpage.activeInHierarchy)
        {
            secondpage.SetActive(false);
            Firstpage.SetActive(true);
            return;
        }
    }
}
