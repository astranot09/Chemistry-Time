using UnityEngine;

public class PlantScript : MonoBehaviour, IInteractable
{
    [SerializeField] private bool isReady = false;

    [SerializeField] private float progressTime;
    [SerializeField] private float currTime;

    //[SerializeField] private Exchange exchange;

    private SpriteRenderer spriteRenderer;
    //private Animator animator;

    [Header("Monologue")]
    [SerializeField] private MonologueSO monologueSO;

    private void Start()
    {
        currTime = progressTime;
        spriteRenderer = GetComponent<SpriteRenderer>();
        //ResetTime();
    }

    private void Update()
    {
        if (!isReady)
        {
            currTime += Time.deltaTime;

            if (currTime >= progressTime)
            {
                isReady = true;
                spriteRenderer.color = Color.green;
                currTime = progressTime;
                MonologueManager.instance.PlayMonologue(monologueSO);
            }
            //UpdateProgressBar();
        }
    }

    private void Do()
    {
        currTime = progressTime;
    }

    private void ResetTime()
    {
        currTime = 0;
        isReady = false;
        spriteRenderer.color = Color.red;
    }

    //private void UpdateProgressBar()
    //{
    //    float fill = currTime / progressTime;
    //    progressBar.fillAmount = fill;

    //    progressBar.enabled = onProgress;
    //}

    public void Interact()
    {
        if (!isReady) return;
        PlayerInventory.instance.AddPlant(3);
        ResetTime();
    }
}
