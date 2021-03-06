using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 10;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy1 enemy = hitInfo.GetComponent<Enemy1>();
        BossHealth boss = hitInfo.GetComponent<BossHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        if(boss != null)
        {
            boss.TakeDamage(damage);
        }
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }
}
