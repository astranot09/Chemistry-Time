using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChangeWeapon : MonoBehaviour
{
    [SerializeField] private TMP_Text rumus;
    [SerializeField] private Button ChangeButton;
    [SerializeField] private Image icon;
    [SerializeField] private JenisBullet jenisBullet;
    [SerializeField] private BulletData data;

    private void OnChange()
    {
        ChemistryWeapon.instance.ChangeBulletType(jenisBullet);
    }
    public void SetUpBulletUI(BulletData bulletData)
    {
        data = bulletData;
        jenisBullet = data.jenisBullet;
        rumus.text = data.rumusBullet;

        if (icon != null && data.bulletSprite != null)
        {
            icon.sprite = data.bulletSprite;
        }

        ChangeButton.onClick.RemoveAllListeners(); // biar ga double
        ChangeButton.onClick.AddListener(OnChange);
    }

}
