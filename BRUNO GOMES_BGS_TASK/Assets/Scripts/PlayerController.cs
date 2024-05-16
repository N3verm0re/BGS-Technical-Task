using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isEnabled;
    [SerializeField] private float playerSpeed;
    private float moveSpeedX, moveSpeedY;
    [SerializeField] private Rigidbody2D rb;
    private Transform orientationTransform;
    public bool canInteract;

    private void Awake()
    {
        ///Rename child object on awake and everytime outfit is swapped due to how animations are done, object requires specific name to be detected by Animator
        ///Ensure player only ever has 1 direct child
        this.transform.GetChild(0).name = "Rogue_pelvis_01";
    }

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
    }

    private void Update()
    {
        if (isEnabled)
        {
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
