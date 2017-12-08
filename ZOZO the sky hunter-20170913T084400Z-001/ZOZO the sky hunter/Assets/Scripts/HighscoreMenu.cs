using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreMenu : MonoBehaviour {

    public Text Highscore;

    public float highscore;

	// Use this for initialization
	void Start () {

        if (PlayerPrefs.HasKey("Highestscore"))
        {
            highscore = PlayerPrefs.GetFloat("Highestscore");
        }

        Highscore.text = "High Score : " + highscore;
    }
	
	// Update is called once per frame
	void Update () {
        Highscore.text = "High Score : " + highscore;

    }
}
