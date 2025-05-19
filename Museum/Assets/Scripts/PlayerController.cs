using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController cc;
    public float moveSpeed;
    public float JumpSpeed;
    private float horizontalMove, verticalMove;
    private Vector3 dir;
    public float gravity;
    private Vector3 Velocity;
    public Transform groundCheck;
    public float CheckRadius;
    public LayerMask groundLayer;
    public bool isGround;

    private void Start()
    {
       cc= GetComponent<CharacterController>();
    }

    private void Update()
    {
        isGround = Physics.CheckSphere(groundCheck.position, CheckRadius, groundLayer);

        if (isGround && Velocity.y < 0)
        {
            Velocity.y = -3f;    
        }

        horizontalMove = Input.GetAxis("Horizontal") * moveSpeed;
        verticalMove = Input.GetAxis("Vertical") * moveSpeed;

        dir = transform.forward * verticalMove + transform.right * horizontalMove;
        cc.Move(dir * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGround)
        {
            Velocity.y = JumpSpeed;
        }

        Velocity.y -= gravity * Time.deltaTime;
        cc.Move(Velocity * Time.deltaTime);
    }
}
