using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystals : MonoBehaviour
{
    public AudioSource destroySound;
    public Damage damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (destroySound != null)
            {
                destroySound.Play();
            }

            Destroy(gameObject);
            damage.crystalcrash();
        }
    }
}
