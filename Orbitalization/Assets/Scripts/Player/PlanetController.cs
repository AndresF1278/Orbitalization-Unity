using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlanetController : MonoBehaviour
{
    [SerializeField] float speed;
    const string Horizontal = "Horizontal";
    const string Vertical = "Vertical";
    private float horizontal;
    private float vertical;

    private Rigidbody2D Rb;

    public StatsCharacter statsPlayer;
    private HealthManager healthManager;
    //aim
    [SerializeField] GameObject aim;
    
    private void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        healthManager = GetComponent<HealthManager>();
    }

    void Update()
    {


        horizontal = Input.GetAxisRaw(Horizontal);
        vertical = Input.GetAxisRaw(Vertical);
        PlanetMovement();
        RotatePlayer();
    }

    void PlanetMovement()
    {
       if(horizontal != 0 ||  vertical != 0)
        {
            Rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        }
        else
        {
            Rb.velocity = Vector2.zero;
        }
    }

    void RotatePlayer()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 direction = mouseWorldPos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            healthManager.SetDamage(collision.gameObject.GetComponent<Enemy>().StatEnemy.damage);
        }
    }

   
    
}
