using System;
using EventSystems;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField] private int heal;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            var conf = FindObjectOfType<PlayerConfig>();
            conf.CurrentHealth += heal;

            if (conf.CurrentHealth > conf.MaxHealth)
            {
                conf.CurrentHealth = conf.MaxHealth;
            }
            Debug.Log("Was healed player");
            Destroy(gameObject);
        }
    }
}
