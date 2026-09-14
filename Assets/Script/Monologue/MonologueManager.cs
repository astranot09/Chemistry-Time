using UnityEngine;
using TMPro;
using DG.Tweening;
public class MonologueManager : MonoBehaviour
{

    public static MonologueManager instance;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }


    [Header("Data")]
    [SerializeField] private MonologueSO monologueData;

    [Header("UI")]
    [SerializeField] private GameObject monologuePanel;
    [SerializeField] private TMP_Text monologueText;


    [Header("Animation")]
    [SerializeField] private float duration = 0.4f;

    [Header("Reference")]
    [SerializeField] private TypeWriterEffect typeWriterEffect;

    public void PlayMonologue(MonologueSO monologue)
    {
        if (monologue == null) return;

        monologueData = monologue;
        monologueText.text = string.Empty;
        monologuePanel.SetActive(true);
        monologuePanel.transform.localScale = Vector3.zero;

        OpenAnimation();
    }

    public void CloseMonologue()
    {
        CloseAnimation();
    }

    private void OpenAnimation()
    {
        monologuePanel.transform.DOKill();

        Sequence s = DOTween.Sequence();

        s.Append(monologuePanel.transform.DOScale(1f, duration).SetEase(Ease.OutQuad))
         //.Append(monologuePanel.transform.DOScaleY(1f, duration/2).SetEase(Ease.OutQuad))
         .OnComplete(() =>
         {
             if (typeWriterEffect != null && monologueData != null)
             {
                 typeWriterEffect.Run(monologueData.monologueText, monologueText);
             }
         })
         .SetUpdate(true);
    }

    private void CloseAnimation()
    {
        monologuePanel.transform.DOKill();

        Sequence s = DOTween.Sequence();

        s.Append(monologuePanel.transform.DOScale(0f, duration).SetEase(Ease.InQuad))
         .OnComplete(() =>
         {
             monologueData = null;
             monologuePanel.SetActive(false);
         })
         .SetUpdate(true);
    }
}
