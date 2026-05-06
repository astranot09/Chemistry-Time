using UnityEngine;

public class WaterShop : ExchangeShop
{
    [SerializeField] private WaterBarManager waterBarManager;
    protected override void Get()
    {
        Debug.Log("Minum");
        waterBarManager.AddWater();
    }
}
