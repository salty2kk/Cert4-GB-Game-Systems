using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script can be found in the component section under the option Intro PRG/Character Movement
[AddComponentMenu("RPG Game / Character / Movement")]
//This script requires CharacterController component to be added to gameObject
[RequireComponent(typeof(CharacterController))]

#region Extra Study
//Input Manager(https://docs.unity3d.com/Manual/class-InputManager.html)
//Input(https://docs.unity3d.com/ScriptReference/Input.html)
//CharacterController allows you to move the character kinda like Rigidbody (https://docs.unity3d.com/ScriptReference/CharacterController.html
#endregion

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    [Header("Character")]
    [Tooltip("Use this to apply movement in worldspace")]
    public Vector3 moveDir; // we will use this to apply movement in worldspace
    public CharacterController charC; // this is our reference variable to the character controller
    [Header("Speeds")] // headers createa header for a variable directly below
    public float moveSpeed = 5f;
    public float jumpSpeed = 8f;
    public float gravity = 20f;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        charC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(charC.isGrounded)
        {
            // set moveDir to the inputs direction
            moveDir = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
            // moveDir's forward is changed from global z  (forward) to the Game Object local z (forward)
            moveDir = transform.TransformDirection(moveDir);

            moveDir *= moveSpeed;

            if(Input.GetButton("Jump"))
            {
                moveDir.y = jumpSpeed;
            }
        }

        moveDir.y -= gravity * Time.deltaTime;

        charC.Move(moveDir * Time.deltaTime);
    }
}
