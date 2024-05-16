using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    //Here could be defined a level index or scene to be loaded when interacting or even just touching the level door
    //For simplicity sake of the task it simply closes the game

    public void ExitGame()
    {
        Application.Quit();
    }
}
