using System.Collections.Generic;
using UnityEngine;



//[System.Serializable]
//public class Exchange
//{
//    public Item itemSell;
//    public int priceSell;
//    public List<ExchangePayment> exchangePayments;
//}
public class ExchangeShop : MonoBehaviour, IInteractable
{
    [SerializeField] private string shopName;
    [SerializeField] private Exchange exchange;
    public void Interact()
    {
        if (PlayerInventory.instance.BuyCost(exchange))
        {
            Get();
        }
        else
        {
            Debug.Log("Ga ada Uang");
        }
    }

    protected virtual void Get()
    {

    }
}
