using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        randomKeyCode = (KeyCode)Random.Range((int)KeyCode.A, (int)KeyCode.Z); //?????_?????L?[??????
        Debug.Log(randomKeyCode); //?????_?????L?[?\??
        HPGage.value = 1; //スライダーの値を最大にする
    }

    // Update is called once per frame
    void Update()
    {
        rb = this.GetComponent<Rigidbody2D>(); // Rigidbody2D????   
    }
    private void OnCollisionStay2D(Collision2D collision) //Player???n????????????????
    {
        //Debug.Log("touch"); //????????????

        if (Input.GetKeyDown(randomKeyCode)) //?????????_?????L?[??????????
        {
            Vector2 jump = new Vector2(0.0f, JumpPower); // ?W?????v????????????
            rb.AddForce(jump); // ?W?????v???s
        }
    }
    public void PlayerDamage(int HitDamage)
    //引数を障害物から渡してもらって、プレイヤーの体力を減らします
    {
        HP = HP - HitDamage;
        HPGage.value = HP*0.01f; //スライダーの値減らす
    }
}
