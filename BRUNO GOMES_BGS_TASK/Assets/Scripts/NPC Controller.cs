using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCController : MonoBehaviour
{
    [SerializeField] private GameObject inRangeIndicator;
    public UnityEvent openShopCall;

    private void Start()
    {
        inRangeIndicator.SetActive(false);
    }

    public void OpenUI()
    {
        openShopCall.Invoke();
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
