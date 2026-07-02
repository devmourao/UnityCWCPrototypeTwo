using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public InputAction moveAction;
    public Vector2 moveInput;
    public float speed = 10.0f;

    void Start()
    {
        moveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -10.0f)
        {
            transform.position = new Vector3(-10.0f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > 10.0f)
        {
            transform.position = new Vector3(10.0f, transform.position.y, transform.position.z);
        }

        moveInput = moveAction.ReadValue<Vector2>();

        transform.Translate(Vector3.right * moveInput.x * speed * Time.deltaTime);
    }
}
