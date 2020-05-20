using UnityEngine;
using System.Collections;
public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed ;

    public float health = 100;

    public int worth = 50;

    public GameObject deathEffect;


    public void Start()
    {
        speed = startSpeed; 
    }
    public void TakeDamage(float amount) {

        health -= amount;

        if (health <= 0) {
            Die();
        }
    }

    public void Slow(float pct) {
        speed = startSpeed * (1f - pct); 
    }

    void Die() {
        PlayerStats.Money += worth;

        GameObject effect = (GameObject) Instantiate(deathEffect, transform.position , Quaternion.identity);
        Destroy(effect,5f);
        Destroy(gameObject);
    }


}
