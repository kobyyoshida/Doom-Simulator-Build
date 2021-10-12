using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{

    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right click!");
            if (collision.gameObject.tag == "Enemy")
            {
                Debug.Log("Melee Strike!!");
                AudioController.instance.PlayPlunge();
                PlayerController.instance.gunAnim.SetTrigger("Melee");
                Debug.Log("Melee Strike!");
                collision.gameObject.GetComponent<EnemyController>().SpecificDamage(3);
            }
        }
    }

    public void MeleeAttack()
    {

    }
}
