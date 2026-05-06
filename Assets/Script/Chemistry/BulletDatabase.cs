using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum JenisUnsur
{
    C,
    H,
    O,
    N
}


[System.Serializable]
public enum JenisBullet
{
    C,
    H,
    O,
    N,
    CO,
    CH20,
    CO2,
    NH3,
    CH3OH
}

[System.Serializable]
public class ExchangePayment
{
    public JenisUnsur unsurpay;
    public int pricePay;
}

[System.Serializable]
public class ExchangeGet
{
    public JenisUnsur unsurGet;
    public int intGet;
}

[System.Serializable]
public class Exchange
{
    public List<ExchangeGet> exchangeEarning;
    public List<ExchangePayment> exchangePayments;
}

[System.Serializable]
public class BulletData
{
    public string namaBullet;
    public string rumusBullet;
    public JenisBullet jenisBullet;
    public Sprite bulletSprite;
    public Exchange bulletChange;
}


public class BulletDatabase : MonoBehaviour
{
    public static BulletDatabase instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }


    [SerializeField] private List<BulletData> bulletData = new List<BulletData>();


    public BulletData GetBullet(JenisBullet x)
    {
        foreach (var bullet in bulletData)
        {
            if (bullet.jenisBullet == x)
            {
                return bullet;
            }
        }
        return null;
    }
    public int GetBulletCount()
    {
        return bulletData.Count;
    }

    public List<BulletData> GetAllBullets()
    {
        return bulletData;
    }

}
