using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCleaner : MonoBehaviour
{
    //メインカメラのオブジェクト
    private GameObject MainCamera;

    // Start is called before the first frame update
    void Start()
    {
        //メインカメラのオブジェクトを取得
        this.MainCamera = GameObject.Find("Main Camera");
       
    }

    // Update is called once per frame
    void Update()
    {
        //オブジェクトのZ軸とメインカメラのZ軸を比較
        if (this.gameObject.transform.position.z <= MainCamera.transform.position.z)
        {
            //メインカメラからはみ出したオブジェクトを破棄
            Destroy(this.gameObject);
        }
    }
}
