using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopListSpawner : MonoBehaviour
{
    [SerializeField] private TMP_Text itemSellName;
    [SerializeField] private TMP_Text itemSellPrice;
    [SerializeField] private TMP_Text itemCostName;
    [SerializeField] private TMP_Text itemCostPrice;
    [SerializeField] private Button buyButton;

    private void Start()
    {
        buyButton.onClick.AddListener(Buy); 
    }

    public void Buy()
    {
        ShopManager.instance.CheckCost();
    }


}
