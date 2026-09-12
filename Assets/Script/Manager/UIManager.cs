using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    [Header("Main Menu")]
    [SerializeField] private TutorialSO tutorialData;
    [SerializeField] private GameObject tutorialPanel;


    [Header("In Game")]
    [SerializeField] private GameObject kamusPanel;
    [SerializeField] private GameObject weaponPanel;

    [SerializeField] private GameObject deadPanel;

    public void ClickKamus()
    {
        kamusPanel.SetActive(!kamusPanel.activeSelf);
        weaponPanel.SetActive(!kamusPanel.activeSelf);
    }

    public void ClickTutorial()
    {
        if(TutorialManager.instance != null)
        {
            if (tutorialPanel.activeSelf)
            {
                TutorialManager.instance.CloseTutorial();
            }
            else
            {
                TutorialManager.instance.SetUpTutorialData(tutorialData);
            }
        }
    }
    public void DeadPanelOpen()
    {
        deadPanel.SetActive(!deadPanel.activeSelf);
    }

}
