using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    public float speed = 3;

    private Rigidbody2D rb;

    public GameObject EnemyBulletPrefab;

    public GameObject Mainenemybullet2;

    public int Enemyhp = 50;

    public bool singleCoroutine;

    public int bulletpower = 5;
    
    public int oncollision = 10; 

  //  public GameObject Enemies;

    private int i;

    public GameObject Destructionpoint;

    public PLayerMovement pm;

    public GameObject Player;

    private float degrees = 90;

    public float amplitude = 2;

    public Scoremanager scm;

    public EnemyManager Em;

    public float VSpeed ;

    public bool movedown;

    public bool moveleft;

    private float Rounds = 0;

    public float HSpeed;

    public int Ydirection = 1;

    public int Xdirection = 1;

    public int loop = 0;

    public GameObject[] Points;

    int pos;

    public int Round_rand ;

    public int randxvalue;

    public PickupManager Pmw;

    private Renderer rend;

    private Color clr;

    public GameObject FlickeringsoundGameobject;

    private AudioSource Flickeringsound;

    private GameObject EnemydeathsoundGameobject;

    private AudioSource Enemydeathsound;

    private float time = 0;


    

    public enum MovementBehaviour
    {
        
        Normal,
        Wave,
        Follow,
        Mainvillian
    };

   public MovementBehaviour Mb;
	// Use this for initialization



    void Start()
    {

        FlickeringsoundGameobject = GameObject.Find("Flickering audio");
        singleCoroutine = true;

        Flickeringsound = FlickeringsoundGameobject.GetComponent<AudioSource>();

        EnemydeathsoundGameobject = GameObject.Find("Enemydeath Audio");

        Enemydeathsound = EnemydeathsoundGameobject.GetComponent<AudioSource>();

       // Flickeringsound.Play();


        Pmw = FindObjectOfType<PickupManager>();
        Round_rand = Random.Range(2,3);
        pos = 0;
        Player = GameObject.Find("Player");

        rend = Player.GetComponent<Renderer>();
        clr = rend.material.color;
        Points = new GameObject[5];

        Points[0] = GameObject.Find("point1");

        Points[1] = GameObject.Find("point2");

        Points[2] = GameObject.Find("point3");

        Points[3] = GameObject.Find("point4");

        Points[4] = GameObject.Find("point5");



        rb = GetComponent<Rigidbody2D>();
        if ((Mb == MovementBehaviour.Normal))
        {
            Invoke("NormalShootingFunc", 0.5f);

        }
        if ((Mb == MovementBehaviour.Follow))
        {
            Invoke("ShootingFunc", 0.5f);

        }

        if (Mb == MovementBehaviour.Mainvillian)
          {
            Invoke("ShootingMainEnemyFunc", 0.5f);
            // Invoke("ShootingMainEnemyFunc", 1f);
         // ShootingMainEnemyFunc();

        }
        Destructionpoint = GameObject.Find("DestructionPoint");

        scm = FindObjectOfType<Scoremanager>();

        pm = FindObjectOfType<PLayerMovement>();

        Em = FindObjectOfType<EnemyManager>();

        randxvalue = Random.Range(1, 4);

    }




    void Update()
    {

        time += Time.deltaTime;

        if(time > 3 && Mb == MovementBehaviour.Mainvillian)
        {
            Instantiate(Mainenemybullet2, new Vector2(transform.position.x - 2f, transform.position.y), transform.rotation);
            time = 0;
        }

        if (Rounds < Round_rand)
        {
            loop = 0;
            HSpeed = 0;
            VSpeed = 3;
        }
        if (Mb == MovementBehaviour.Normal)
        {
            transform.Translate(new Vector2(-2 * speed * Time.deltaTime, 0));
        }
        else if (Mb == MovementBehaviour.Follow && Player != null)
        {
            transform.Translate(new Vector2(-2 * speed * Time.deltaTime, 0));
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, Player.transform.position.y), Time.deltaTime);

        }
        else if (Mb == MovementBehaviour.Wave)
        {

            transform.Translate(new Vector2(-1 * speed, Mathf.Sin(Mathf.Deg2Rad * degrees)) * amplitude * Time.deltaTime);
            degrees++;

        }

        else if (Mb == MovementBehaviour.Mainvillian)
        {
            //  Debug.Log("moved villan");


            // transform.position = Vector2.MoveTowards(transform.position, Points[0].transform.position, VSpeed*Time.deltaTime);

            if (Rounds < Round_rand)
            {
                if (transform.position.y != Points[i % 2].transform.position.y)
                {
                    // transform.position = Vector2.Lerp(transform.position, Points[i % 2].transform.position, Time.deltaTime);
                    transform.position = Vector2.MoveTowards(transform.position, Points[i % 2].transform.position, VSpeed * Time.deltaTime);

                }
                if (transform.position.y == Points[i % 2].transform.position.y)
                {
                    i++;
                    Rounds++;
                }
            }
            if (Rounds >= Round_rand)
            {
                transform.position = Vector2.MoveTowards(transform.position, Points[randxvalue].transform.position, VSpeed * Time.deltaTime * 8);
                if (transform.position.x == Points[randxvalue].transform.position.x)
                {
                    Round_rand = Random.Range(2, 3);
                    Rounds = 0;
                    randxvalue = Random.Range(1, 4);
                }
            }


            /*
                        while (transform.position.y > Points[1].transform.position.y)
                        {
                            transform.position =  Vector2.MoveTowards(transform.position, Points[1].transform.position, VSpeed * Time.deltaTime);

                        }
                        while (transform.position.y < Points[0].transform.position.y)
                        {
                            transform.position = Vector2.MoveTowards(transform.position, Points[0].transform.position, VSpeed * Time.deltaTime);

                        }

                    */

            /* if (transform.position.y >= 3 || transform.position.y <= -3)
             {
                 Ydirection = Ydirection * (-1);
                 Rounds++;

             }

             if(Rounds>10)

                 VSpeed = 0;
                 HSpeed = 10;
                 if (transform.position.x >= 9 || transform.position.x <= -7)
                 {
                     Xdirection = Xdirection*(-1);
                     loop++;
                 }
                 if(transform.position.x>=9)
                 {
                     loop++;
                 }
                 if(loop>=2)
                 {
                     Rounds = 0;
                 }

             }

             transform.Translate(new Vector3(HSpeed*Time.deltaTime*Xdirection, VSpeed * Time.deltaTime * Ydirection, 0));*/
        }

        if (transform.position.x < Destructionpoint.transform.position.x)
        {
            Destroy(gameObject);
        }

        if (Enemyhp <= 0)
        {

            Enemydeathsound.Play();
            Pmw.EnemiesDestroyed++;

            Debug.Log("entered");
            if (gameObject.tag == "MainEnemy")
            {
                Em.StartCoroutine("EnemySpawner");
            }

            if (gameObject.transform.name == "NormalEnemy(Clone)")
            {
                Debug.Log("entered1");

                scm.score+=2;
            }
            if (gameObject.transform.name == "FollowEnemy(Clone)")
            {
                Debug.Log("entered2");

                scm.score += 3;
            }
            if (gameObject.transform.name == "UpdatedWaveEnemy(Clone)")
            {
                Debug.Log("entered3");

                scm.score += 1;
            }
            if (gameObject.transform.name == "Main Enemy(Clone)")
            {
                Debug.Log("entered4");

                scm.score += 10;
            }
            Destroy(gameObject);


            // scm.score++;

        }
    }  

    void ShootingFunc()
    {
       StartCoroutine( Shooting());
    }

    void ShootingMainEnemyFunc()
    {
        StartCoroutine(ShootingMainEnemy());
    }

    void NormalShootingFunc()
    {
        StartCoroutine(Normalshooting());
    }


    void shoot()
    {
        Instantiate(EnemyBulletPrefab, new Vector2(transform.position.x - 1f, transform.position.y), transform.rotation);

    }

    IEnumerator Shooting()
    {
       // if ((Mb == MovementBehaviour.Normal) && (Mb == MovementBehaviour.Follow))
       
            for (i = 0; i < 100; i++)
            {
                //  float RandomValue = Random.Range(-3, 3);
                Instantiate(EnemyBulletPrefab, new Vector2(transform.position.x - 0.8f, transform.position.y-0.2f), transform.rotation);
                // Enemyprefab.transform.Translate(Vector3.left);
                yield return new WaitForSeconds(0.7f);
                
            }
        
    }

    IEnumerator Normalshooting()
    {
        for (i = 0; i < 100; i++)
        {
            //  float RandomValue = Random.Range(-3, 3);
            Instantiate(EnemyBulletPrefab, new Vector2(transform.position.x - 1.2f, transform.position.y-0.1f), transform.rotation);
            // Enemyprefab.transform.Translate(Vector3.left);
            yield return new WaitForSeconds(1f);

        }
    }

    IEnumerator ShootingMainEnemy()
    {
        // if ((Mb == MovementBehaviour.Normal) && (Mb == MovementBehaviour.Follow))

        for (i = 0; i < 300; i++)
        {
            //  float RandomValue = Random.Range(-3, 3);
            Instantiate(EnemyBulletPrefab, new Vector2(transform.position.x - 2f, transform.position.y-0.5f), transform.rotation);
            // Enemyprefab.transform.Translate(Vector3.left);
            yield return new WaitForSeconds(2f);
        }


    }
    IEnumerator Flicker()
    {

        singleCoroutine = false;
       
        Color clr2 = new Color(clr.r, clr.g, clr.b, .1f);

              Flickeringsound.Play();
            Player.GetComponent<Renderer>().material.color = clr2;
            yield return new WaitForSeconds(0.5f);

             Player.GetComponent<Renderer>().material.color = clr;

           Debug.Log("colour resetted");
        /*  yield return new WaitForSeconds(0.5f);
          Player.GetComponent<Renderer>().material.color = clr2;
          yield return new WaitForSeconds(0.5f);
          Player.GetComponent<Renderer>().material.color = clr;

*/
        singleCoroutine = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player1")
        {

            pm.Playerhealth -= oncollision;

            Debug.Log("collided");
            Flickeringsound.Play();
            // if (singleCoroutine)
            // {
            //  StartCoroutine("Flicker");
            //Player.GetComponent<Renderer>().material.color = clr;

            //   }


            // Destroy(gameObject);
        }
    }
}
