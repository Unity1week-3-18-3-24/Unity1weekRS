using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵のダメージ処理用のスクリプト
/// Damageはinspectorで変えられるようにしてあります
/// </summary>
public class BarrierScript : MonoBehaviour
{
    public static int Damage = 20; //Playerに与えるダメージ
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnCollisionEnter2D(Collision2D col)
    //PlayerのDamege関数を実行させる
    {
        //if(col.gameObject.GetComponent<PlayerController>())
        //当たったオブジェクトがPlayerControllerのコンポーネントがあった時に実行
        //ダメージ与えたら消えます
            if(col.gameObject.tag == "Player")
            {
                col.gameObject.GetComponent<PlayerScript>().PlayerDamage(Damage); //引数にDamageを入れてPlayerDamageを実行
                //Debug.Log("atatta");
                Destroy(this.gameObject);
            }
    }
}
