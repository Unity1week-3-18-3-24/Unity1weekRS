using UnityEngine;
using UnityEngine.UI;

public class StartScript : MonoBehaviour
{
    public Text countdownText;
    public float countdownTime = 3f;
    private float timer = 0f;
    private bool isCounting = true;

    void Start()
    {
        // ゲームを開始する前のカウントダウンを開始する
        timer = countdownTime;
    }

    void Update()
    {
        if (isCounting)
        {
            timer -= Time.deltaTime;

            // UI上のテキストを更新する
            countdownText.text = Mathf.CeilToInt(timer).ToString();

            if (timer <= 0)
            {
                // カウントダウンが終了したら停止する
                isCounting = false;

                // ゲームを開始する処理を実行する
                StartGame();
            }
        }
    }

    void StartGame()
    {
        Debug.Log("ゲームが開始されました！");
        // ここにゲームの開始処理を記述する
    }

    public void PauseGame()
    {
        // ゲームの時間を一時停止する
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        // ゲームの時間を再開する
        Time.timeScale = 1f;
    }
}
