using System.Threading.Tasks.Sources;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public float fadeDuration = 2f; // フェードの期間（秒）
    public float startAlpha = 1f;   // 開始アルファ値
    public float endAlpha = 0f;     // 終了アルファ値

    public Image image;
    private float currentAlpha;
    private float timer;

    public static bool onflag;
    public static bool offflag;
    private Color targetColor1;
    private Color targetColor2;
    private Color originalColor;

    void Start()
    {
        image = GetComponent<Image>();
        currentAlpha = startAlpha;
        //image.color = new Color(image.color.r, image.color.g, image.color.b, currentAlpha);
        originalColor = image.color;
        targetColor1 = new Color(originalColor.r, originalColor.g, originalColor.b, 0.95f); // 終了時のアルファ値を1に設定
        targetColor2 = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
    }

    void Update()
    {
        if(onflag == true)
        {
        timer += Time.deltaTime;

        // フェードの進行度合いを計算
        float progress = timer / fadeDuration;

        // 現在のアルファ値を計算
        float currentAlpha = Mathf.Lerp(originalColor.a, targetColor1.a, progress);

        // 画像の色を更新
        image.color = new Color(originalColor.r, originalColor.g, originalColor.b, currentAlpha);

        // フェードが完了したらタイマーをリセット
        if (progress >= 1.0f)
        {
            onflag = false;
        }
        }

        if(offflag == true)
        {
         // タイマーを更新
        timer += Time.deltaTime;

        // フェードの進行度合いを計算
        float progress = timer / fadeDuration;

        // 現在のアルファ値を計算
        currentAlpha = Mathf.Lerp(startAlpha, targetColor2.a, progress);

        // 画像のアルファ値を更新
        image.color = new Color(image.color.r, image.color.g, image.color.b, currentAlpha);

        // フェードが完了したらタイマーをリセット
        if (progress >= 0.95f)
        {
            //timer = 0f;
            offflag = false;
        }
        }
    }
}
