using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
   [SerializeField] float _timer, _maxTime;


    [SerializeField] float speed;
    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _maxTime)
            gameObject.SetActive(false);

        transform.position += transform.right * Time.deltaTime * speed;
        //Destroy(this.gameObject, 3f);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Choca");
            int xpEnemy = collision.collider.gameObject.GetComponent<Enemy>().StatEnemy.XP;
            ExpManager.Instance.SetXPValue(xpEnemy);
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
            
        }

    }


    private void OnDisable()
    {
        _timer = 0;
    }
}
