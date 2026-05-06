using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }


    [SerializeField] private int point;

    public void AddPoint(int x)
    {
        point += x;
        PointUI.instance.SetUp();
        SoundManager.instance.PlaySFX(SoundManager.instance.gainPoint);
    }
    public int ReturnPoint()
    {
        return point;
    }
}
