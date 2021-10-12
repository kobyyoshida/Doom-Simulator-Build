using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject boss;
    public EnemyController bossController;
    public GameObject menu;
    public GameObject WinScreen;
    public int coinsCollected = 0;
    public Slider sensitivitySlider;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        sensitivitySlider.value = PlayerController.instance.mouseSensitivity;
        Time.timeScale = 1;
        WinScreen.SetActive(false);
        //bossController = boss.GetComponent<EnemyController>();
        LockCursor();
        PlayerController.instance.UpdateDamageText();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
        if(Input.GetMouseButtonDown(0))
        {
            //LockCursor();
        }
        /*if(bossController.health < 1)
        {
            //win game
            Time.timeScale = 0;
            WinScreen.SetActive(true);
            UnlockCursor();
        }*/
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ToggleCursor()
    {
        if(Cursor.lockState == CursorLockMode.None)
        {
            LockCursor();
        }
        else
        {
            UnlockCursor();
        }
    }

    public void ToggleMenu()
    {
        if(menu.activeSelf == true)
        {
            menu.SetActive(false);
            LockCursor();
            Time.timeScale = 1;
            PlayerController.instance.mouseSensitivity = sensitivitySlider.value;
        }
        else
        {
            menu.SetActive(true);
            UnlockCursor();
            Time.timeScale = 0;
        }
    }
}
