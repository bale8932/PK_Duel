using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GKController : MonoBehaviour {
    Animator animator2;
    public GameObject gameobject2;
  
    public void Shoot(Vector3 dir2)
    {
        GetComponent<Rigidbody>().AddForce(dir2);
    }
    private int jumped = 0; //コルーチンが終了するまで、新たなコルーチンを開始させないためのフラグ
    // Use this for initialization
    void Start () {
        this.animator2 = GetComponent<Animator>();
        this.gameobject2 = GameObject.Find("GameDirector");
       
    }
	
	// Update is called once per frame
	void Update () {
        if (this.jumped == 0 && (Input.GetKeyDown("up") || Input.GetKeyDown("down")))
        {
            StartCoroutine("Goal");
        }
 }
    private IEnumerator Goal()
        {
        this.jumped = 1;
        yield return new WaitForSeconds(1.2f);
            float z = Random.Range(-1, 2);
            Shoot(new Vector3(-10, 2000, 160000*z));
            this.animator2.SetBool("jump", true);
        yield return new WaitForSeconds(3.2f);
 if (this.gameobject2.GetComponent<GameDirector>().match == 4 && this.gameobject2.GetComponent<GameDirector>().point - this.gameobject2.GetComponent<GameDirector>().lose == 3
 || this.gameobject2.GetComponent<GameDirector>().match == 5 && this.gameobject2.GetComponent<GameDirector>().point - this.gameobject2.GetComponent<GameDirector>().lose == 2)
        {
            SceneManager.LoadScene("WIN");
            yield break;
        }
        else if (this.gameobject2.GetComponent<GameDirector>().match == 4 && this.gameobject2.GetComponent<GameDirector>().lose - this.gameobject2.GetComponent<GameDirector>().point == 2
           || this.gameobject2.GetComponent<GameDirector>().match == 5 && this.gameobject2.GetComponent<GameDirector>().lose - this.gameobject2.GetComponent<GameDirector>().point == 1
         )
        { 
            SceneManager.LoadScene("LOSE");
            yield break;
        }
        SceneManager.LoadScene("pk3");
    }
}
