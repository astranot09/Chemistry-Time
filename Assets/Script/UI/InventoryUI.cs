using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private TMP_Text inventoryUIText;

    private void Start()
    {
        SetUp();
    }
    public void SetUp()
    {
        var x = PlayerInventory.instance;
        inventoryUIText.text =
    $"C = {x.C}\n" +
    $"H = {x.H}\n" +
    $"O = {x.O}\n" +
    $"N = {x.N}\n" +
    $"Plant = {x.tumbuhan}";
    }
}
