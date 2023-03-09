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
        Vector3 cameraPosition = Camera.main.transform.position;
        cameraPosition.z = 0f;

        Vector3 spawnPosition = Vector3.zero;
        float minDistance = 10f;
        float distance = 0f;
        float desiredZ = 0f; // Cambiar este valor a la posición z deseada

        do
        {
            spawnPosition = cameraPosition + new Vector3(Random.insideUnitCircle.normalized.x, Random.insideUnitCircle.normalized.y, 0f) * spawnRadius;

            spawnPosition.z = desiredZ;
            distance = Vector3.Distance(spawnPosition, cameraPosition);
        } while (distance < minDistance);

        float distanceToPlayer = Vector2.Distance(spawnPosition, cameraPosition);
        if (distance < 10)
        {
            return;
        }
        else
        {
            Vector3 directionToPlanet = (cameraPosition - spawnPosition).normalized;
            Quaternion spawnRotation = Quaternion.LookRotation(Vector3.forward, directionToPlanet);

            GameObject meteor = Instantiate(meteorPrefab, spawnPosition, spawnRotation);

            StatsCharacter enemyInfo = meteor.GetComponent<Enemy>().StatEnemy;
            meteor.GetComponent<Rigidbody2D>().velocity = directionToPlanet * enemyInfo.speed;
        }

    }
}
