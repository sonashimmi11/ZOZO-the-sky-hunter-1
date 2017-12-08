using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Openingscreen : MonoBehaviour {

    public float colorincrement = 0.1f;

    public Color clr;

    public SpriteRenderer Opening_screen;

    private float Timer = 0;

  //  public GameObject OpeningTheme;

    public AudioSource Openingaudio;



    // Use this for initialization
    void Start () {

        // Color clr = new Color(clr.r, clr.g, clr.b, 0f);

        //Color clr = GetComponent<Image>().color;

        Opening_screen = GetComponent<SpriteRenderer>();
        clr = Opening_screen.color;

        StartCoroutine("Mainmenu");

        Openingaudio.Play();

    }
	
	// Update is called once per frame
	void Update () {
        Timer += Time.deltaTime;
        if (colorincrement <= 1 && Timer >=0.4f)
        {

            Color clr2 = new Color(clr.r, clr.g, clr.b, colorincrement);

            Opening_screen.color = clr2;

            colorincrement += 0.1f;

            Timer = 0;


        }
        
    }

    IEnumerator Mainmenu()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Mainmenu");
        Openingaudio.Stop();

    }
}
