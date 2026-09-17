using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ExtractorScript : MonoBehaviour, IInteractable
{
    [SerializeField] private bool onProgress = false;
    [SerializeField] private bool isReady = false;

    [SerializeField] private float progressTime;
    [SerializeField] private float currTime;
    [SerializeField] private Image progressBar;

    [SerializeField] private Exchange exchange;

    [Header("Particle")]
    [SerializeField] ParticleSystem particleSystem;


    [Header("Animation")]
    [SerializeField] private Vector3 scaleValue = new Vector3(1.2f, 1.2f, 1.2f);
    [SerializeField] private float duration = 1f;
    [SerializeField] private float strength = 2f;
    private Vector3 normalScale;

    private void Start()
    {
        normalScale = transform.localScale;
        UpdateProgressBar();
    }

    private void Update()
    {
        if (onProgress)
        {
            currTime -= Time.deltaTime;

            if (currTime <= 0 && !isReady)
            {
                currTime = 0;
                onProgress = false;
                isReady = true;
                AnimationDone();
            }
            UpdateProgressBar();
        }
    }

    private void Do()
    {
        PlayerInventory.instance.TakePlant(1);
        currTime = progressTime;
        onProgress = true;
    }

    private void UpdateProgressBar()
    {
        float fill = currTime / progressTime;
        progressBar.fillAmount = fill;

        progressBar.enabled = onProgress;
    }

    public void Interact()
    {
        if (onProgress) return;

        if (isReady)
        {
            PlayerInventory.instance.Earning(exchange);
            isReady = false;
        }
        else
        {
            if(PlayerInventory.instance.tumbuhan <=0) return;
            Do();
        }
    }


    private void AnimationDone()
    {
        float halfDuration = duration / 2f;

        Sequence s = DOTween.Sequence();
        s.Append(transform.DOScaleY(Mathf.Abs(normalScale.y + (normalScale.y - scaleValue.y)), halfDuration))
         .Join(transform.DOScaleX(scaleValue.x, duration))
         .Append(transform.DOScaleY((normalScale.y + scaleValue.y), halfDuration))
         .Join(transform.DOScaleX(scaleValue.x, halfDuration))
         .Append(transform.DOScaleY(normalScale.y, halfDuration))
         .Join(transform.DOScaleX(normalScale.x, halfDuration))
         .OnComplete(()=> particleSystem.Play()); // Added missing X restoration
    }

}