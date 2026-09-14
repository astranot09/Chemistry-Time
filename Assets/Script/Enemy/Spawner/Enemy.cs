using UnityEngine;
using TMPro;
using System.Collections;
public class Enemy : MonoBehaviour
{
    [SerializeField] private TMP_Text enemyName;
    [SerializeField] private int health = 3;
    [SerializeField] private JenisBullet jenisEnemy;

    [Header("Feedback")]
    [SerializeField] private float deathTimeScale = 0.05f;
    [SerializeField] private float deathTimeFeedback = 0.05f;


    [SerializeField] private float moveSpeed = 3f;

    private Rigidbody2D rb;
    private Collider2D enemyCollider2D;
    private ParticleSystem deathParticle;

    private bool onDead = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        deathParticle = GetComponent<ParticleSystem>();
        enemyCollider2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if(!onDead)
            rb.linearVelocity = Vector2.left * moveSpeed;
    }

    public void SetUpEnemy(BulletData data)
    {
        enemyName.text = data.namaBullet;
        jenisEnemy = data.jenisBullet;
    }

    public void OnHit(JenisBullet jenisHit)
    {
        if(jenisEnemy != jenisHit)
            return;
        health--;
        Debug.Log(health);
        if(health <= 0)
        {
            Death();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.instance.TakeDamage(1);
            Destroy(gameObject);
        }
    }

    public void Death()
    {
        onDead = true;
        Debug.Log("Death");
        enemyCollider2D.enabled = false;
        GameManager.instance.AddPoint(1);
        StartCoroutine(deathTime());
        deathParticle.Play();
    }

    IEnumerator deathTime()
    {
        Time.timeScale = deathTimeScale;
        yield return new WaitForSecondsRealtime(deathTimeFeedback);
        Time.timeScale = 1f;
    }

}
