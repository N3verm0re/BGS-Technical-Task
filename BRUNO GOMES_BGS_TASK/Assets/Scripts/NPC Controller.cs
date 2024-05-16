using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCController : MonoBehaviour
{
    [SerializeField] private GameObject uiPanel;
    [SerializeField] private GameObject inRangeIndicator;

    private void Start()
    {
        inRangeIndicator.SetActive(false);
        //uiPanel.SetActive(false);
    }

    public void OpenUI()
    {

    }

    public void InRange()
    {
        inRangeIndicator.SetActive(true);
    }

    public void OutOfRange()
    {
        inRangeIndicator.SetActive(false);
    }
}
