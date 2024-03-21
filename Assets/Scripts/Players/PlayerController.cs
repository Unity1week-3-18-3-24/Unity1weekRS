using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
    public static int HP = 100;//プレイヤーの体力、ゲームオーバーのトリガー
    [SerializeField] float JumpPower; //ジャンプの高さ
    [SerializeField] Slider HPGage; //HPのスライダー
    private bool jumpflag; //ジャンプフラグ

    private float countdown = 2.0f; //ジャンプクールタイム

    
    [SerializeField] float speed,flashInterval; //点滅の間隔
    [SerializeField] int loopCount; //点滅させるときのループカウント
    SpriteRenderer sp; //点滅させるためのSpriteRenderer
    public CapsuleCollider2D cp2d; //コライダーをオンオフするためのCapsleCollider2D
    bool isHit; //当たったかどうかのフラグ

    public float switchInterval = 2f; // レイヤーを切り替える間隔（秒）
    public string[] layerNames; // 使用するレイヤーの名前の配列
    public string newLayerName; //変更するレイヤーの名前
    private float Damagecount = 3.0f;

    void Start()
    {
        randomKeyCode = (KeyCode)Random.Range((int)KeyCode.A, (int)KeyCode.Z); //ランダムなキーを決定
        Debug.Log(randomKeyCode); //ランダムなキーを表示
        HPGage.value = 1; //スライダーの値を最大にする
        
        sp = GetComponent<SpriteRenderer>(); //SpriteRenderer格納
        cp2d = GetComponent<CapsuleCollider2D>(); //BoxCollider2D格納

        if (cp2d == null)
        {
            Debug.LogError("CapsuleCollider2Dが見つかりませんでした!!");
            enabled = false;
            return;
        }

        cp2d.enabled = true; //collider有効
    }
    void Update()
    {
        rb = this.GetComponent<Rigidbody2D>(); // Rigidbody2D取得
        //Debug.Log(HP); //HP表示

        if(HP <= 0) //HPが0になったら
        {
            SceneManager.LoadScene("GameOver"); //GameOverシーンに移動
        }
        if (Input.GetKeyDown(randomKeyCode)) //ランダムなキーが押されたら
        {
            Jump(); //ジャンプします
            countdown = 5.0f;  //カウントダウンリセット
        }

        //Debug.Log(countdown);

        if(jumpflag == true)
        {
            countdown -= Time.deltaTime; //カウントダウン始めるよ〜〜
            JumpPower = 0.0f; //動けないように
        }

        if(countdown <= 0.0f)
        {
            JumpPower = 50.0f; //動けるように
        }
    }
    public void PlayerDamage(int HitDamage)
    //引数を障害物から渡してもらって、プレイヤーの体力を減らします
    {
        HP = HP - HitDamage;
        HPGage.value = HP*0.01f; //スライダーの値減らす

        if (isHit) //Hitしていたら処理を行わない
        {
            return;
        }
        
        StartCoroutine(_hit()); //コルーチンを開始

        SwitchLayer(); // 最初のレイヤーを設定
    }
    IEnumerator _hit() //点滅させる処理
    {
       isHit = true; //当たりフラグをtrueに変更（当たっている状態）
        
        for (int i = 0; i < loopCount; i++) //点滅ループ開始
        {
            yield return new WaitForSeconds(flashInterval); //flashInterval待ってから
            sp.enabled = false; //spriteRendererをオフ
            
            yield return new WaitForSeconds(flashInterval); //flashInterval待ってから
            sp.enabled = true; //spriteRendererをオン
        }

        isHit = false; //点滅ループが抜けたら当たりフラグをfalse(当たってない状態)

    }
    void SwitchLayer()
    {
        //gameObject.layer = LayerMask.NameToLayer("Damage"); //レイヤー変更
        BarrierScript.Damage = 0;
        Damagecount -=Time.deltaTime;
        if(Damagecount <= 0)
        {
            BarrierScript.Damage = 10;
            Damagecount = 3.0f;
        }
        Debug.Log("Layerchange");
    }

    void Jump()
    {
        Debug.Log("Jump!");
        Vector2 jump = new Vector2(0.0f, JumpPower); // ジャンプの大きさ定義
        rb.AddForce(jump); //ジャンプ実行！    
        jumpflag = true;        
    }

}
