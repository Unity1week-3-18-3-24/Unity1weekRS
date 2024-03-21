using UnityEngine;

public class FallDamage : MonoBehaviour
{
    public float fallHeightThreshold = 5f; // 落下ダメージを与える高さの閾値
    public float damageMultiplier = 1f; // ダメージの倍率
    public int baseDamage = 10; // ベースダメージ

    private float lastYPos; // 前フレームのY座標
    private bool isFalling; // 落下中かどうか

    private bool onetime;

    void Start()
    {
        lastYPos = transform.position.y;
    }

    void Update()
    {
        float currentYPos = transform.position.y;

        // 落下中でない場合、現在のY座標を前フレームのY座標として更新し、落下状態をfalseに設定
        if (currentYPos >= lastYPos)
        {
            isFalling = false;
            lastYPos = currentYPos;
            return;
        }

        // 落下中の場合、前フレームのY座標を現在のY座標として更新し、落下状態をtrueに設定
        isFalling = true;
        lastYPos = currentYPos;
        //Debug.Log(isFalling);

        if(isFalling == true)
        {
            BarrierScript.Damage = Mathf.RoundToInt(baseDamage + (transform.position.y - lastYPos) * damageMultiplier);
            //Debug.Log("Fall damage: " + BarrierScript.Damage);
            //Invoke("DownDamage", 0f); // 0秒後に関数を呼び出す
        }
    }
    void DownDamage()
    {
        PlayerController.HP -= BarrierScript.Damage;
    }
}
