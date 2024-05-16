using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool isEnabled;
    [SerializeField] private float playerSpeed;
    private float moveSpeedX, moveSpeedY;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D interactCollider;
    private Transform orientationTransform;

    private void Start()
    {
        if (this.transform.childCount > 0 && GetComponentInChildren<Transform>(false))
        {
            orientationTransform = GetComponentInChildren<Transform>();
        }
        else 
        {
            orientationTransform = transform;
        }

        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
            if(rb == null)
            {
                Debug.LogWarning($"Component: PlayerController of {this.name} requires a Rigidbody2D to function!");
                isEnabled = false;
            }
        }

        if(interactCollider != null)
        {
            interactCollider.enabled = false;
        }
        else
        {
            Debug.LogWarning($"{this.name} PlayerController script missing interaction collider refference");
        }
    }

    private void Update()
    {
        if (isEnabled)
        {
            ///Interaction reset
            if (interactCollider.enabled)
            {
                interactCollider.enabled = false;
            }

            ///Movement
            moveSpeedX = Input.GetAxisRaw("Horizontal") * playerSpeed;
            moveSpeedY = Input.GetAxisRaw("Vertical") * playerSpeed;

            rb.velocity = new Vector2(moveSpeedX, moveSpeedY);
            //Debug.Log($"(PlayerController component) {this.name} speed: {rb.velocity}");

            ///Character orientation
            if (moveSpeedX > 0)
            {
                orientationTransform.SetLocalPositionAndRotation(orientationTransform.localPosition, Quaternion.Euler(Vector3.zero));
            }
            else if (moveSpeedX < 0) 
            {
                orientationTransform.SetLocalPositionAndRotation(orientationTransform.localPosition, Quaternion.Euler(Vector3.down * 180));
            }

            ///Interaction
            if (Input.GetKeyDown(KeyCode.E))
            {
                interactCollider.enabled = true;
            }
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
