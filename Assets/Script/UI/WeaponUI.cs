using UnityEngine;
using TMPro;
using Unity.VisualScripting;
public class WeaponUI : MonoBehaviour
{

    public static WeaponUI instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private TMP_Text weaponSekarangUI;

    public void SetUpUIWeapon(string x)
    {
        weaponSekarangUI.text = x;
    }
}
