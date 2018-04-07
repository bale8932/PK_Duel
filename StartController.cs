using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour {

	
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            //Destroy(GetComponent<CGameMan>());
            //return;
            SceneManager.LoadScene("PK2");
        }
	}
}
