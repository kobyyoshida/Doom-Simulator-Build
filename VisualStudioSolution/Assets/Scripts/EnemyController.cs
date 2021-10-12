using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float health = 3.0f;
    public GameObject explosion;

    public float playerRange = 10f;

    public Rigidbody2D theRB;
    public float moveSpeed;

    public bool shouldShoot;
    public float fireRate = .5f;
    private float shotCounter;
    public GameObject bullet;
    public GameObject coin;
    public Transform firePoint;
    public Vector3 lastPosition;
    public Animator anim;
    public int coinDropMin;
    public int coinDropMax;
    public GameObject key;
    public int keyDropMinChance = 1;
    public int keyDropMaxChance = 100;
    public bool isBoss = false;



    // Start is called before the first frame update
    void Start()
    {
        keyDropMinChance = 1;
        keyDropMaxChance = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector3.Distance(transform.position, PlayerController.instance.transform.position) < playerRange) || health < 3)
        {
            Vector3 playerDirection = PlayerController.instance.transform.position - transform.position;

            theRB.velocity = playerDirection.normalized * moveSpeed;

            if (shouldShoot)
            {
                shotCounter -= Time.deltaTime;

                if (shotCounter <= 0)
                {
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                    shotCounter = fireRate;
                    //AudioController.instance.PlayGunShot();
                }
            }
        }
        else
        {
            theRB.velocity = Vector2.zero;
        }

        if (theRB.velocity == Vector2.zero)
        {
            anim.SetBool("isMoving", false);
        }
        else
        {
            anim.SetBool("isMoving", true);
        }

        //UpdateSprite();
        lastPosition = transform.position;
    }

    public void TakeDamage()
    {
        //PlayerController.damage = d;
        health--;
        if (health <= 0) //if the enemy is dead
        {
            AudioController.instance.PlayEnemyDeath();
            dropCoins(coinDropMin, coinDropMax);
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            if(isBoss)
            {
                Time.timeScale = 0;
                GameManager.instance.WinScreen.SetActive(true);
                GameManager.instance.UnlockCursor();
            }
            //Instantiate(coinPool);
        }
        else
        {
            AudioController.instance.PlayEnemyShot();
        }
    }

    public void SpecificDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0)//if the enemy is dead
        {
            AudioController.instance.PlayEnemyDeath();
            dropCoins(coinDropMin, coinDropMax);
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            if (isBoss)
            {
                Time.timeScale = 0;
                GameManager.instance.WinScreen.SetActive(true);
                GameManager.instance.UnlockCursor();
            }
        }
    }

    public void UpdateSprite()
    {
        Vector3 playerDirection = PlayerController.instance.transform.position - transform.position;
        playerDirection.Normalize();
        Vector3 currentDirection = lastPosition - transform.position;
        currentDirection.Normalize();
        float angle = Vector3.Angle(playerDirection, currentDirection);
        Debug.Log(angle);
    }

    public void dropCoins(int minCoins, int maxCoins)
    {
        //need this function to take in the position of the enemy and then change the y value with delta time for it to drop to the ground
        //Random rnd = new Random();
        int numCoins = Random.Range(minCoins, maxCoins);
        for(int i = 0; i < numCoins; i++)
        {
            Debug.Log("Coin Spawned.");
            GameObject newCoin = Instantiate(coin, transform);
            newCoin.transform.SetParent(GameManager.instance.transform);
            float offsetX = Random.Range(-.5f, .5f);
            float offsetY = Random.Range(-.5f, .5f);
            newCoin.transform.position = new Vector3(transform.position.x + offsetX, transform.position.y + offsetY, 0);
        }
        if (!PlayerController.instance.hasKey)
        {
            chanceDropKey(key);
        }
    }
    public void chanceDropKey(GameObject key)
    {
        float keyDropChance = Random.Range(keyDropMinChance,keyDropMaxChance);
        //Debug.Log("Key Spawned.");
        if(keyDropChance > 90)
        {
            Debug.Log("Key Dropped.");
            //Instantiate();
            GameObject newKey = Instantiate(key, transform);
            newKey.transform.SetParent(GameManager.instance.transform);
        }
    }
}
