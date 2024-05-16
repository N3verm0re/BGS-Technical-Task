using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private GameObject baseHUD;
    [SerializeField] private GameObject inventoryPanel;
    private bool inventoryActive;
    [SerializeField] private GameObject pausePanel;
    private bool pauseActive;
    [SerializeField] private GameObject outfitList;
    private bool outfitActive;
    [SerializeField] private GameObject shopPanel;
    private bool shopActive;
    public bool menuOpen;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!menuOpen && !inventoryActive) { OpenInventory(); }
            else if (inventoryActive) { CloseInventory(); }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!menuOpen && !pauseActive) { OpenPause(); }
            else if (pauseActive) { ClosePause(); }
        }
    }
    public void OpenInventory()
    {
        player.canInteract = false;
        player.isEnabled = false;
        menuOpen = true;
        inventoryActive = true;

        inventoryPanel.SetActive(true);
        baseHUD.SetActive(false);
    }
    public void CloseInventory() 
    {
        inventoryPanel.SetActive(false);
        baseHUD.SetActive(true);

        player.canInteract = true;
        player.isEnabled = true;
        inventoryActive = false;
        menuOpen = false;
    }
    public void OpenPause()
    {
        baseHUD.SetActive(false);
        pausePanel.SetActive(true);

        Time.timeScale = 0f;
        pauseActive = true;
        menuOpen = true;
    }
    public void ClosePause()
    {
        Time.timeScale = 1f;
        menuOpen = false;
        pauseActive = false;
        
        pausePanel.SetActive(false);
        baseHUD?.SetActive(true);
    }
    public void OpenOutfitList()
    {
        if (!outfitActive) 
        {
            outfitActive = true;
            outfitList.SetActive(true);
        }
        else
        {
            outfitActive = false;
            outfitList.SetActive(false);
        }
    }
    public void OpenShop()
    {
        player.canInteract = false;
        player.isEnabled = false;
        menuOpen = true;
        shopActive = true;

        shopPanel.SetActive(true);
        baseHUD.SetActive(false);
    }
    public void CloseShop()
    {
        player.canInteract = true;
        player.isEnabled = true;
        menuOpen = false;
        shopActive = false;

        shopPanel.SetActive(false);
        baseHUD.SetActive(true);
    }
    public void CloseGame()
    {
        Application.Quit();
    }
}
