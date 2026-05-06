using UnityEngine;
using TMPro;
public class PointUI : MonoBehaviour
{
    public static PointUI instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    [SerializeField] private TMP_Text pointUI;

    private void Start()
    {
        SetUp();
    }

    public void SetUp()
    {
        pointUI.text = GameManager.instance.ReturnPoint().ToString();
    }
}
