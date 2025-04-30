using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WeaponHit : MonoBehaviour
{
    private bool isAttacking = false;

    public void StartAttack()
    {
        isAttacking = true;
    }

    public void StopAttack()
    {
        isAttacking = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isAttacking && other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.Kill();
                Debug.Log("Enemy hit by guitar!");
            }
        }
    }
}
