using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goalline2 : MonoBehaviour {

    GameObject director2;
    void Start()
    {
        this.director2 = GameObject.Find("GameDirector");
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Ball")
        {
            this.director2.GetComponent<GameDirector>().ComScore();
            Debug.Log("Goal");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}