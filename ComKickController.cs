using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ComKickController : MonoBehaviour {
    public AudioClip shootSE;
    public AudioClip powerSE;
    public AudioClip whistleSE;
    AudioSource aud;
    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }
    public GameObject gameobject;
    private int comkicked = 0; //コルーチンが終了するまで、新たなコルーチンを開始させないためのフラグ
    int ratio = 2; //COMが強力力シュートを打つ確率20%
    int ration = 1; //COMが真ん中に強力力シュートを打つ確率10%
    void Start()
    {
        this.aud = GetComponent<AudioSource>();
        this.gameobject = GameObject.Find("GameDirector");
        StartCoroutine("ComShoot");
        this.aud.PlayOneShot(this.whistleSE);
    }
   
	// Update is called once per frame
	void Update () {
      
            
      
    }
    public IEnumerator ComShoot()
    {
        
        yield return new WaitForSeconds(3.4f);
        int dice = Random.Range(1, 11);
        if(dice <= this.ratio) {
            
            float r = Random.Range(-3, 4);
            Shoot(new Vector3(1000, 200 , 200 * r));
            this.aud.PlayOneShot(this.powerSE);
            Rigidbody rb = GetComponent<Rigidbody>();
  //  オブジェクトの Rigidbody の Mass を増加させてゴールを揺らすシュートを打つ
            rb.mass = 2000f;
        } else if (dice == this.ration){
        float y = Random.Range(1, 5);
        Shoot(new Vector3(800, 150 * y, 300));
        this.aud.PlayOneShot(this.powerSE);
        }
        else
        {
            float z = Random.Range(-1, 2);
            Shoot(new Vector3(800, 200, 300 * z));
            this.aud.PlayOneShot(this.shootSE);
        }
        yield return new WaitForSeconds(3.2f);
        if (this.gameobject.GetComponent<GameDirector>().point == 3 && this.gameobject.GetComponent<GameDirector>().lose == 0 
           || this.gameobject.GetComponent<GameDirector>().match == 4 && this.gameobject.GetComponent<GameDirector>().point - this.gameobject.GetComponent<GameDirector>().lose == 2 
           || this.gameobject.GetComponent<GameDirector>().match > 4 && this.gameobject.GetComponent<GameDirector>().lose < this.gameobject.GetComponent<GameDirector>().point)
        {
            SceneManager.LoadScene("WIN");
            yield break;
       } else if (this.gameobject.GetComponent<GameDirector>().point == 0 && this.gameobject.GetComponent<GameDirector>().lose == 3 
            || this.gameobject.GetComponent<GameDirector>().match == 4 && this.gameobject.GetComponent<GameDirector>().lose - this.gameobject.GetComponent<GameDirector>().point == 2
            || this.gameobject.GetComponent<GameDirector>().match > 4 && this.gameobject.GetComponent<GameDirector>().point < this.gameobject.GetComponent<GameDirector>().lose)
        {
            SceneManager.LoadScene("LOSE");
            yield break;
        }
        this.gameobject.GetComponent<GameDirector>().GetShoot();
        SceneManager.LoadScene("pk2");
    }
}

