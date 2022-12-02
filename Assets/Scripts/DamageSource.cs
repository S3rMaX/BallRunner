using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DagameSource : MonoBehaviour
{
    private bool _isCausingDamage = false;

    public int DamageRePeatRate = 1; // a float value may during more longer effects with this kind of dmg

    public int DamageAmount = 1;

    public bool Repeating = true;

    private void OnTriggerEnter(Collider other)
    {
        _isCausingDamage = true;

        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            if (Repeating)
            {
                StartCoroutine(TakeDamage(player, DamageRePeatRate));
            }
            else
            {
                player.TakeDamage(DamageAmount); 
            }
        }
    }

    IEnumerator TakeDamage(PlayerController player, int repeatRate) // repeat rate can be a float value
    {
        while (_isCausingDamage)
        {
            player.TakeDamage(DamageAmount);
            TakeDamage(player, repeatRate);
            yield return new WaitForSeconds(repeatRate);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            _isCausingDamage = false;
        }
    }



}
