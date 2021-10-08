using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    Animator animator; //アニメーションするためのコンポーネントを入れる
    Rigidbody2D rigid2D; //Unityちゃんを移動させるコンポーネントを入れる

    private float groundLevel = -3.0f; //地面の位置
    private float dump = 0.8f; //ジャンプ速度の減衰
    float jumpVelocity = 20; //ジャンプ速度
    private float deadLine = -9; //ゲームオーバーになる位置

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator> ();
        this.rigid2D = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        //走るアニメーションを再生するために、Animatorのパラメータを調節する
        this.animator.SetFloat("Horizontal", 1); 
        //着地しているかどうか調べる
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool ("isGround", isGround);
        //ジャンプ中はボリュームを0にする
        GetComponent<AudioSource> ().volume = (isGround) ? 1 : 0;

        //着地状態でクリックされたとき
        if (Input.GetMouseButtonDown (0) && isGround)
        {
            this.rigid2D.velocity = new Vector2 (0, this.jumpVelocity);
        }
     　　//クリックをやめたら上方向への速度を減速する
        if (Input.GetMouseButton (0) == false)
        {
            if (this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }

        if (transform.position.x < this.deadLine)
        {
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();
            Destroy (gameObject); 
        }
    }
}
