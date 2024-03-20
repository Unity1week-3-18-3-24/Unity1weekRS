using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JudgeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Clear") //クリアタグに当たったら
        {
            SceneManager.LoadScene("GameClear"); //クリアシーンに移動
        }

        if (collision.tag == "Over") //オーバーシーンに移動
        {
            SceneManager.LoadScene("GameOver"); //オーバータグに当たったら
        }
    }
}
