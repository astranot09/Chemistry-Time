using TMPro;
using UnityEngine;

public class IsiKamusScript : MonoBehaviour
{
    [SerializeField] private TMP_Text nama;
    [SerializeField] private TMP_Text rumus;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void SetUp(string namaData, string rumusData)
    {
        nama.text = namaData;
        rumus.text = rumusData;
    }
}
