using System.Collections.Generic;
using UnityEngine;

public class SpaceGenerator : MonoBehaviour
{
    public GameObject starPrefab;
    public int maxStars = 100;
    public float minDistance = 10f;
    public float maxDistance = 30f;
    public float maxDistanceFromPlayer = 100f;

    private List<GameObject> stars;
    private Transform playerTransform;
    private Camera mainCamera;

    void Start()
    {
        stars = new List<GameObject>();
        playerTransform = GameObject.Find("Planet").transform;

        mainCamera = Camera.main;

        // Crear estrellas iniciales
        for (int i = 0; i < maxStars; i++)
        {
            GameObject star = Instantiate(starPrefab, transform);
            star.SetActive(false);
            stars.Add(star);
        }
    }

    Vector3 GeneratePosition()
    {
        Vector3 viewportPoint = new Vector3(Random.Range(-1f, 2f), Random.Range(-1f, 2f), Random.Range(0f, 1f));
        Vector3 position = mainCamera.ViewportToWorldPoint(viewportPoint);
        Vector3 direction = Random.onUnitSphere;
        float distance = Random.Range(minDistance, maxDistance);
        position += direction * distance;
        return position;
    }

    GameObject GetInactiveStar()
    {
        foreach (GameObject star in stars)
        {
            if (!star.activeSelf)
            {
                return star;
            }
        }
        return null;
    }

    GameObject GetActiveStar(Vector3 position)
    {
        foreach (GameObject star in stars)
        {
            if (star.activeSelf && Vector3.Distance(star.transform.position, position) < 0.1f)
            {
                return star;
            }
        }
        return null;
    }

    void CreateStar()
    {
        // Generar posición aleatoria fuera de la cámara
        Vector3 position = GeneratePosition();

        // Verificar distancia desde el jugador
        float distanceToPlayer = Vector3.Distance(playerTransform.position, position);
        if (distanceToPlayer > maxDistanceFromPlayer)
        {
            GameObject newstar = GetActiveStar(position);

            if (newstar != null)
            {
                newstar.SetActive(false);
            }
            return;
        }

        // Activar estrella y establecer posición
        GameObject star = GetInactiveStar();
        if (star != null)
        {
            star.SetActive(true);
            star.transform.position = position;
        }
    }

    private void Update()
    {
        playerTransform = GameObject.Find("Planet").transform;
        CreateStar();

        // Desactivar estrellas lejanas
        foreach (GameObject star in stars)
        {
            if (star.activeSelf && Vector3.Distance(star.transform.position, playerTransform.position) > maxDistanceFromPlayer)
            {
                star.SetActive(false);
            }
        }
    }
}
