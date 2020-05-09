using UnityEngine;
using System.Collections; 
public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;
    public int health = 100;
    public int value = 50;
    public GameObject deathEffect;
    void Start()
    {
        target = Waypoints.points[0];    
    }

    // Update is called once per frame
    void Update()
    {
                Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }
    void GetNextWaypoint() {
        if (wavepointIndex >= Waypoints.points.Length - 1) {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath ()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }

   public void TakeDamage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }

    }

    void Die()
    {  PlayerStats.Money += value;
       GameObject effect = (GameObject) Instantiate(deathEffect, transform.position, Quaternion.identity);
       Destroy(effect, 5f);  
        Destroy(gameObject);
    }

}
