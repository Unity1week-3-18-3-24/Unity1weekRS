using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private KeyCode randomKeyCode;
    // Start is called before the first frame update
    void Start()
    {
        randomKeyCode = (KeyCode)Random.Range((int)KeyCode.A, (int)KeyCode.Z); //ランダムなキーを設定
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(randomKeyCode); //ランダムなキー表示

        rb = this.GetComponent<Rigidbody2D>(); // Rigidbody2D取得

        Transform myTransform = this.transform; //transformを取得
        myTransform.Translate(0.05f, 0.0f, 0.0f, Space.World); //現在の座標からのX座標を1ずつ加算して移動
    }
    private void OnCollisionStay2D(Collision2D collision) //Playerが地面についていたら
    {
        Debug.Log("touch"); //当たった判定

        if (Input.GetKeyDown(randomKeyCode)) //もしランダムなキーを押したら
        {
            Vector3 jump = new Vector2(0.0f, 30.0f); // ジャンプの大きさ設定
            rb.AddForce(jump); // ジャンプ実行
        }
    }
}
