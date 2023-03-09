using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGame : MonoBehaviour
{
    Vector2 playerTarget;

    private void Start()
    {
       
    }
    private void Update()
    {
        playerTarget = GameObject.Find("Planet").transform.position;
        transform.position = Vector3.Lerp(transform.position, new Vector3(playerTarget.x, playerTarget.y, transform.position.z), 2 * Time.deltaTime) ;
    }
}
