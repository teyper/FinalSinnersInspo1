using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerAttack : MonoBehaviour
{
    public WeaponHit weapon;
    public float attackDuration = 0.4f;
    public AudioSource guitarAudio;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(PerformAttack());
        }
    }

    IEnumerator PerformAttack()
    {
        GetComponent<Animator>().SetTrigger("attack"); // Trigger animation
        if (guitarAudio != null) guitarAudio.Play();
        weapon.StartAttack();
        yield return new WaitForSeconds(attackDuration);
        weapon.StopAttack();
    }
}
