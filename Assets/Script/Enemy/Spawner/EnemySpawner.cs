using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnDelay;
    [SerializeField] private float spawnTime;
    [SerializeField] private Transform enemySpawner;

    private void Start()
    {
        ResetTime();
    }

    private void ResetTime()
    {
        spawnTime = spawnDelay;
    }

    private void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime < 0)
        {
            ResetTime();
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        var x = Instantiate(enemyPrefab, enemySpawner);

        JenisBullet randomEnemy = (JenisBullet)Random.Range(0, System.Enum.GetValues(typeof(JenisBullet)).Length);

        x.GetComponent<Enemy>().SetUpEnemy(BulletDatabase.instance.GetBullet((JenisBullet)randomEnemy));
    }

}
