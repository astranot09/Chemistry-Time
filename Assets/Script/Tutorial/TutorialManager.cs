using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class TutorialManager : MonoBehaviour
{
    public static TutorialManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    [Header("Data")]
    [SerializeField] private TutorialSO tutorialSO;

    [Header("UI")]
    [SerializeField] private GameObject tutorialPanel;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject prevButton;

    [SerializeField] private Image tutorialImage;
    [SerializeField] private TMP_Text tutorialName;
    [SerializeField] private TMP_Text tutorialDescription;

    [Header("Animation")]
    [SerializeField] private Transform panelTransform;
    [SerializeField] private float sizeUpValue = 2f;
    [SerializeField] private float animationDuration = 2f;

    private int indexTutorial = 0;
    private int maximumIndexTutorial = 0;

    public void SetUpTutorialData(TutorialSO data)
    {
        tutorialSO = data;
        indexTutorial = 0;
        maximumIndexTutorial = tutorialSO.tutorials.Count;
        tutorialPanel.SetActive(true);
        AnimationPanelSizeUp();
        SetUpUITutorial();
    }

    public void SetUpUITutorial()
    {
        Mathf.Clamp(indexTutorial, 0, maximumIndexTutorial);
        tutorialImage.sprite = tutorialSO.tutorials[indexTutorial].tutorialImage;
        tutorialName.text = tutorialSO.tutorials[indexTutorial].tutorialName.ToString();
        tutorialDescription.text = tutorialSO.tutorials[indexTutorial].tutorialDescription.ToString();

        nextButton.SetActive(true);
        prevButton.SetActive(true);

        if (indexTutorial >= maximumIndexTutorial-1)
        {
            nextButton.SetActive(false);
        }
        if(indexTutorial <= 0)
        {
            prevButton.SetActive(false);
        }
    }

    public void NextPageTutorial()
    {
        indexTutorial++;
        SetUpUITutorial();
    }
    public void PreviousPageTutorial()
    {
        indexTutorial--;
        SetUpUITutorial();
    }

    public void CloseTutorial()
    {
        indexTutorial = 0;
        tutorialSO = null;
        AnimationPanelClose();
    }


    private void AnimationPanelSizeUp()
    {

        panelTransform.localScale = Vector3.zero;

        Sequence popSequence = DOTween.Sequence();

        popSequence.Append(panelTransform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), animationDuration).SetEase(Ease.OutQuad))
                          .Append(panelTransform.DOScale(Vector3.one, animationDuration * 0.5f).SetEase(Ease.InOutQuad))
                          .SetUpdate(true);
    }


    private void AnimationPanelClose()
    {
        panelTransform.DOKill();

        Sequence closeSequence = DOTween.Sequence();
        closeSequence.Append(panelTransform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), animationDuration * 0.4f).SetEase(Ease.OutQuad))
                     .Append(panelTransform.DOScale(Vector3.zero, animationDuration).SetEase(Ease.InBack)).OnComplete(() => tutorialPanel.SetActive(false));
    }

}
