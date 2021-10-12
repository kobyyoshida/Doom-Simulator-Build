using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public GameObject key;
    //public bool hasKey; 

    // Start is called before the first frame update
    void Start()
    {
        //PlayerController.instance.hasKey = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerController.instance.hasKey = true;
            AudioController.instance.PlayCoinPickup();
            Destroy(gameObject);
        }
    }
}

