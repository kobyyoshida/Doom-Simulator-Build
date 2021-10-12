using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopKeeper : MonoBehaviour
{

    //public GameObject shopHUD;
    public Text maxHealthText;
    public Text damageText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Shop.instance.gameObject.SetActive(true);
            Shop.instance.maxHealthText.text = "Max HealtH: " + PlayerController.instance.maxHealth;
            GameManager.instance.UnlockCursor();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Shop.instance.gameObject.SetActive(false);
            GameManager.instance.LockCursor();
        }
    }


    // Update is called once per frame
    void Update()
    {
      /*  if(Vector3.Distance(PlayerController.instance.gameObject.transform.position, transform.position) < 3)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //turn on the HUD for the shop if its off. if its on, turn it off
                if(Shop.instance.gameObject.activeSelf)
                {
                    Shop.instance.gameObject.SetActive(false);
                    GameManager.instance.LockCursor();
                    //Time.timeScale = 1;
                }
                else
                {
                    Shop.instance.gameObject.SetActive(true);
                    Shop.instance.maxHealthText.text = "Max HealtH: " + PlayerController.instance.maxHealth;
                    GameManager.instance.UnlockCursor();
                    //Time.timeScale = 0;
                }
            }
        } else
        {
            if(Shop.instance.gameObject.activeSelf)
            {
                Shop.instance.gameObject.SetActive(false);
                GameManager.instance.LockCursor();
                //Time.timeScale = 1;
            }
        }*/
    }
}
