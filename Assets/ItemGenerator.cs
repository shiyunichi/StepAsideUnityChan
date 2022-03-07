using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //conePrefabを入れる
    public GameObject conePrefab;
    //スタート地点
    private int startPos = 80;
    //ゴール地点
    private int goalPos = 360;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;
    //Unitychanの座標を入れる
    private GameObject unityChan;
    //untyChanPosZを初期化
    private float unityChanPosZ = 0.0f;
    //　generatPosを初期化
    private float generatPos = 0.0f;
    //itemPosを初期化
    private float itemPos = 0.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        //unitychanのオブジェクトを取得
        unityChan = GameObject.Find("unitychan");

        //生成ポイントを80にセット
        generatPos = 80.0f;

    }

    // Update is called once per frame
    void Update()
    {
        //ユニティちゃんの座表を取得
        unityChanPosZ = unityChan.transform.position.z;

        if (generatPos >= startPos && generatPos < goalPos)
        {
            
            if (generatPos >= unityChanPosZ + 40.0f)
            {

                    //どのアイテムを出すのかをランダムに設定
                    int num = Random.Range(1, 11);
                    if (num <= 2)
                    {
                        //コーンをx軸方向に一直線に生成
                        for (float j = -1; j <= 1; j += 0.4f)
                        {
                            GameObject cone = Instantiate(conePrefab);
                            cone.transform.position = new Vector3(4 * j, cone.transform.position.y, generatPos);
                        }
                    }
                    else
                    {
                        //レーンごとにアイテムを生成
                        for (int j = -1; j <= 1; j++)
                        {
                            //アイテムの種類を決める
                            int item = Random.Range(1, 11);
                            int offsetZ = Random.Range(-5, 6);
                            if (1 <= item && item <= 6)
                            {

                                //コインを生成
                                GameObject coin = Instantiate(coinPrefab);
                                coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, generatPos + offsetZ);
                            }
                            else if (7 <= item && item <= 9)
                            {

                                //車を生成
                                GameObject car = Instantiate(carPrefab);
                                car.transform.position = new Vector3(posRange * j, car.transform.position.y, generatPos + offsetZ);

                            }
                        }
                    }

                //生成ポイントを15間隔にする
                generatPos += 15;
            }

        }

    }

   
}
