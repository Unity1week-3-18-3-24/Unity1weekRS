using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// オブジェクトとかをスクロールさせる
/// inspectorでスピード変更できるようにしてます
/// </summary>

public class MoveGround : MonoBehaviour
{
    [SerializeField] float ScrollSpeed; //スクロールの速さ

    public Transform target; // 目的地
    public float speed = 5.0f; // 移動速度
    public float decelerationDistance = 1.0f; // 減速を開始する距離
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(StartScript.start == true) //StartScriptから信号がきたら
        {
            Scroll(); //動きます
        }
    }
    void Scroll()
    //ScrollSpeedの値を加算して移動させる
    //Update内で実行
    {
        // Transform myTransform = this.transform;
        // myTransform.Translate(-ScrollSpeed,0,0,Space.World);


        if (target == null)
            return;

        // 目的地への方向ベクトルを計算
        Vector3 direction = target.position - transform.position;
        float distance = direction.magnitude;

        // 目的地に到達した場合、移動を停止
        if (distance <= 0.1f)
        {
            // もしくは、任意の処理を追加する
            return;
        }

        // 減速を開始する距離に達したら減速を開始
        if (distance <= decelerationDistance)
        {
            // 減速
            float decelerationFactor = distance / decelerationDistance;
            speed *= decelerationFactor;
        }

        // 移動
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
    }
}
