using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{
    public AudioClip shootSE;
    public AudioClip powerSE;
    public AudioClip whistleSE;
    AudioSource aud;
    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }
    private int kicked = 0;//コルーチンが終了するまで、新たなコルーチンを開始させないためのフラグ
    private int ctrl = 0;//シュートの方向を変えるためのフラグ
   

    
    void Start()
    {
        this.aud = GetComponent<AudioSource>();
        // Shoot(new Vector3(800, 200, 0));
        this.aud.PlayOneShot(this.whistleSE);
    }

    void Update()
    {    
        if(Input.GetKeyDown("right"))
        {
            this.ctrl = 1;
        }
        if (Input.GetKeyDown("left"))
        {
            this.ctrl = 2;
        }
        if (this.kicked == 0 && this.ctrl == 1 && Input.GetKeyDown("up"))
        {
            StartCoroutine("Right");
        }
        if (this.kicked == 0 && this.ctrl == 2 && Input.GetKeyDown("up"))
        {
            StartCoroutine("Left");
        }
        if (this.kicked == 0 && this.ctrl == 0 && Input.GetKeyDown("up"))
        {
            StartCoroutine("Up");
        }
        if (this.kicked == 0 && this.ctrl == 0 && Input.GetKeyDown("down"))
        {
            StartCoroutine("Down");
        }
        if (this.kicked == 0 && this.ctrl == 1 && Input.GetKeyDown("down"))
        {
            StartCoroutine("PowerRight");
        }
        if (this.kicked == 0 && this.ctrl == 2 && Input.GetKeyDown("down"))
        {
            StartCoroutine("PowerLeft");
        }

    }
    IEnumerator Right()
        {
        this.kicked = 1;
        yield return new WaitForSeconds(1.2f);
            Shoot(new Vector3(800, 200, -300));
        this.aud.PlayOneShot(this.shootSE);

    }
    IEnumerator Left()
    {
        this.kicked = 1;
        yield return new WaitForSeconds(1.2f);
        Shoot(new Vector3(800, 200, 300));
        this.aud.PlayOneShot(this.shootSE);
    }
    IEnumerator Up()
    {
        this.kicked = 1;
        yield return new WaitForSeconds(1.2f);
        Shoot(new Vector3(800, 200, 0));
        this.aud.PlayOneShot(this.shootSE);
    } 
    
    IEnumerator Down()
    {//  外れる可能性があるが、GKが防ぎにくいシュートを放つ
        this.kicked = 1;
        yield return new WaitForSeconds(1.2f);
        float y = Random.Range(1, 5);
        Shoot(new Vector3(1000, 150 * y, 0)); // y=4のときシュートが外れる
        this.aud.PlayOneShot(this.powerSE);
        Rigidbody rb = GetComponent<Rigidbody>();
//  オブジェクトの Rigidbody の Mass をを増加させてゴールを揺らすシュートを打つ
        rb.mass = 2000f;
    }
    IEnumerator PowerRight()
    {//  外れる可能性があるが、GKが防ぎにくいシュートを放つ
        this.kicked = 1;
        yield return new WaitForSeconds(1.2f);
        float z = Random.Range(1, 4);
        Shoot(new Vector3(1100, 200 , -250 * z)); // z=3のときシュートが外れる
        this.aud.PlayOneShot(this.powerSE);
        Rigidbody rb = GetComponent<Rigidbody>();
        //  オブジェクトの Rigidbody の Mass をを増加させて
        rb.mass = 2000f;
    }
    IEnumerator PowerLeft()
    {//  外れる可能性があるが、GKが防ぎにくいシュートを放つ
        this.kicked = 1;
        yield return new WaitForSeconds(1.2f);
        float u = Random.Range(1, 4);
        Shoot(new Vector3(1100, 200, 250 * u)); // y=uのときシュートが外れる
        this.aud.PlayOneShot(this.powerSE);
        Rigidbody rb = GetComponent<Rigidbody>();
       
        rb.mass = 5000f;
    }
}

