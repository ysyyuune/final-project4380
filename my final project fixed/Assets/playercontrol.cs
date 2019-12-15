using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 3.5f;
    public float gravity = 10f;
    private RaycastHit _hit;
    public GameObject lefthand;
    public GameObject righthand;
    public GameObject reaction;
    public GameObject camera;
    private int targetLayer = 1 << 8;

    private CharacterController controller;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private GameObject Target;
    void Update()
    {
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out _hit, Mathf.Infinity, targetLayer))
        {
            Target = _hit.collider.gameObject;
            if (Input.GetButtonDown("Jump")&& lefthand.transform.childCount == 0)
            {
                //position of object change
                //gameobject tag change
                Target.gameObject.transform.parent = lefthand.transform;
                Target.transform.localPosition = new Vector3(-1f, 2f, 1f);
            }
            if (Input.GetButtonDown("Fire3") && righthand.transform.childCount == 0)
            {
                //position of object change
                //gameobject tag change
                Target.transform.parent = righthand.transform;
                Target.transform.localPosition = new Vector3(-2f, 3f, 1f);
            }
            if (Input.GetButtonDown("Fire1"))
            {
                reaction.GetComponent<reaction>();
            }
        }
        PlayerMovement();
    }
    void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        Vector3 velocity = direction * speed;
        velocity.y -= gravity;
        controller.Move(velocity * Time.deltaTime);
    }
}
