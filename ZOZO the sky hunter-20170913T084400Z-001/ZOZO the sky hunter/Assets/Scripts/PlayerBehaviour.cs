using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    public PLayerMovement PM;

    public bool Invisible = false ;

    public GameObject Destructionpoint_pickup;

    public bool Spower_pickup;

    public GameObject Wall;

    public GameObject PickupsoundGameobject;

    public AudioSource Pickupsound;


    public GameObject Shieldonplayer;

	// Use this for initialization
	void Start () {

        PM = FindObjectOfType<PLayerMovement>();
        Invisible = false;
        Destructionpoint_pickup = GameObject.Find("DestructionPoint");

        PickupsoundGameobject = GameObject.Find("Pickupaudio");

        Pickupsound = PickupsoundGameobject.GetComponent<AudioSource>();

        Shieldonplayer = GameObject.Find("shieldonplayer");

        Spower_pickup = false;


    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector2(-6 * Time.deltaTime, 0));


       // if (transform.position.x < Destructionpoint_pickup.transform.position.x)
       // {
        //    Destroy(gameObject);
       // }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("enter triggerdddddddd");

        if (transform.tag == "Healthpickup" && other.transform.tag == "Player1")
        {
            Debug.Log("enter health");
            PM.Playerhealth += 50;
            Destroy(gameObject);

            Pickupsound.Play();
        }
        if (transform.tag == "Shield" && other.transform.tag == "Player1")
        {
            Debug.Log("entered shield");
            //Invisible = true;
            //  Destroy(gameObject);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
           
         //  PM.StartCoroutine("Invisibility");

            Pickupsound.Play();

            StartCoroutine("Shield");



            //Invisible = false;
        }
        if (transform.tag == "Spower" && other.transform.tag == "Player1")
        {
            Debug.Log("entered Spower");
            Destroy(gameObject);
            StartCoroutine("Spower_ienum");

            Pickupsound.Play();

        }

        if (transform.tag == "Wallpowerup" && other.transform.tag == "Player1")
        {
            Debug.Log("enetered Wallpower");
            Destroy(gameObject);
            Instantiate(Wall);

            Pickupsound.Play();

        }
        if (transform.tag == "Bulletpowerup" && other.transform.tag == "Player1")
        {
            //  Debug.Log("enetered Wallpower");
            //  Destroy(gameObject);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;


            Pickupsound.Play();
            StartCoroutine("Spower_ienum");

        }

    }

    public IEnumerator Spower_ienum()
    {
        Spower_pickup = true;
        yield return new WaitForSeconds(30f);
        Spower_pickup = false;
    }

   public IEnumerator Shield()
    {
        Shieldonplayer.transform.localScale = new Vector3(1, 1, 1);
        yield return new WaitForSecondsRealtime(10.0f);
        //  yield return new WaitForSeconds(4.0f);
       // gameObject.GetComponent<SpriteRenderer>().enabled = true;

        Shieldonplayer.transform.localScale = new Vector3(0, 0, 0);

        Destroy(gameObject);
        Debug.Log("shield over");

    }



}
