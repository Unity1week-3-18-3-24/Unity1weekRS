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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }
    void Scroll()
    //ScrollSpeedの値を加算して移動させる
    //Update内で実行
    {
        Transform myTransform = this.transform;
        myTransform.Translate(-ScrollSpeed,0,0,Space.World);
    }
}
