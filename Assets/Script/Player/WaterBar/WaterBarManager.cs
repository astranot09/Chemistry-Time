using UnityEngine;
using UnityEngine.UI;

public class WaterBarManager : MonoBehaviour
{
    [Header("Survival")]
    [SerializeField] private float hydrationCurr;
    [SerializeField] private float hydrationMaxTime;

    [Header("UI")]
    [SerializeField] private Image hydrationBar;

    private void Start()
    {
        hydrationCurr = hydrationMaxTime;
    }

    private void Update()
    {
        hydrationCurr -= (Time.deltaTime / 4);
        UpdateUI();
        if(hydrationCurr <= 0)
        {
            Player.instance.TakeDamage(100);
        }
    }
    private void UpdateUI()
    {
        hydrationBar.fillAmount = hydrationCurr / hydrationMaxTime;
    }

    public void AddWater()
    {
        hydrationCurr++;
        if(hydrationCurr > hydrationMaxTime)
            hydrationCurr = hydrationMaxTime;
    }

}
