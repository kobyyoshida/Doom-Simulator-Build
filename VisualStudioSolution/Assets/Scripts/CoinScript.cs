﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //GameManager.instance.coinsCollected++;
            
            AudioController.instance.PlayCoinPickup();
            //GameManager.instance.coinsCollected++;
            PlayerController.instance.currentCoins++;
            PlayerController.instance.UpdateCoinUI();
            Destroy(gameObject);
        }

    }


}
