using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float bulletSpeed = 3f;
    public int damageAmount;
    public Rigidbody2D theRB;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = PlayerController.instance.transform.position - transform.position;
        direction.Normalize();
        direction *= bulletSpeed;
        //Invoke("deleteObj", 8f);
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = direction * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerController.instance.TakeDamage(damageAmount);

            Destroy(gameObject);
        }
        else if(other.tag == "Wall")
        {
            Destroy(gameObject);
        }

    }

    private void deleteObj()
    {
        Destroy(gameObject);
    }
}
