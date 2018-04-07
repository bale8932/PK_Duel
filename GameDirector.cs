using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    GameObject loseText;
    GameObject pointText;
    GameObject matchText;
    public int point = 0;
    public int match = 1;
    public int lose = 0;
   
    public void GetShoot()
    {
        this.match += 1;
    }
    public void GetScore()
    {
        this.point += 1;
    }
    public void ComScore()
    {
        this.lose += 1;
    }
    // Use this for initialization
    void Start()
    {
        this.pointText = GameObject.Find("Point");
        this.matchText = GameObject.Find("Match");
        this.loseText = GameObject.Find("Lose");
    }

    // Update is called once per frame
    void Update()
    {
        this.pointText.GetComponent<Text>().text =
         "YOU " + this.point.ToString();
        this.loseText.GetComponent<Text>().text =
         "COM " + this.lose.ToString();
        if (this.match > 5)
        {
            this.matchText.GetComponent<Text>().text =
              "サドンデス";
        }　else if (this.match < 6) { 
        this.matchText.GetComponent<Text>().text =
            this.match.ToString() + "本目";}
        if (SceneManager.GetActiveScene().name == "WIN" || SceneManager.GetActiveScene().name == "LOSE")
        {
            this.point = 0;
            this.match = 1;
            this.lose = 0;
        }
}
}