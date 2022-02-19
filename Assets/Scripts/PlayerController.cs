using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 12f;
    CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        // -1, gdy idziemy w lewo; 1, gdy idziem w prawo
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Vector3 move = Vector3.right * x + Vector3.forward * z;
        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);
    }
}