using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    public GameObject cubePrefab;
    private float delta = 0; //時間計測用
    private float span = 1.0f; //キューブの生成間隔
    private float genPosX = 12; //キューブの生成位置:x座標
    
    private float offsetY = 0.3f; //キューブの生成位置オフセット
    private float spaceY = 6.9f; //キューブの縦方向の間隔

    private float offsetX = 0.5f; //キューブの生成位置オフセット
    private float spaceX = 0.4f; //キューブの横方向の間隔
    
    private int maxBlockNum = 4; //キューブの生成個数の上限

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;

        if (this.delta > this.span) //span秒以上の時間が経過したら
        {
            this.delta = 0; //時間を測りなおす
            int n = Random.Range (1, maxBlockNum+1); //生成するキューブ数をランダムに決める

            for (int i = 0; i < n; i++) //ランダムで指定された数だけ生成する
            {
                GameObject go = Instantiate (cubePrefab);
                go.transform.position = new Vector2 (this.genPosX, this.offsetY + i * this.spaceY);
            }
            this.span = this.offsetX + this.spaceX * n; //次のキューブまでの生成時間を決める
        }
    }
}
