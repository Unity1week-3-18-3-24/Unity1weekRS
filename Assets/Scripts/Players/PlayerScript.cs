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
public class PlayerScript : MonoBehaviour
{
    Dictionary<char, int> keyIntegers = new Dictionary<char, int>();
    private char randomKey;
    //public PlayerController playerController;


    public Rigidbody2D rb;
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
    private float Damagecount = 3.0f;
    void Start()
    {
        AssignRandomIntegers();
        LogKeyIntegers();

         HPGage.value = 1; //スライダーの値を最大にする

        sp = GetComponent<SpriteRenderer>(); //SpriteRenderer格納
        cp2d = GetComponent<CapsuleCollider2D>(); //BoxCollider2D格納
    }

    void AssignRandomIntegers()
    {
        // AからZまでのすべての文字に対して、0から25までのランダムな整数を割り当てます
        for (char c = 'A'; c <= 'Z'; c++)
        {
            int randomInteger = Random.Range(0, 25);
            keyIntegers.Add(c, randomInteger);
        }
    }

    void LogKeyIntegers()
    {
        // すべてのキーとそれに割り当てられた整数をログに表示します
        
    }

    void Update()
    {
        rb = this.GetComponent<Rigidbody2D>(); // Rigidbody2D取得

        if(HP <= 0) //HPが0になったら
        {
            SceneManager.LoadScene("GameOver"); //GameOverシーンに移動
        }
        
        if (Input.anyKeyDown)
        {
            List<char> keys = new List<char>(keyIntegers.Keys);
            randomKey = keys[Random.Range(0, keys.Count)];

            // ランダムなキーに割り当てられた整数が1であればJump_one関数を実行する
            if (keyIntegers[randomKey] == 1)
            {
                Jump_one();
            }
            if (keyIntegers[randomKey] == 2)
            {
                //2つ目の関数
            }
            if (keyIntegers[randomKey] == 3)
            {
                //3つ目の関数
            }
            if (keyIntegers[randomKey] == 4)
            {
                //4つ目の関数
            }
            if (keyIntegers[randomKey] == 5)
            {
                //5つ目の関数
            }
            if (keyIntegers[randomKey] == 6)
            {
                //6つ目の関数
            }
            if (keyIntegers[randomKey] == 7)
            {
                //7つ目の関数
            }
            if (keyIntegers[randomKey] == 8)
            {
                //8つ目の関数
            }
            if (keyIntegers[randomKey] == 9)
            {
                //9つ目の関数
            }
            if (keyIntegers[randomKey] == 10)
            {
                //10つ目の関数
            }
            if (keyIntegers[randomKey] == 11)
            {
                //11つ目の関数
            }
            if (keyIntegers[randomKey] == 12)
            {
                //12つ目の関数
            }
            if (keyIntegers[randomKey] == 13)
            {
                //13つ目の関数
            }
            if (keyIntegers[randomKey] == 14)
            {
                //14つ目の関数
            }
            if (keyIntegers[randomKey] == 15)
            {
                //15つ目の関数
            }
            if (keyIntegers[randomKey] == 16)
            {
                //16つ目の関数
            }
            if (keyIntegers[randomKey] == 17)
            {
                //17つ目の関数
            }
            if (keyIntegers[randomKey] == 18)
            {
                //18つ目の関数
            }
            if (keyIntegers[randomKey] == 19)
            {
                //19つ目の関数
            }
            if (keyIntegers[randomKey] == 20)
            {
                //20つ目の関数
            }
            if (keyIntegers[randomKey] == 21)
            {
                //21つ目の関数
            }
            if (keyIntegers[randomKey] == 22)
            {
                //22つ目の関数
            }
            if (keyIntegers[randomKey] == 23)
            {
                //23つ目の関数
            }
            if (keyIntegers[randomKey] == 24)
            {
                //24つ目の関数
            }
            if (keyIntegers[randomKey] == 25)
            {
                //25つ目の関数
            }
            if (keyIntegers[randomKey] == 26)
            {
                //26つ目の関数
            }
        }

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

    void Jump_one()
    {
        Debug.Log("Jump!");
        Vector2 jump = new Vector2(0.0f, JumpPower); // ジャンプの大きさ定義
        rb.AddForce(jump); //ジャンプ実行！    
        jumpflag = true;    

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
}
