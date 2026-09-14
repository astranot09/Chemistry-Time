using System.Collections;
using UnityEngine;

public class WaveClearSkill : MonoBehaviour
{
    [SerializeField] ParticleSystem particleSystem;

    [Header("Enemy")]
    [SerializeField] Transform enemySpawner;

    [Header("Setting")]
    [SerializeField] float durationDelay = 1f;
    public void SkillCast()
    {
        particleSystem.Play();
        StartCoroutine(SkillCountdown());
    }

    public void KillAllEnemy()
    {
        int x = enemySpawner.childCount;

        for (int i = x-1; i >= 0; i--)
        {
            enemySpawner.GetChild(i).gameObject.GetComponent<Enemy>().Death();
        }
    }

    IEnumerator SkillCountdown()
    {
        yield return new WaitForSeconds(durationDelay);
        KillAllEnemy();
    }

}
