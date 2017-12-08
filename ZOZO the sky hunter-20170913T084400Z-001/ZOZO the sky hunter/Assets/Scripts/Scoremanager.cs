using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoremanager : MonoBehaviour {

    public Text EnemiesKill;

    public float score = 0;

    public Text Highscore;

    public float highscore = 0;

	// Use this for initialization
	void Start () {
		
       if (PlayerPrefs.HasKey("Highestscore"))
        {
            highscore = PlayerPrefs.GetFloat("Highestscore");
        }
	}
	
	// Update is called once per frame
	void Update () {
        EnemiesKill.text = "Score : " + score;

        if(score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetFloat("Highestscore", highscore);
        }

        Highscore.text = "High Score : " + highscore;

	}
}
