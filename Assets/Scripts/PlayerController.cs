using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 12f;
    float gravity = -10;
    Vector3 velocity;
    CharacterController characterController;

    public Transform groundCheck;
    public LayerMask groungMask;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        PlayerMove();

        CheckGround();
    }

    void PlayerMove()
    {
        // -1, gdy idziemy w lewo; 1, gdy idziemy w prawo
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Vector3 move = Vector3.right * x + Vector3.forward * z;
        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);
    }

    private void CheckGround()
    {
        RaycastHit hit;


        if (Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down), out hit, 0.4f, groungMask))
        {
            string terrainType = hit.collider.gameObject.tag;

            switch(terrainType)
            {
                default:
                    speed = 12f;
                    break;
                case "Low":
                    speed = 4f;
                    break;
                case "High":
                    speed = 20f;
                    break;
            }
        }
    }
}