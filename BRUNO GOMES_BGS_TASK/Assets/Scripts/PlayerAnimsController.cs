using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimsController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animController;

    private void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
            if (rb == null)
            {
                Debug.LogWarning($"{this.name} lacks component RigidBody2D to properly animate!");
                enabled = false;
            }
        }

        if (animController == null)
        {
            animController = GetComponent<Animator>();
            if (animController == null)
            {
                Debug.LogWarning($"{this.name} lacks component Animator to properly animate!");
                enabled = false;
            }
        }
    }

    private void Update()
    {
        if (rb.velocity.magnitude > 0)
        {
            animController.SetBool("isMoving", true);
        }
        else
        {
            animController.SetBool("isMoving", false);
        }
    }
}
