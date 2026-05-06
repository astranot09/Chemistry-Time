using UnityEngine;

public class KamusSpawner : MonoBehaviour
{
    [SerializeField] private GameObject isiKamusPrefab;

    private void Start()
    {
        SetUp();
    }

    private void SetUp()
    {
        var allData = BulletDatabase.instance.GetAllBullets();
        foreach(var x in allData)
        {
            var isi = Instantiate(isiKamusPrefab, transform);
            isi.GetComponent<IsiKamusScript>().SetUp(x.namaBullet,x.rumusBullet);
        }
    }
}
