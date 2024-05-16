using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject outfitList;
    public bool menuOpen;
    private void Update()
    {
        if (!menuOpen && Input.GetKeyDown(KeyCode.I))
        {

        }

        if (!menuOpen && Input.GetKeyDown(KeyCode.Escape))
        {

        }
    }
    public void OpenInventory()
    {
        player.canInteract = false;
        player.isEnabled = false;
        menuOpen = true;
        //OpenUI, hide HUD
    }
    public void CloseInventory() 
    {
        //CloseUI, restore HUD
        player.canInteract = true;
        player.isEnabled = true;
        menuOpen = false;
    }
    public void OpenPause()
    {
        //Hide HUD, Open pause
        Time.timeScale = 0f;
        menuOpen = true;
    }
    public void ClosePause()
    {
        Time.timeScale = 1f;
        menuOpen = false;
        //Close Pause, restore HUD
    }
    public void OpenOutfitList()
    {
        //Expand outfit list if closed, hide if open
    }
}
