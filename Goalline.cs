using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goalline : MonoBehaviour {
    GameObject director;
    void Start()
    {
        this.director = GameObject.Find("GameDirector");
    }

    void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "Ball")
        {
            this.director.GetComponent<GameDirector>().GetScore();
            Debug.Log("Goal");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
