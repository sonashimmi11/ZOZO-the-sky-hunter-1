using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mainenemybullet2 : MonoBehaviour {

    private GameObject player;

    public float speed = 2;

    public PLayerMovement Pm;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");

        Pm = FindObjectOfType<PLayerMovement>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector2(-2 * speed * Time.deltaTime, 0));
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, player.transform.position.y), Time.deltaTime);

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player1")
        {
            Pm.Playerhealth -= 5;
            // Destroy(other.gameObject);
            Destroy(gameObject);
            //  Bulletobjectcollisionsound.Play();

        }
        if (other.transform.tag == "playerbullet")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

    }
}
