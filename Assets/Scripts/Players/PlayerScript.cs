using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    private Dictionary<char, KeyCode> keyCodes = new Dictionary<char, KeyCode>();
    private Dictionary<char, int> keyIntegers = new Dictionary<char, int>();

    public Rigidbody2D rb;
    private char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(); // アルファベット配列
    public static int HP = 100;
    [SerializeField] float JumpPower;
    [SerializeField] Slider HPGage;
    private bool jumpflag;
    private float countdown = 2.0f;
    
    [SerializeField] float speed, flashInterval;
    [SerializeField] int loopCount;
    SpriteRenderer sp;
    public CapsuleCollider2D cp2d;
    bool isHit;
    private float Damagecount = 3.0f;

    public float fadeSpeed = 0.5f; // フェードスピード

    public  SpriteRenderer spriteRenderer;
    private bool fading = false;
    private bool fading2 = false;


    void Start()
    {
        AssignKeysAndIntegers();
        LogKeyIntegers();

        HPGage.value = 1;

        sp = GetComponent<SpriteRenderer>();
        cp2d = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void AssignKeysAndIntegers()
    {
        for (int i = 0; i < alphabet.Length; i++)
        {
            char currentKey = alphabet[i];
            // アルファベットキーごとに固定のキーコードを割り当てる
            KeyCode fixedKeyCode = (KeyCode)(KeyCode.A + i);
            // ランダムな整数（0〜26）を割り当てる
            int randomInteger = Random.Range(1, 6);
            // マッピングを追加
            keyCodes.Add(currentKey, fixedKeyCode);
            keyIntegers.Add(currentKey, randomInteger);
        }
    }

    void LogKeyIntegers()
    {
        foreach (var kvp in keyCodes)
        {
            //Debug.Log("Key: " + kvp.Key + ", KeyCode: " + kvp.Value + ", Random Integer: " + keyIntegers[kvp.Key]);
        }
    }

    void Update()
    {
        rb = this.GetComponent<Rigidbody2D>();

        if (HP <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        
        foreach (var kvp in keyCodes)
        {
            if (Input.GetKeyDown(kvp.Value))
            {
                //Debug.Log("Random Integer for Key " + kvp.Key + ": " + keyIntegers[kvp.Key]);
                // Do something with the random integer for this key
                if( keyIntegers[kvp.Key] == 1)
                {
                    Debug.Log("1");
                    One();
                }
                if( keyIntegers[kvp.Key] == 2)
                {
                    Debug.Log("2");
                    Two();
                }
                if( keyIntegers[kvp.Key] == 3)
                {
                    Debug.Log("3");
                    Three();
                }
                if( keyIntegers[kvp.Key] == 4)
                {
                    Debug.Log("4");
                    fading=true;
                    Four();
                }
                if( keyIntegers[kvp.Key] == 5)
                {
                    Debug.Log("5");
                    fading2=true;
                    Five();
                }
                if( keyIntegers[kvp.Key] == 6)
                {
                    Debug.Log("6");
                }
                if( keyIntegers[kvp.Key] == 7)
                {
                    Debug.Log("7");
                }
                if( keyIntegers[kvp.Key] == 8)
                {
                    Debug.Log("8");
                }
                if( keyIntegers[kvp.Key] == 9)
                {
                    Debug.Log("9");
                }
                if( keyIntegers[kvp.Key] == 10)
                {
                    Debug.Log("10");
                }


            }
        }

        if(jumpflag)
        {
            countdown -= Time.deltaTime;
            JumpPower = 0.0f;
        }

        if(countdown <= 0.0f)
        {
            JumpPower = 50.0f;
        }
    }

    void One() //ジャンプ！
    {
        Vector2 jump = new Vector2(0.0f, JumpPower);
        rb.AddForce(jump);
        jumpflag = true;    
    }

    void Two() //スクロール早くなる
    {
        MoveGround.speed = 10.0f;
    }

    void Three() //スクロール遅くなる
    {
       MoveGround.speed = 4f;
    }

    void Four() //暗くなります
    {
       Debug.Log("4");  
       if (fading)
        {
            // 現在の透明度を取得
            Color color = spriteRenderer.color;
            // フェードスピードに応じて透明度を減少させる
            color.a -= fadeSpeed * Time.deltaTime;
            // 透明度が0以下になったら0にクランプする
            color.a = Mathf.Clamp01(color.a);
            // 変更した透明度を反映
            spriteRenderer.color = color;

            // 透明度が完全に0になったらフェードを停止する
            if (color.a <= 0)
            {
                fading = false;
            }
        }
    }

    void Five() //明るくなります
    {
        Debug.Log("5");
        if (fading2)
        {
            // 現在の透明度を取得
            Color color = spriteRenderer.color;
            // フェードスピードに応じて透明度を増加させる
            color.a += fadeSpeed * Time.deltaTime;
            // 透明度が1以上になったら1にクランプする
            color.a = Mathf.Clamp01(color.a);
            // 変更した透明度を反映
            spriteRenderer.color = color;

            // 透明度が完全に1になったらフェードを停止する
            if (color.a >= 1)
            {
                fading = false;
            }
        }
    }

    void Six()
    {
        Debug.Log("6");  
    }

    void Seven()
    {
        Debug.Log("7");
    }

    void Eight()
    {
        Debug.Log("8");
    }

    void Nine()
    {
        Debug.Log("9");
    }

    void Ten()
    {
        Debug.Log("10");
    }




    public void PlayerDamage(int HitDamage)
    {
        HP -= HitDamage;
        HPGage.value = HP * 0.01f;

        if (isHit)
        {
            return;
        }
        
        StartCoroutine(_hit());
        SwitchLayer();
    }

    IEnumerator _hit()
    {
        isHit = true;
        
        for (int i = 0; i < loopCount; i++)
        {
            yield return new WaitForSeconds(flashInterval);
            sp.enabled = false;
            
            yield return new WaitForSeconds(flashInterval);
            sp.enabled = true;
        }

        isHit = false;
    }

    void SwitchLayer()
    {
        BarrierScript.Damage = 0;
        Damagecount -= Time.deltaTime;
        if(Damagecount <= 0)
        {
            BarrierScript.Damage = 10;
            Damagecount = 3.0f;
        }
    }
}
