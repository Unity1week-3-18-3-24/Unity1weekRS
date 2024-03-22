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
            int randomInteger = Random.Range(0, 27);
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
                    Jump_one();
                }
                if( keyIntegers[kvp.Key] == 2)
                {
                    Debug.Log("2");
                }
                if( keyIntegers[kvp.Key] == 3)
                {
                    Debug.Log("3");
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

    void Jump_one()
    {
        Vector2 jump = new Vector2(0.0f, JumpPower);
        rb.AddForce(jump);
        jumpflag = true;    
    }

    void Jump_two()
    {
        Debug.Log("2");  
    }

    void Jump_three()
    {
        Debug.Log("3");    
    }

    void Jump_four()
    {
       Debug.Log("4");  
    }

    void Jump_five()
    {
        Debug.Log("5");
    }

    void Jump_six()
    {
        Debug.Log("6");  
    }

    void Jump_seven()
    {
        Debug.Log("7");
    }

    void Jump_eight()
    {
        Debug.Log("8");
    }

    void Jump_nine()
    {
        Debug.Log("9");
    }

    void Jump_ten()
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
