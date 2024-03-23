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
            int randomInteger = Random.Range(1, 26);
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
                }
                if( keyIntegers[kvp.Key] == 5)
                {
                    Debug.Log("5");
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
                if( keyIntegers[kvp.Key] == 11)
                {
                    Debug.Log("11");
                }
                if( keyIntegers[kvp.Key] == 12)
                {
                    Debug.Log("12");
                }
                if( keyIntegers[kvp.Key] == 13)
                {
                    Debug.Log("13");
                }
                if( keyIntegers[kvp.Key] == 14)
                {
                    Debug.Log("14");
                }
                if( keyIntegers[kvp.Key] == 15)
                {
                    Debug.Log("15");
                }
                if( keyIntegers[kvp.Key] == 16)
                {
                    Debug.Log("16");
                }
                if( keyIntegers[kvp.Key] == 17)
                {
                    Debug.Log("17");
                }
                if( keyIntegers[kvp.Key] == 18)
                {
                    Debug.Log("18");
                }
                if( keyIntegers[kvp.Key] == 19)
                {
                    Debug.Log("19");
                }
                if( keyIntegers[kvp.Key] == 20)
                {
                    Debug.Log("20");
                }
                if( keyIntegers[kvp.Key] == 21)
                {
                    Debug.Log("21");
                }
                if( keyIntegers[kvp.Key] == 22)
                {
                    Debug.Log("22");
                }
                if( keyIntegers[kvp.Key] == 23)
                {
                    Debug.Log("23");
                }
                if( keyIntegers[kvp.Key] == 24)
                {
                    Debug.Log("24");
                }
                if( keyIntegers[kvp.Key] == 25)
                {
                    Debug.Log("25");
                }
                if( keyIntegers[kvp.Key] == 26)
                {
                    Debug.Log("26");
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
       MoveGround.speed = 2.5f;
    }

    void Four()
    {
       Debug.Log("4");  
    }

    void Five()
    {
        Debug.Log("5");
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
