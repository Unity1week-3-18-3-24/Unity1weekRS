using System.Threading.Tasks.Sources;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{public float fadeDuration = 2f; // フェードの期間（秒）
    public float startAlpha = 1f;   // 開始アルファ値
    public float endAlpha = 0f;     // 終了アルファ値

    public Image image;
    private float currentAlpha;
    private float timer;

    public static bool onflag;
    public static bool offflag;


    void Start()
    {
        image = GetComponent<Image>();
        currentAlpha = startAlpha;
        image.color = new Color(image.color.r, image.color.g, image.color.b, currentAlpha);
    }

    void Update()
    {
        if(onflag == true)
        {
            // タイマーを更新
        timer += Time.deltaTime;

        // フェードの進行度合いを計算
        float progress = timer / fadeDuration;

        // 現在のアルファ値を計算
        currentAlpha = Mathf.Lerp(startAlpha, endAlpha, progress);

        // 画像のアルファ値を更新
        image.color = new Color(image.color.r, image.color.g, image.color.b, currentAlpha);

        // フェードが完了したらタイマーをリセット
        if (progress >= 1f)
        {
            timer = 0f;
        }
        }
    }
}
