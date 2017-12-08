using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shieldonplayer : MonoBehaviour {

    public EnemyBehaviour Eb;

	// Use this for initialization
	void Start () {
       // Eb = GameObject.FindObjectOfType<EnemyBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.transform.tag == "EnemyBullet")
        {
          //  Eb = other.GetComponent<EnemyBehaviour>();
           // Eb.Enemyhp -= bulletpower;
            //Destroy(other.gameObject);

            // kills++;
            //Scoremanager.score++;
            // EnemyKills.text = "Enemy Kills :" + kills; 
            Destroy(other.gameObject);
        }

        if (other.transform.tag == "Enemy")
        {
            Eb = other.GetComponent<EnemyBehaviour>();
            Eb.Enemyhp = 0;
        }


    }
}
