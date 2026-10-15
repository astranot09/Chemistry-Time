using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    [SerializeField] private AudioSource BGM;
    [SerializeField] private AudioSource SFX;

    [SerializeField] private AudioClip bgmMusic;
    public AudioClip gainPoint;
    public AudioClip damage;
    public AudioClip drink;
    public AudioClip processDone;
    public AudioClip failedInteract;
    private void Start()
    {
        PlayBGM(bgmMusic);
    }

    public void PlayBGM(AudioClip clip)
    {
        BGM.clip = clip;
        BGM.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }
}
