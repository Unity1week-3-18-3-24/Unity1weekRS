using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// プレイヤーの操作全般を司る
/// キー設定は全部ランダムになる予定
/// プレイヤーの機能
/// ・ジャンプ
/// ・スニーク
/// ・体力システム
/// </summary>

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private KeyCode randomKeyCode;
    private int HP = 100;//プレイヤーの体力、ゲームオーバーのトリガー
    public BarrierScript BarrierScript;
    [SerializeField] float JumpPower; //ジャンプの高さ
    [SerializeField] Slider HPGage; //HPのスライダー
    // Start is called before the first frame update
    void Start()
    {
        randomKeyCode = (KeyCode)Random.Range((int)KeyCode.A, (int)KeyCode.Z); //ランダムなキーを決定
        Debug.Log(randomKeyCode); //ランダムなキーを表示
        HPGage.value = 1; //スライダーの値を最大にする
    }

    // Update is called once per frame
    void Update()
    {
        rb = this.GetComponent<Rigidbody2D>(); // Rigidbody2D取得
    }
    private void OnCollisionStay2D(Collision2D collision) //接触検知
    {
        //Debug.Log("touch"); //接触！

        if (Input.GetKeyDown(randomKeyCode)) //ランダムなキーが押されたら
        {
            Vector2 jump = new Vector2(0.0f, JumpPower); // ジャンプの大きさ定義
            rb.AddForce(jump); //ジャンプ実行！
        }
    }
    public void PlayerDamage(int HitDamage)
    //引数を障害物から渡してもらって、プレイヤーの体力を減らします
    {
        HP = HP - HitDamage;
        HPGage.value = HP*0.01f; //スライダーの値減らす
    }
}
