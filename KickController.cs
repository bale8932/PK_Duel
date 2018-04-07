using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KickController : MonoBehaviour
{

    Animator animator;
    // Use this for initialization
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "pk3")
        {
            StartCoroutine("COMKick");

        }
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "pk2" && (Input.GetKeyDown("up") || Input.GetKeyDown("down")))
        {
            this.animator.SetBool("is_jumping", true);
        }

    }
    private IEnumerator COMKick()
    {
        this.animator = GetComponent<Animator>();
        yield return new WaitForSeconds(2.2f);
        this.animator.SetBool("is_jumping", true);
    }
}
