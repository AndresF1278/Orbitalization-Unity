using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    private GameObject playerTransform;
    [SerializeField] GameObject preFabBullet;
    Vector2 facingDirecction;
    [SerializeField] float cadence;
    bool Shoting;

    List<GameObject> bullets = new List<GameObject>();
    [SerializeField] int maxBullets;
    private void Start()
    {
        playerTransform = GameObject.Find("Planet");
        Shoting = true;

    }
    private void Update()
    {
        if (!GameManager.Instance.isPaused)
        {
            AimPosition();
            shot();
        }
       
        
    }

    void shot()
    {
        if (Input.GetMouseButton(0) && Shoting)
        {
            float angle = Mathf.Atan2(facingDirecction.y, facingDirecction.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

            if (bullets.Count < maxBullets)
            {
                bullets.Add(Instantiate(preFabBullet, transform.position, targetRotation));
            }
            else
            {
                GameObject _currentBullet = bullets.Find(x => x.activeSelf == false);
                _currentBullet.SetActive(true);
                _currentBullet.transform.position = transform.position;
                _currentBullet.transform.rotation = targetRotation;
            }

            Shoting = false;
            StartCoroutine(CadenceTime());
        }

    }

    void AimPosition()
    {
        facingDirecction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - playerTransform.transform.position;
        transform.position = playerTransform.transform.position + (Vector3)facingDirecction.normalized * 4;
        Vector3 mousePos = Input.mousePosition;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 direction = mouseWorldPos - playerTransform.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));


    }

    IEnumerator CadenceTime()
    {
        yield return new WaitForSeconds(cadence);
        Shoting = true;
    }
}
