using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public static Shop instance;
    public Text maxHealthText;
    public Text damageText;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fullHeal()
    {
        if (PlayerController.instance.currentCoins >= 10)
        {
            if (PlayerController.instance.maxHealth > PlayerController.instance.currentHealth)
            {
                PlayerController.instance.currentCoins -= 10;
                PlayerController.instance.UpdateCoinUI();
                PlayerController.instance.AddHealth(PlayerController.instance.maxHealth);
            }
        }
    }

    public void healTen()
    {
        if (PlayerController.instance.currentCoins >= 7)
        {
            if(PlayerController.instance.maxHealth > PlayerController.instance.currentHealth)
            {
                PlayerController.instance.currentCoins -= 7;
                PlayerController.instance.AddHealth(20);
                PlayerController.instance.UpdateCoinUI();
            }
        }
    }

    public void increaseMaxHealth()
    {
        if (PlayerController.instance.currentCoins >= 10)
        {
            PlayerController.instance.currentCoins -= 10;
            PlayerController.instance.maxHealth += 10;
            maxHealthText.text = "Max HealtH: " + PlayerController.instance.maxHealth;
            PlayerController.instance.UpdateCoinUI();
        }
    }

    public void buyAmmo()
    {
        if (PlayerController.instance.currentCoins >= 5)
        {
            PlayerController.instance.currentCoins -= 5;
            PlayerController.instance.currentAmmo += 15;
            PlayerController.instance.UpdateCoinUI();
            PlayerController.instance.UpdateAmmoUI();
        }
    }
    public void increaseDamage()
    {
        if (PlayerController.instance.currentCoins >= 15)
        {
            PlayerController.instance.currentCoins -= 15;
            PlayerController.instance.increaseDamage();
            PlayerController.instance.UpdateCoinUI();
            PlayerController.instance.UpdateDamageText();
        }
    }
}
