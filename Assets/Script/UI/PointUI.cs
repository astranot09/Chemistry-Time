using UnityEngine;
using TMPro;
using DG.Tweening;

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

    [Header("Animation")]
    [SerializeField] private Vector3 targetBigScale = new Vector3(1.2f, 1.2f, 1.2f);
    private Vector3 normalScale;
    [SerializeField] private Vector3 targetSmallScale = new Vector3(0.8f, 0.8f, 0.8f);
    [SerializeField] private float animationDuration;

    private void Start()
    {
        normalScale = transform.localScale;
        SetUp();
    }

    public void SetUp()
    {
        pointUI.text = GameManager.instance.ReturnPoint().ToString();
        PointAnimation();
    }

    void PointAnimation()
    {
        Transform x = pointUI.transform;

        Sequence s = DOTween.Sequence();
        s.Append(x.DOScale(targetSmallScale, animationDuration / 2))
            .Append(x.DOScale(targetBigScale, animationDuration / 2))
            .Append(x.DOScale(normalScale, animationDuration / 2).SetUpdate(true)
            );
    }
}
