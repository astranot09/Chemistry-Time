using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    [Header("Main Menu")]
    [SerializeField] private GameObject tutorial;

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
        tutorial.SetActive(!tutorial.activeSelf);
    }
    public void DeadPanelOpen()
    {
        deadPanel.SetActive(!deadPanel.activeSelf);
    }

}
