using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    public GameObject[] Enemyprefab;

    //public GameObject Enemyprefab2;
    private int i;

    public float speed = -1;

    private float count = 0;

    private bool SmallVillians = true;

    GameObject obj;

    public EnemyBehaviour EB;

    public int MainEnemyFrequency = 10;






    // Use this for initialization
    void Start () {
        StartCoroutine("EnemySpawner");

        EB = FindObjectOfType<EnemyBehaviour>();
	}

    IEnumerator Mainenemyspawner()
    {
        Debug.Log("Came out");


        obj = Instantiate(Enemyprefab[3], new Vector2(9,0), transform.rotation);





     // SmallVillians = false;

        count = 0;

        yield return null;




    }
   public IEnumerator EnemySpawner()
    {
        while (SmallVillians)
        {
            Debug.Log("Entered loop");

            int rand = Random.Range(0, 3);
            switch (rand)
            {
                case 0:
                   StartCoroutine("NormalEnemySpawner");
                    yield return new WaitForSeconds(20.0f);
                    count++;

                    break;
                case 1:
                    StartCoroutine("FollowEnemySpawner");
                    yield return new WaitForSeconds(20.0f);
                    count++;


                    break;
                case 2:
                    StartCoroutine("WaveEnemySpawner");
                    yield return new WaitForSeconds(4.0f);
                    count++;


                    break;

            }
            if (count >= MainEnemyFrequency)
            {
                StartCoroutine("Mainenemyspawner");
                StopCoroutine("EnemySpawner");

                yield return null;
            }
                


        }

        




       

     



    }

    // Update is called once per frame
    void Update () {
        //   StartCoroutine("EnemySpawner");
       
        

       // if(EB.Enemyhp<=0)
       // {
        //    SmallVillians = true;
       // }
    }
  

    IEnumerator NormalEnemySpawner()
    {
       // Debug.Log("Entered Normal enemy loop");

        for (i=0;i<=8;i++)
        {
           
            float RandomValue = Random.Range(-3, 3);
            Instantiate(Enemyprefab[0], new Vector2(8, RandomValue), transform.rotation);
            Enemyprefab[0].transform.Translate(Vector3.left);
            yield return new WaitForSeconds(2f);
        }
      

    }
    IEnumerator FollowEnemySpawner()
    {
       // Debug.Log("Entered follow enemy loop");

        for (i=0;i<=8;i++)
        {
        
            float RandomValue = Random.Range(-3, 3);
            Instantiate(Enemyprefab[1], new Vector2(8, RandomValue), transform.rotation);
            Enemyprefab[1].transform.Translate(Vector3.left);
            yield return new WaitForSeconds(2f);
        }


    }
    IEnumerator WaveEnemySpawner()
    {
        //Debug.Log("Entered Wave enemy loop");

        for (i=0;i<4;i++)
        {

           // float RandomValue = Random.Range(-3, 3);
            Instantiate(Enemyprefab[2], new Vector2(8, 0), transform.rotation);
            Enemyprefab[2].transform.Translate(Vector3.left);
            yield return new WaitForSeconds(0.4f);
        }


    }

   /* IEnumerator MainVillianSpawner()
    {
        Instantiate(Enemyprefab[3], new Vector2(9, 0), transform.rotation);
        if(Enemyprefab[3].transform.position.x >=3)
        {

        }
    }*/
}
