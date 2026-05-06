using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    [SerializeField] private int health = 5;
    [SerializeField] private float duration;
    public ShieldSkill shield;


    private void Update()
    {
        duration -= Time.deltaTime;
        if(duration <= 0)
            DestroyShield();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("p");
            SkillDo(collision.gameObject);
        }
    }
    

    private void SkillDo(GameObject enemy)
    {
        health--;
        Destroy(enemy);
        if(health <= 0)
        {
            DestroyShield();
        }

    }

    private void DestroyShield()
    {
        shield.OnReset();
        Destroy(gameObject);
    }
}
