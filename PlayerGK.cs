using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGK : MonoBehaviour
{
    Animator animator2;
    public void Shoot(Vector3 dir2)
    {
        GetComponent<Rigidbody>().AddForce(dir2);
    }
    private int dived = 0; //コルーチンが終了するまで、新たなコルーチンを開始させないためのフラグ
    // Use this for initialization
    void Start()
    {
        this.animator2 = GetComponent<Animator>();
        //StartCoroutine("Save");
        Invoke("DelayMethod", 3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("right"))
        {
            this.dived = 1;

        }
        else if (Input.GetKeyDown("left"))
        {
            this.dived = 2;
        }
    }
    void DelayMethod()
    {
        if (this.dived == 1)
        {
            Shoot(new Vector3(-10, 2000, -160000));
            this.animator2.SetBool("jump", true);
        }
        else if (this.dived == 2)
        {
            Shoot(new Vector3(-10, 2000, 160000));
            this.animator2.SetBool("jump", true);
        }
        else if (this.dived == 0)
        {
            Shoot(new Vector3(-10, 2000, 1));
            this.animator2.SetBool("jump", true);
        }
    }
}
  //  IEnumerator Save()
   // {
      //  if (Input.GetKeyDown("right"))
     //   {
     //       this.dived = 1;

    //    }
     //   else if (Input.GetKeyDown("left"))
    //    {
    //        this.dived = 2;
    //    }
     //   yield return new WaitForSeconds(3.4f);
      //  StartCoroutine("Saving");
 //   }
 //   IEnumerator Saving()
  //  {
  //      if (this.dived == 1)
    //    {
     //       Shoot(new Vector3(-10, 2000, -160000));
     //   }
     //   else if (this.dived == 2)
      //  {
      //      Shoot(new Vector3(-10, 2000, 160000));
     //   }
     //   else if (this.dived == 0)
      //  {
      //      Shoot(new Vector3(-10, 2000, 1));
      //  }
      //  yield return new WaitForSeconds(0.1f);
     //   this.animator2.SetBool("jump", true);
   // }
    
  //  }


