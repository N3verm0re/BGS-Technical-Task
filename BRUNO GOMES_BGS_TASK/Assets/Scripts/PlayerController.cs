using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool isEnabled;
    [SerializeField] private float playerSpeed;
    private float moveSpeedX, moveSpeedY;
    [SerializeField] private Rigidbody2D rb;

    private void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
            if(rb == null)
            {
                Debug.LogWarning($"Component: PlayerController of {this.name} requires a Rigidbody2D to function!");
                isEnabled = false;
            }
        }
    }

    private void Update()
    {
        //Movement and interaction controls
        if (isEnabled)
        {
            moveSpeedX = Input.GetAxisRaw("Horizontal") * playerSpeed;
            moveSpeedY = Input.GetAxisRaw("Vertical") * playerSpeed;

            rb.velocity = new Vector2(moveSpeedX, moveSpeedY);
            //Debug.Log($"(PlayerController component) {this.name} speed: {rb.velocity}");
        }
    }

    public void DisablePlayerControl()
    {
        isEnabled = false;
    }
    public void ResumePlayerControl()
    {
        isEnabled = true;
    }
    public void OnEnable()
    {
        isEnabled = true;
    }
    public void OnDisable()
    {
        isEnabled = false;
    }
}
