using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StageFader : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private AnimationCurve curve;
    private void OnEnable()
    {
        Time.timeScale = 1;
        StartCoroutine(FadeIn());
    }
    private IEnumerator FadeOut(string sceneName)
    {
        Time.timeScale = 1;
        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime;
            var a = curve.Evaluate(t);
            fadeImage.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator FadeIn()
    {
        var t = 1f;
        while (t > 0)
        {
            t -= Time.deltaTime;
            var a = curve.Evaluate(t);
            fadeImage.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
    }

    public void LoadStage(string nameOfScene)
    {
        StartCoroutine(FadeOut(nameOfScene));
    }
}
