using DG.Tweening;
using UnityEngine;

public class Key : MonoBehaviour
{

    private void Start()
    {
        transform.DOMoveY(0.5f, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutQuad);
    }
    

}
