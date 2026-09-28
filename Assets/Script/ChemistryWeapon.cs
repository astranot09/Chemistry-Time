using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;



public class ChemistryWeapon : MonoBehaviour
{

    public static ChemistryWeapon instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    [SerializeField] private JenisBullet jenisBulletSekarang;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private GameObject bulletPrefab;

    [Header("Charged Time")]
    [SerializeField] private float chargedTime = 1f;
    [SerializeField] private GameObject chargedParticle;

    private float currentChargeTimer = 0f;
    private bool isCharging = false;

    void Start()
    {
        SetWeaponUI();
    }

    void Update()
    {
        if (isCharging)
        {
            currentChargeTimer += Time.deltaTime;
        }
    }

    public void OnHoldCharge()
    {
        isCharging = true;
        currentChargeTimer = 0f;
        chargedParticle.SetActive(true);
    }
    public void OnChargeOff()
    {
        if (currentChargeTimer >= chargedTime)
        {
            if (PlayerInventory.instance.BulletCost(jenisBulletSekarang))
            {
                SpawnBulletPrefab();
            }
            else
            {
                Debug.Log("Ga cukup!");
            }
        }
        else
        {
            Debug.Log("Charge belum cukup :(");
        }

        isCharging = false;
        currentChargeTimer = 0f;

        if (chargedParticle != null)
            chargedParticle.SetActive(false);
    }


    private void SpawnBulletPrefab()
    {
        Sprite bulletSpritePrefab = GetBulletSprite(jenisBulletSekarang);

        if (bulletPrefab != null)
        {
            var x = Instantiate(bulletPrefab, transform.position, transform.rotation, bulletSpawn);
            ChemistryBullet chem = x.GetComponent<ChemistryBullet>();
            chem.SetUpBullet(jenisBulletSekarang);

            //SpriteRenderer sr = x.GetComponent<SpriteRenderer>();
            //if (sr != null)
            //{
            //    sr.sprite = bulletSpritePrefab;
            //}
        }
    }

    private Sprite GetBulletSprite(JenisBullet jenis)
    {
        BulletData bulletData = BulletDatabase.instance.GetBullet(jenis);
        if(bulletData != null)
        {
            return bulletData.bulletSprite;
        }
        return null;
    }

    public void ChangeBulletType(JenisBullet unsur)
    {
        jenisBulletSekarang = unsur;
        SetWeaponUI();
    }

    public JenisBullet GetBulletType()
    {
        return jenisBulletSekarang;
    }

    public void SetWeaponUI()
    {
        WeaponUI.instance.SetUpUIWeapon(BulletDatabase.instance.GetBullet(jenisBulletSekarang).rumusBullet);
    }

}
