using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGameMan : MonoBehaviour
{
    // このオブジェクトを読み込み時に破壊させない
    void Awake()
    {
        // 1つより多かったらすでに追加済みなので、このGameManは削除する
        if (GameObject.FindGameObjectsWithTag("GameController").Length > 1)
        {
            Destroy(gameObject);
            return;
        }
            // 永続化
            DontDestroyOnLoad(this);
    }
    // Use this for initialization
    void Start()
    {


    }


    // Update is called once per frame
    void Update()
    {

    }
}
