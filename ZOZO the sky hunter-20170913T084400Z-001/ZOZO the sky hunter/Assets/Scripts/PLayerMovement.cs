using UnityEngine;

using System.Collections;

using UnityEngine.EventSystems;

using UnityEngine.UI;





public class PLayerMovement : MonoBehaviour {
    Vector2 pos;

    Vector2 FlightMovement;

    public float PlayerSpeed = 5;

    public GameObject PlayerBullet;

    private int i;

    private bool shooting = false;

    public int Playerhealth = 100;

    public static bool Gameover = false;

    public bool SBullet = false;

    public BoxCollider2D Playercollider;

    public PlayerBehaviour Pb_pm;

    public GameObject Deathmenu;

    public Slider Playerhealthbar;

    public AudioSource Shooting_audio;

    public AudioSource Playerdeathsound;

    private Animator Playeranim;

    public bool Crackedplane;

    public AudioSource Thememusic;

  


    IEnumerator PlayerShooting()
    {
       // if (Pb_pm.Spower_pickup == false)
       // {
            for (i = 0; i < 1; i++)
           {
                Instantiate(PlayerBullet, new Vector2(transform.position.x + 1.5f, transform.position.y - 0.23f), transform.rotation);

                yield return new WaitForSeconds(0.3f);
            }
            shooting = false;
       // }

        /*if(Pb_pm.Spower_pickup)
        {
            for (i = 0; i < 2; i++)
            {
               Instantiate(PlayerBullet, new Vector2(transform.position.x + 0.7f, transform.position.y), transform.rotation);

               // Instantiate(PlayerBullet, new Vector2(transform.position.x + 0.f, transform.position.y), transform.rotation);

               // Instantiate(PlayerBullet, new Vector2((transform.position.x + 0.7f)*Mathf.Sin(30), transform.position.y*Mathf.Cos(30)), transform.rotation);

               // Instantiate(PlayerBullet, new Vector2((transform.position.x + 0.7f)*Mathf.Cos(30), transform.position.y*Mathf.Sin(30)), transform.rotation);

                yield return new WaitForSeconds(0.1f);
          }
            shooting = false;
        }*/
    }

    public void shoot()
    {

        if (shooting == false)
        {
            shooting = true;
            StartCoroutine("PlayerShooting");

        }
    }
/*
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("enter triggerdddddddd");

        if (other.transform.tag == "Healthpickup")
        {
            Debug.Log("enter trigger");
            Playerhealth += 50;
            Destroy(other.gameObject);
        }
    }
    */

    // Use this for initialization
    void Start () {

        Playercollider = GetComponent<BoxCollider2D>();

        Pb_pm = FindObjectOfType<PlayerBehaviour>();

        Playerhealthbar.value = Playerhealth;

        Crackedplane = false;

        Playeranim = gameObject.GetComponent<Animator>();

        Thememusic.Play();

  
	}



    // Update is called once per frame
    void Update()
    {

        if (Playerhealth < 50 && Playerhealth > 0)
        {
            Crackedplane = true;
        }

        if (Playerhealth >= 50)
        {
            Crackedplane = false;
        }

        Playeranim.SetBool("Crackedplane", Crackedplane);

        FlightMovement = Input.acceleration;
        //   transform.Translate(new Vector3(0, FlightMovement.y * Time.deltaTime*PlayerSpeed, 0));

        //   transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3, 3), transform.position.z);
        //
        //   transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, Mathf.Clamp( FlightMovement.y * PlayerSpeed,-3,3), transform.position.z), Time.deltaTime );

        Playerhealthbar.value = Playerhealth;

        // RaycastHit hit;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);


            // if  (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            //  {
            pos = Camera.main.ScreenToWorldPoint(touch.position);

            //  return;
            //  }
            //     if (!EventSystem.current.IsPointerOverGameObject())// && touch.phase == TouchPhase.Began)
            //   {
            //  Touch touch = Input.GetTouch(0);
            //     pos = Camera.main.ScreenToWorldPoint(touch.position);

            //           }

            //00nsform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, pos.y, transform.position.z), Time.deltaTime * PlayerSpeed);

            // Debug.Log(pos);
        }

        //    if( Input.GetMouseButton(0))
        //  {
        //
        //     if (!EventSystem.current.IsPointerOverGameObject())
        {
            //      pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //   }

            //   }
            if (pos.x < -3f)
            {
               // transform.Translate(new Vector3(0, pos.y * Time.deltaTime * PlayerSpeed, 0));
                 transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, Mathf.Clamp(pos.y, -3, 3), transform.position.z), Time.deltaTime * PlayerSpeed);

               // transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3, 3), transform.position.z);

                // transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, Mathf.Clamp( FlightMovement.y * PlayerSpeed,-3,3), transform.position.z), Time.deltaTime );
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (shooting == false)
                {
                    Shooting_audio.Play();
                    if (Shooting_audio.isPlaying)
                    {
                        Shooting_audio.Stop();
                        Shooting_audio.Play();
                    }
                    shooting = true;
                    StartCoroutine("PlayerShooting");

                }
            }

            if (Playerhealth <= 0)
            {
                Playerdeathsound.Play();
                Gameover = true;
                Destroy(gameObject);
                Time.timeScale = 0;
                 Deathmenu.SetActive(true);

                Thememusic.Stop();

            }
            if (Playerhealth > 100)
            {
                Playerhealth = 100;
            }



        }
    }

    public IEnumerator Invisibility()
    {
        Playercollider.enabled = false;
        yield return new WaitForSeconds(10f);
        Playercollider.enabled = true;
    }

    




}
