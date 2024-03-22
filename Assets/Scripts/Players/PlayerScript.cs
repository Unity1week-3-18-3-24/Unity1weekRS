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
        AssignRandomKeys();
        AssignAlphabetIndexes();
        LogKeyIntegers();

        HPGage.value = 1;

        sp = GetComponent<SpriteRenderer>();
        cp2d = GetComponent<CapsuleCollider2D>();
    }

    void AssignRandomKeys()
    {
        for (int i = 0; i < alphabet.Length; i++)
        {
            char currentKey = alphabet[i];
            // ランダムなKeyCodeを割り当てる
            KeyCode randomKeyCode = (KeyCode)Random.Range((int)KeyCode.A, (int)KeyCode.Z + 1);
            // マッピングを追加
            keyCodes.Add(currentKey, randomKeyCode);
        }
    }

    void AssignAlphabetIndexes()
    {
        for (int i = 0; i < alphabet.Length; i++)
        {
            char currentKey = alphabet[i];
            // アルファベットのインデックス（0から25までの数値）を割り当てる
            keyIntegers.Add(currentKey, i);
        }
    }

    void LogKeyIntegers()
    {
        foreach (var kvp in keyCodes)
        {
            Debug.Log("Key: " + kvp.Key + ", KeyCode: " + kvp.Value + ", Value: " + keyIntegers[kvp.Key]);
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
                Debug.Log("Random Value for Key " + kvp.Key + ": " + keyIntegers[kvp.Key]);
                // Do something with the random value for this key
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
