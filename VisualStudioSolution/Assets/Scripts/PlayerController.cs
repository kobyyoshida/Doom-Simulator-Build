using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //public float damage;
    public int damageLevel;
    public Rigidbody2D theRB;
    public float moveSpeed = 5f;
    public float verticalViewClampAngle = 80f;
    private Vector2 moveInput;
    private Vector2 mouseInput;

    public float mouseSensitivity = 1f;

    public Camera viewCam;
    public static PlayerController instance;

    public GameObject bulletImpact;
    public int currentAmmo;

    public Animator gunAnim;
    public Animator anim;

    public int currentHealth;
    public int maxHealth = 100;
    public GameObject deadScreen;
    private bool hasDied;

    public Text healthText, ammoText, coinText, damageText;

    public bool hasKey;

    public int currentCoins = 0;
    public float currentDamage;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthText.text = currentHealth.ToString() + "%";
        UpdateAmmoUI();
        //Cursor.lockState = CursorLockMode.Locked;
        hasKey = false;
        currentDamage = 1.0f;
        damageLevel = 1;
        //currentDamage = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasDied)
        {
            if (Time.timeScale != 0)
            {


                //player WASD
                moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                Vector3 moveHorizontal = transform.up * -moveInput.x;
                Vector3 moveVertical = transform.right * moveInput.y;
                theRB.velocity = (moveHorizontal + moveVertical) * moveSpeed;

                //player camera 
                mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseInput.x);

                viewCam.transform.localRotation = Quaternion.Euler(viewCam.transform.localRotation.eulerAngles.x,
                                                                   Mathf.Clamp(viewCam.transform.localRotation.eulerAngles.y + mouseInput.y, 90 - verticalViewClampAngle, 90 + verticalViewClampAngle),
                                                                   viewCam.transform.localRotation.eulerAngles.z);

                //shooting
                if (Input.GetMouseButtonDown(0))
                {
                    if (currentAmmo > 0)
                    {
                        if(!Shop.instance.gameObject.activeSelf)
                        {
                            Ray ray = viewCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
                            RaycastHit hit;
                            if (Physics.Raycast(ray, out hit))
                            {
                                //Debug.Log("I'm looking at " + hit.transform.name);
                                Instantiate(bulletImpact, hit.point, transform.rotation);

                                if (hit.transform.tag == "Enemy")
                                {
                                    hit.transform.parent.GetComponent<EnemyController>().SpecificDamage(currentDamage);
                                }
                                AudioController.instance.PlayGunShot();
                            }
                            else
                            {
                                //Debug.Log("I'm looking at nothing");
                            }
                            currentAmmo--;
                            UpdateAmmoUI();
                            gunAnim.SetTrigger("Shoot");
                        }
                    }
                }

                if (moveInput != Vector2.zero)
                {
                    anim.SetBool("isMoving", true);
                }
                else
                {
                    anim.SetBool("isMoving", false);
                }
            }
        }
    }

    public void TakeDamage(int damageAmount)//player taking damage
    {
        currentHealth -= damageAmount;

        if(currentHealth <= 0)
        {
            deadScreen.SetActive(true);
            GameManager.instance.UnlockCursor();
            hasDied = true;
            currentHealth = 0;
            Time.timeScale = 0;
        }

        healthText.text = currentHealth.ToString() + "%";
        AudioController.instance.PlayPlayerHurt();
    }


    public void AddHealth(int healAmount)
    {
        currentHealth += healAmount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthText.text = currentHealth.ToString() + "%";
    }

    public void UpdateAmmoUI()
    {
        ammoText.text = currentAmmo.ToString();
    }

    public void UpdateCoinUI()
    {
        coinText.text = currentCoins.ToString();
    }
    public void increaseDamage()
    {
        currentDamage += .5f;
        damageLevel++;
    }
    public void UpdateDamageText()
    {
        damageText.text = "Damage Level: " + damageLevel.ToString();
    }
}
