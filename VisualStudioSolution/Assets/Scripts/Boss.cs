using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public EnemyController bossController;
 

    // Update is called once per frame
    void Update()
    {
        Debug.Log(bossController.health);
        if(bossController.health < 1)
        {
            Debug.Log("Boss Defeated.");
            Time.timeScale = 0;
            GameManager.instance.WinScreen.SetActive(true);
            GameManager.instance.UnlockCursor();
        }
    }
}
