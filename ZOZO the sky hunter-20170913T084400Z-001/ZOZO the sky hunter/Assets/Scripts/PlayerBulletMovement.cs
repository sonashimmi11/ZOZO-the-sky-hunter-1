using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class PlayerBulletMovement : MonoBehaviour {

    public int Bulletspeed = 5;

   

    public int bulletpower = 50;

    // public Text EnemyKills;

    //  private float kills = 0;

    public EnemyBehaviour Eb;

    public GameObject dp2;

   
	// Use this for initialization
	void Start () {

        //  EnemyKills.text = "Enemy Kills : 0";

        dp2 = GameObject.Find("Destructionpoint2");
        

      //  Eb = FindObjectOfType<EnemyBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
        
        transform.Translate(new Vector2(Bulletspeed * Time.deltaTime, 0));

        if(transform.position.x >=dp2.transform.position.x)
            {

            Destroy(gameObject);
        }

	}
 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Enemy" || other.transform.tag == "MainEnemy")
        {
            Eb = other.GetComponent<EnemyBehaviour>();
            Eb.Enemyhp -= bulletpower;
            //Destroy(other.gameObject);

            // kills++;
            //Scoremanager.score++;
           // EnemyKills.text = "Enemy Kills :" + kills; 
            Destroy(gameObject);
        }

       
    }
}
