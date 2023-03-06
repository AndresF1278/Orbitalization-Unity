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

        
        Vector3 spawnPosition = Random.onUnitSphere;

       
        Vector3 planeNormal = (spawnPosition - cameraPosition).normalized;
        Vector3 planePoint = cameraPosition + planeNormal;
        spawnPosition = Vector3.ProjectOnPlane(spawnPosition, planeNormal).normalized * spawnRadius + planePoint;

      
        directionToPlanet = (planet.position - spawnPosition).normalized;
        Quaternion spawnRotation = Quaternion.LookRotation(Vector3.forward, directionToPlanet);

        
        GameObject meteor = Instantiate(meteorPrefab, spawnPosition, spawnRotation);
        StatsCharacter enemyInfo = meteor.GetComponent<Enemy>().StatEnemy;
        meteor.GetComponent<Rigidbody2D>().velocity = directionToPlanet * enemyInfo.speed;
    }
}