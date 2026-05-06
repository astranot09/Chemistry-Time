using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }


    [Header("Unsur")]
    public int C;
    public int H;
    public int O;
    public int N;

    [Header("Sumber")]
    public int tumbuhan;


    [Header("Reference")]
    public InventoryUI inventoryUI;

    // =========================
    // GET UNSUR
    // =========================
    public int GetUnsur(JenisUnsur unsur)
    {
        switch (unsur)
        {
            case JenisUnsur.C: return C;
            case JenisUnsur.H: return H;
            case JenisUnsur.O: return O;
            case JenisUnsur.N: return N;
        }
        return 0;
    }

    // =========================
    // TAMBAH UNSUR (optional)
    // =========================
    public void AddUnsur(JenisUnsur unsur, int amount)
    {
        switch (unsur)
        {
            case JenisUnsur.C: C += amount; break;
            case JenisUnsur.H: H += amount; break;
            case JenisUnsur.O: O += amount; break;
            case JenisUnsur.N: N += amount; break;
        }
    }

    // =========================
    // KURANGI UNSUR
    // =========================
    public void ReduceUnsur(JenisUnsur unsur, int amount)
    {
        switch (unsur)
        {
            case JenisUnsur.C: C -= amount; break;
            case JenisUnsur.H: H -= amount; break;
            case JenisUnsur.O: O -= amount; break;
            case JenisUnsur.N: N -= amount; break;
        }
    }

    // =========================
    // CEK APAKAH CUKUP
    // =========================
    public bool HasEnough(Exchange exchange)
    {
        foreach (var payment in exchange.exchangePayments)
        {
            if (GetUnsur(payment.unsurpay) < payment.pricePay)
            {
                return false;
            }
        }

        inventoryUI.SetUp();
        return true;
    }

    // =========================
    // KURANGI SESUAI COST
    // =========================
    public void PayCost(Exchange exchange)
    {
        foreach (var payment in exchange.exchangePayments)
        {
            ReduceUnsur(payment.unsurpay, payment.pricePay);
        }
        inventoryUI.SetUp();
    }

    // =========================
    // TAMBAHKAN SESUAI EARN
    // =========================
    public void Earning(Exchange exchange)
    {
        foreach (var earn in exchange.exchangeEarning)
        {
            AddUnsur(earn.unsurGet, earn.intGet);
        }
        inventoryUI.SetUp();
    }


    // =========================
    // FUNGSI UTAMA (DIPANGGIL SAAT NEMBAK)
    // =========================
    public bool BulletCost(JenisBullet jenis)
    {
        BulletData bulletData = BulletDatabase.instance.GetBullet(jenis);

        if (bulletData == null)
            return false;

        // CEK DULU
        if (!HasEnough(bulletData.bulletChange))
            return false;

        // BAYAR
        PayCost(bulletData.bulletChange);

        return true;
    }

    public bool BuyCost(Exchange exchange)
    {
        // CEK DULU
        if (!HasEnough(exchange))
            return false;

        // BAYAR
        PayCost(exchange);

        inventoryUI.SetUp();
        return true;
    }

    public bool ExchangeGet(Exchange exchange)
    {
        // CEK DULU
        if (tumbuhan <= 0)
            return false;

        // BAYAR
        tumbuhan--;

        // DAPAT
        Earning(exchange);
        inventoryUI.SetUp();
        return true;
    }

    public void AddPlant(int x)
    {
        tumbuhan += x;
        inventoryUI.SetUp();
    }
    public void TakePlant(int x)
    {
        tumbuhan -= x;
        inventoryUI.SetUp();
    }
}
