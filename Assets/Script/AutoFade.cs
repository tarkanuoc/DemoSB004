using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AutoFade : MonoBehaviour
{
    [SerializeField] private CanvasGroup group;
    public float showDuration;
    public float hideDuration;

    public void Show()
    {
        
        gameObject.SetActive(true);
                
        
        group.DOFade(1f, 1f).OnComplete(() =>
        {
            DOVirtual.DelayedCall(showDuration, () =>
            {
                Hide();
            });
        });
    }

    public void Hide()
    {
        group.DOFade(0, 1f).OnComplete(() => {
            gameObject.SetActive(false);
        });
    }
}
