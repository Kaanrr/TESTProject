using DG.Tweening;
using UnityEngine;

public class PlayerHitUI : MonoBehaviour
{
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }
    public void Show()
    {
        gameObject.SetActive(true);
        _canvasGroup.DOKill();
        _canvasGroup.DOFade(1, .2f).OnComplete(()=>Hide(.1f));
    }
    public void Hide(float delay)
    {
        _canvasGroup.DOKill();
        _canvasGroup.DOFade(0, .2f).SetDelay(delay).OnComplete(() => gameObject.SetActive(false));
    }

    public void PopPlayerHitUI()
    {
        Show();
        
    }

}
