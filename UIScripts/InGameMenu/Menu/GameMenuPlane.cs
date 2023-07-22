using System.Collections;
using UnityEngine;

public class GameMenuPlane : MonoBehaviour
{
    [SerializeField] private AnimationCurve scaleCurve;
    [Range(0, 1), SerializeField] private float scale;
    private RectTransform rectTransform => this.gameObject.GetComponent<RectTransform>();
    private Vector3 normalScale;
    private void OnEnable()
    {
        Time.timeScale = 0;
        normalScale = rectTransform.localScale;
        rectTransform.localScale = new Vector3(0, 0, 0);
        StartCoroutine(Resize());
    }

    private IEnumerator Resize()
    {
        while (scale < 1)
        {
            scale += 0.03f;
            var a = scaleCurve.Evaluate(scale);
            rectTransform.localScale = new Vector3(a, a, a);
            yield return 0;
        }
        scale = 0;
    }
    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
