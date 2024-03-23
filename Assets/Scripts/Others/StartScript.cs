using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class StartScript : MonoBehaviour
{
    public Text countdownText; //3,2,1,GO!!のテキスト
    public float countdownTime = 3f; //何秒からカウントダウンするかの定義
    private float timer = 0f; //時間
    private bool isCounting = true; //カウントダウンしてる？のbool

    public static bool start = false; //MoveObjectスクリプトに送って判定してます

    public float hideDelay = 2f; //非表示にするまでの時間

    public GameObject text; //text非表示にするために使ってます

    public static float gametime;
    public Text gametimetext;

    public static bool timeflag;
    void Start()
    {
        timer = countdownTime; //ゲームを開始する前のカウントダウンを開始する
    }

    void Update()
    {
        if (isCounting)
        {
            timer -= Time.deltaTime;
            countdownText.text = Mathf.CeilToInt(timer).ToString(); //UI上のテキストを更新する

            if (timer <= 0)
            {
                isCounting = false; //カウントダウンが終了したら停止する
                StartGame(); //ゲームを開始する処理を実行する
            }
        }
        if(timeflag == true)
        {
            gametime += Time.deltaTime;
        }
        gametimetext.text = gametime.ToString("F2");
    }

    void StartGame()
    {
        Debug.Log("ゲームが開始されました！");
        countdownText.text = "GO!!"; //ゲーム開始！
        start = true; //地面も動くよ

        Invoke("HideObject", hideDelay); //hideDelay秒後にテキスト見えなくなる
        timeflag = true;
    }

    private void HideObject()
    {
       text.SetActive(false); //オブジェクトを非表示にする
    }
}
