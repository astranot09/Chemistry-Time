using UnityEngine;

public class PlantScript : MonoBehaviour, IInteractable
{
    [SerializeField] private bool isReady = false;

    [SerializeField] private float progressTime;
    [SerializeField] private float currTime;

    //[SerializeField] private Exchange exchange;

    private SpriteRenderer spriteRenderer;
    //private Animator animator;

    [Header("SFX")]
    [SerializeField] private GameObject particleParent;
    private int childParticleCount;

    [Header("Monologue")]
    [SerializeField] private MonologueSO monologueSO;

    private void Start()
    {
        currTime = progressTime;
        spriteRenderer = GetComponent<SpriteRenderer>();
        //childParticleCount = particleParent.childCount;
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
                ReadAllParticleSystem(isReady);
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
        ReadAllParticleSystem(isReady);
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

    private void ReadAllParticleSystem(bool x)
    {
        //for(int i = childParticleCount-1; i >= 0; i--)
        //{
            if (!x)
            {
                particleParent.SetActive(false);
                //particleParent.GetComponent<ParticleSystem>().Stop();
                //particleParent.GetChild(i).GetComponent<ParticleSystem>().Stop();
            }

            else
            {
                particleParent.SetActive(true);
                //particleParent.GetComponent<ParticleSystem>().Play();
                //particleParent.GetChild(i).GetComponent<ParticleSystem>().Play();
            }
                
        //}
    }

}
