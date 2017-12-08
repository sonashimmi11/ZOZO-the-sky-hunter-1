using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainenemybulletMovement : MonoBehaviour {

    public int Bulletspeed = -5;

    public float speed = 3;

    public GameObject Destructionpoint;


    public PLayerMovement Pm;

    public PlayerBehaviour Pb;

    public bool invisiblemode;

    private float degrees = 90;

    public float amplitude = 2;

    private GameObject Bulletobjectcollision;

    private AudioSource Bulletobjectcollisionsound;

    // Use this for initialization
    void Start()
    {

        Destructionpoint = GameObject.Find("DestructionPoint");


        Pm = FindObjectOfType<PLayerMovement>();

        Pb = FindObjectOfType<PlayerBehaviour>();

        //  invisiblemode = false;

       // Bulletobjectcollision = GameObject.Find("Bulletobjectcoll Audio");

       // Bulletobjectcollisionsound = Bulletobjectcollision.GetComponent<AudioSource>();



    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(new Vector2(-1 * speed, -Mathf.Sin(Mathf.Deg2Rad * degrees)) * amplitude * Time.deltaTime);

        degrees++;

        if (transform.position.x < Destructionpoint.transform.position.x)
        {
            Destroy(gameObject);
        }

        // if(Pb.Invisible == true )
        //{
        // invisiblemode = true;
        // }


    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player1")
        {
            Pm.Playerhealth -= 5;
            // Destroy(other.gameObject);
            Destroy(gameObject);
           // Bulletobjectcollisionsound.Play();
        }
        if (other.transform.tag == "playerbullet")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

    }
}
