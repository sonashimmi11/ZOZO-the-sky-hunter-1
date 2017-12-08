using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{

    public GameObject[] pickups;
    public int Yrand;

    public int pickuprand;

    public Scoremanager sm;

    public int maxscore_powerup = 4;

    public int EnemiesDestroyed;

    public int Rand;

    private Scoremanager scm;

    // Use this for initialization
    void Start()
    {

        EnemiesDestroyed = 0;
        Yrand = Random.Range(-3, 3);
       // StartCoroutine("PickupGeneration");
        pickuprand = Random.Range(0, pickups.Length);

        sm = FindObjectOfType<Scoremanager>();

       // maxscore_powerup = 3;

        Rand = maxscore_powerup;

        scm = FindObjectOfType<Scoremanager>();

        
    }
  //  IEnumerator PickupGeneration()
   // {
       // yield return new WaitForSeconds(10f);

    void Update()
    { 
        if(scm.score >= maxscore_powerup)
        {
            Instantiate(pickups[pickuprand], new Vector2(9, Yrand), transform.rotation);

            pickuprand = Random.Range(0, pickups.Length);

            Yrand = Random.Range(-3, 3);

            maxscore_powerup += Rand ;

          //  yield return new WaitForSeconds(40f);

        }


    }

}
