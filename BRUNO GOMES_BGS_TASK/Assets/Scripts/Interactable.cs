using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool inRange;
    public UnityEvent interactCall;
    public UnityEvent inRangeCall;
    public UnityEvent outOfRangeCall;

    private void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                interactCall.Invoke();
                Debug.Log($"Interacting with {this.name}");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.CompareTag("Player"))
        {
            inRangeCall.Invoke();
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.parent.CompareTag("Player"))
        {
            outOfRangeCall.Invoke();
            inRange = false;
        }
    }
}
