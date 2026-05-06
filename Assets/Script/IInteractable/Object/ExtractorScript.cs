using UnityEngine;
using UnityEngine.UI;

public class ExtractorScript : MonoBehaviour, IInteractable
{
    [SerializeField] private bool onProgress = false;
    [SerializeField] private bool isReady = false;

    [SerializeField] private float progressTime;
    [SerializeField] private float currTime;
    [SerializeField] private Image progressBar;

    [SerializeField] private Exchange exchange;

    private void Start()
    {
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
}