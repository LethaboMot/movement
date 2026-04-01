using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;
    public float jumpForce = 5f;
    private Rigidbody rb;
    public bool isGrounded;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


void OnCollisionEnter(Collision collision)
    {

        isGrounded = true;

    }
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 targetVelocity = new Vector3(x*speed, rb.linearVelocity.y,z*speed);
        rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, targetVelocity, 0.5f);

        if(Input.GetKeyDown(KeyCode.Space)&& isGrounded)
        {
            rb.AddForce(Vector3.up* jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
