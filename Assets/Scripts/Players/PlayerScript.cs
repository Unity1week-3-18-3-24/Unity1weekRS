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
    private float Damagecount = 1.0f;

    public float fadeSpeed = 0.5f; // フェードスピード

    private bool damageflag;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;

    public float fadeDuration = 1f; // フェードの期間（秒）
    public float startAlpha = 1f;   // 開始アルファ値
    public float endAlpha = 0f;     // 終了アルファ値


    void Start()
    {
        AssignKeysAndIntegers();
        LogKeyIntegers();

        HPGage.value = 1;

        sp = GetComponent<SpriteRenderer>();
        cp2d = GetComponent<CapsuleCollider2D>();
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
                    Four();
                }
                if( keyIntegers[kvp.Key] == 5)
                {
                    Debug.Log("5");
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

        if(damageflag == true)
        {
            //BarrierScript.Damage = 40;
            Damagecount -= Time.deltaTime;
        }
        if(Damagecount <= 0)
        {
            BarrierScript.Damage = 20;
            damageflag = false;
            Damagecount = 1.0f;
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
       //Debug.Log(test.onflag);
       test.onflag = true;
    }

    void Five() //明るくなります
    {
        Debug.Log("5");
        test.offflag = true;
    }

    void Six() //敵全部消えます
    {
        Debug.Log("6");  
        enemy1.SetActive(false);
        enemy2.SetActive(false);
        enemy3.SetActive(false);
        enemy4.SetActive(false);
        enemy5.SetActive(false);
    }

    void Seven() //敵戻ります
    {
        Debug.Log("7");
        enemy1.SetActive(true);
        enemy2.SetActive(true);
        enemy3.SetActive(true);
        enemy4.SetActive(true);
        enemy5.SetActive(true);
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
        Debug.Log(BarrierScript.Damage);
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
            //BarrierScript.Damage = 0;
        }

        isHit = false;
        
    }

    void SwitchLayer()
    {
        damageflag = true;
    }
}
