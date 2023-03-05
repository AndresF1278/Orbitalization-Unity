using UnityEngine;

public class SpawnEnemiesManager : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float meteorSpeed = 5f;
    public float spawnDelay = 1f;
    public float spawnRadius = 40f;
    public Transform planet;
    public Vector3 directionToPlanet;

    private float nextSpawnTime;

    

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnMeteor();
            nextSpawnTime = Time.time + spawnDelay;
        }
    }

    void SpawnMeteor()
    {
        Vector3 spawnPosition = Random.insideUnitCircle.normalized * spawnRadius;
        directionToPlanet = (planet.position - spawnPosition).normalized;
        float angleToPlanet = Mathf.Atan2(directionToPlanet.y, directionToPlanet.x) * Mathf.Rad2Deg - 90f;
        Quaternion spawnRotation = Quaternion.LookRotation(Vector3.forward, directionToPlanet);

        GameObject meteor = Instantiate(meteorPrefab, spawnPosition, spawnRotation);
        StatsCharacter enemyInfo = meteor.GetComponent<Enemy>().StatEnemy;
        meteor.GetComponent<Rigidbody2D>().velocity = directionToPlanet * enemyInfo.speed;
    }
}