using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //room camera
    [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    //follow player
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float aheadDistance;//vi tri cam huong ve trc
    [SerializeField]
    private float cameraSpeed;
    private float lookAhead;


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (player.position.x, 
            player.position.y, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, 
            (aheadDistance * player.localScale.x), 
            Time.deltaTime*cameraSpeed);

    }
}
