using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵のダメージ処理用のスクリプト
/// Damageはinspectorで変えられるようにしてあります
/// </summary>
public class BarrierScript : MonoBehaviour
{
    public static int Damage; //Playerに与えるダメージ
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
        if(col.gameObject.GetComponent<PlayerController>())
        //当たったオブジェクトがPlayerControllerのコンポーネントがあった時に実行
        //ダメージ与えたら消えます
        {
            col.gameObject.GetComponent<PlayerController>().PlayerDamage(Damage); //引数にDamageを入れてPlayerDamageを実行
            Debug.Log("atatta");
            this.gameObject.SetActive (false); //擬似的Destroy
            //Destroy(this.gameObject);
        }
    }
}
