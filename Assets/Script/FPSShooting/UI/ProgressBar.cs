using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private RectTransform rectProgressBar;
    [SerializeField] private RectTransform rectMask;
    [SerializeField] private RectTransform rectProgressImage;

    private float maxWidth;
    private float maxHeight;

    private void Awake()
    {
        maxWidth = rectMask.rect.width;
        maxHeight = rectMask.rect.height;
    }

    public void SetProgressValue(float progress)
    {
        //Debug.Log("========= loadig progress = " + progress);
        float currentWidth = Mathf.Clamp01(progress) * maxWidth;
        rectMask.sizeDelta = new Vector2(currentWidth, maxHeight);
    }
}
