using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public StatsCharacter StatEnemy;
    private GameObject Player;

    private Animator animator;
    private bool isDead = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Chequear si el personaje ha muerto
        if (isDead)
        {

            // No hacer nada si ya se est� reproduciendo la animaci�n de muerte
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("MeteorDeath"))
                return;

            // Reproducir la animaci�n de muerte
            animator.SetTrigger("MeteorDeath");

            // Desactivar al personaje despu�s de un tiempo
            StartCoroutine(DisableCharacter());
        }
    }

    IEnumerator DisableCharacter()
    {
        // Esperar hasta que termine la animaci�n de muerte
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Desactivar al personaje
        gameObject.SetActive(false);
    }

    // Llamado desde otro script para matar al personaje
    public void Kill()
    {
        isDead = true;
    }
}
