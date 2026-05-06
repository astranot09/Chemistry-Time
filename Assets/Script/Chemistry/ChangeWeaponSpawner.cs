using UnityEngine;

public class ChangeWeaponSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ChangeWeaponUIPrefab;

    private void Start()
    {
        Spawning();
    }
    private void Spawning()
    {
        foreach (JenisBullet x in System.Enum.GetValues(typeof(JenisBullet)))
        {
            BulletData data = BulletDatabase.instance.GetBullet(x);

            if (data == null) continue;

            GameObject obj = Instantiate(ChangeWeaponUIPrefab, transform);

            ChangeWeapon change = obj.GetComponent<ChangeWeapon>();

            change.SetUpBulletUI(data);
        }
    }
}
