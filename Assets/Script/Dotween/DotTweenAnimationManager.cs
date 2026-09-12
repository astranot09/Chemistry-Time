using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;


public enum TypeAnimation
{
    None,
    Scaling
}

public class DotTweenAnimationManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TypeAnimation typeAnimation;
    private bool onActived;
    [SerializeField] private bool playOnLooping;

    [Header("Setting")]
    [SerializeField] private float scaleValue = 1.2f;
    [SerializeField] private float durationValue = 0.2f;


    private void Start()
    {
        if (playOnLooping)
        {
            PlayAnimationLooping();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(playOnLooping) return;
        onActived = true;
        PlayAnimation();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (playOnLooping) return;
        onActived = false;
        PlayAnimation();
    }


    private void PlayAnimation()
    {
        if (onActived)
        {
            switch (typeAnimation)
            {
                case TypeAnimation.Scaling:
                    this.transform.DOScale(scaleValue, durationValue);
                    break;
            }
        }
        else
        {
            switch (typeAnimation)
            {
                case TypeAnimation.Scaling:
                    this.transform.DOScale(1, durationValue);
                    break;
            }
        }
    }
    private void PlayAnimationLooping()
    {
        switch (typeAnimation)
        {
            case TypeAnimation.Scaling:
                Sequence s = DOTween.Sequence();
                s.Append(transform.DOScale(scaleValue, durationValue))
                 .Append(transform.DOScale(1f, durationValue))
                 .SetLoops(-1, LoopType.Yoyo) // -1 artinya loop tanpa batas
                 .SetUpdate(true);
                break;
        }
    }
}
