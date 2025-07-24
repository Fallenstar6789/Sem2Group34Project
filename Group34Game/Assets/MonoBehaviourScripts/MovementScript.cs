using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed = 4f;
    public float jump = 3f;
    Rigidbody rb;
    BoxCollider col;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        col = GetComponent<BoxCollider>();
    }
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal") * speed;
        float Vertical = Input.GetAxis("Vertical") * speed;
        Horizontal *= Time.deltaTime;
        Vertical *= Time.deltaTime;

        transform.Translate(Horizontal, 0, Vertical);

        if(isGrounded() && Input.GetButtonDown("Jump")) 
        {
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }

        if (Input.GetKeyDown("escape")) 
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private bool isGrounded() 
    {
        return Physics.Raycast(transform.position, Vector3.down, col.bounds.extents.y + 0.1f);
    }
}
