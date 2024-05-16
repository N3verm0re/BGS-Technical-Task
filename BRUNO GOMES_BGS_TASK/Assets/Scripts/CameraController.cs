using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    public bool cameraFollow = true;
    private void Update()
    {
        //hardcode offsetting y position by 2 because sprite animation keep pushing the character 2 units up
        if (cameraFollow)
        {
            this.transform.position = new Vector3(player.position.x, player.position.y + 2, -10);
        }
    }
}
