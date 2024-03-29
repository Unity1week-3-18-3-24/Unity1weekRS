using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// オブジェクトとかをスクロールさせる
/// inspectorでスピード変更できるようにしてます
/// </summary>

public class MoveGround : MonoBehaviour
{
    //public static float ScrollSpeed = 0.1f; //スクロールの速さ

    public Transform target; // 目的地
    public static float speed = 5.0f; // 移動速度
    public float decelerationDistance = 20.0f; // 減速を開始する距離
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

        if(GameClear.flag == true)
        {
            Stop();
        }
    }
    void Scroll()
    //ScrollSpeedの値を加算して移動させる
    //Update内で実行
    {
        if (target == null)
            return;

        // 目的地への方向ベクトルを計算
        Vector3 direction = target.position - transform.position;
        float distance = direction.magnitude;

        // 移動
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
    }

    void Stop()
    {
        Debug.Log("Stop");
    }
}
