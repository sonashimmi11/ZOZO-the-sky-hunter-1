using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsMovement : MonoBehaviour {

    public float speed = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
         transform.Translate(new Vector2(-Time.deltaTime * speed, 0));
       // Vector2 offset = new Vector2(Time.deltaTime * speed, 0);

        //transform.position += transform.position +  Vector2(Time.deltaTime * speed, 0);
    }
}
