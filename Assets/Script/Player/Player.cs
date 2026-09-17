using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    public static Player instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    [Header("Health")]
    [SerializeField] private int health = 5;


    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector2 dir;
    public Vector2 lastDir = Vector2.right;

    private Rigidbody2D rb;
    //[SerializeField] private SpriteRenderer spriteRenderer;
    [Header("Sprite")]
    [SerializeField] private Transform playerSprite;
    private bool alreadyRotate;

    private bool onDeath = false;

    [SerializeField] private PlayerInteractSystem interactSystem;

    private Animator animator;

    [Header("Effect Feedback")]
    [SerializeField] private CinemachineImpulseSource impulseSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        interactSystem = GetComponent<PlayerInteractSystem>();

        animator = GetComponent<Animator>();
    }

    public void SetDirectionPlayer(Vector2 dir, Vector2 lastDir)
    {
        this.dir = dir;
        this.lastDir = lastDir;
    }

    void Update()
    {
        animator.SetFloat("velocity",rb.linearVelocity.magnitude);
        rb.linearVelocity = dir * moveSpeed;
        if (lastDir.x < 0 && !alreadyRotate)
        {
            alreadyRotate = true;
            playerSprite.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (lastDir.x > 0 && alreadyRotate)
        {
            alreadyRotate = false;
            playerSprite.localRotation = Quaternion.identity;
        }
    }

    public void TakeDamage(int damage)
    {
        if (onDeath) return;
        health -= damage;
        SoundManager.instance.PlaySFX(SoundManager.instance.damage);
        impulseSource.GenerateImpulse();
        if (health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        onDeath = true;
        UIManager.instance.DeadPanelOpen();
        BestScoreManager.instance.AddScore(GameManager.instance.ReturnPoint());
    }
}
