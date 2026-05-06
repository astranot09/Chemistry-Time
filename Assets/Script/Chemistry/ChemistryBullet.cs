using System.Collections;
using UnityEngine;

public class ChemistryBullet : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] private float speed;
    [SerializeField] private Vector2 dir;
    [SerializeField] private JenisBullet jenisBullet;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dir = Player.instance.lastDir;
        if(dir.x==0)
            dir= Vector2.right;

        StartCoroutine(DestroyTime());
    }
    void Update()
    {
        rb.linearVelocityX = speed *  dir.x;
    }

    public void SetUpBullet(JenisBullet jenis)
    {
        jenisBullet = jenis;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().OnHit(jenisBullet);
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyTime()
    {
        yield return new WaitForSeconds (2f);
        Destroy(gameObject);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Enemy"))
    //    {
    //        collision.GetComponent<Enemy>().OnHit(jenisBullet);
    //        Destroy(gameObject);
    //    }
    //}

}
