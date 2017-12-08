using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallscript : MonoBehaviour {

    public int speed = 4;

    public GameObject dp2;

    public EnemyBehaviour eb;

    public Scoremanager scm;

    // Use this for initialization
    void Start() {

        dp2 = GameObject.Find("Destructionpoint2");

        eb = FindObjectOfType<EnemyBehaviour>();

        scm = FindObjectOfType<Scoremanager>();

    }

    // Update is called once per frame
    void Update() {


        transform.Translate(new Vector2(speed * Time.deltaTime, 0));

        if (transform.position.x >= dp2.transform.position.x)
        {

            Destroy(gameObject);
        }
    }

        void OnTriggerEnter2D(Collider2D other)
        { 
            if (other.transform.tag == "Enemy")
            {
            other.gameObject.GetComponent<EnemyBehaviour>().Enemyhp = 0;

            // Destroy(other.gameObject);

            // scm.score++;

        }

        if (other.transform.tag == "MainEnemy")
        {
            other.gameObject.GetComponent<EnemyBehaviour>().Enemyhp -= 100;

        }
        if (other.transform.tag == "EnemyBullet")
        {
            Destroy(other.gameObject);
        }

    }
    
}