using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
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
    [SerializeField] private ParticleSystem deathParticle;

    private bool onDead = false;
    [SerializeField] private Transform enemySpriteParent;

    private void Awake()
    {
        //spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        enemyCollider2D.enabled = false;
        GameManager.instance.AddPoint(1);

        // Play particle jika ada (lepaskan parent-nya dulu kalau child dari enemy agar tidak mendadak hancur)
        if (deathParticle != null)
        {
            deathParticle.transform.SetParent(null);
            deathParticle.Play(true);
            Destroy(deathParticle.gameObject, deathParticle.main.duration);
        }

        StartCoroutine(DeathRoutine());
    }

    private IEnumerator DeathRoutine()
    {
        // 1. Hitstop / Freeze Frame Effect
        Time.timeScale = deathTimeScale;
        yield return new WaitForSecondsRealtime(deathTimeFeedback);
        Time.timeScale = 1f;

        // 2. Disassemble / Meledakkan kepingan
        CharacterDisassemble();

        // 3. Hapus GameObject parent utama
        Destroy(gameObject);
    }

    private void CharacterDisassemble()
    {
        // Kumpulkan semua child transform
        Transform[] allChildren = new Transform[enemySpriteParent.childCount];

        for (int i = 0; i < enemySpriteParent.childCount; i++)
        {
            allChildren[i] = enemySpriteParent.GetChild(i);
        }

        foreach (var child in allChildren)
        {
            // Lepas parent agar tidak hancur saat parent-nya di-Destroy
            child.SetParent(null);

            // Tambahkan Rigidbody2D jika belum ada
            Rigidbody2D childRb = child.GetComponent<Rigidbody2D>();
            if (childRb == null)
            {
                childRb = child.gameObject.AddComponent<Rigidbody2D>();
            }

            // Atur gravity scale agar kepingan jatuh/melayang pas
            childRb.gravityScale = 1f;

            // Beri gaya ledakan acak
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            float explosionForce = Random.Range(5f, 10f);

            childRb.AddForce(randomDirection * explosionForce, ForceMode2D.Impulse);
            childRb.AddTorque(Random.Range(-5f, 5f), ForceMode2D.Impulse);

            // Fade out kepingannya perlahan sebelum hancur (misal fade dalam 2.5 detik)
            SpriteRenderer sr = child.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.DOFade(0f, 2.5f);
            }

            // Hapus kepingan dari memory setelah 3 detik
            Destroy(child.gameObject, 3f);
        }
    }
}
