using UnityEngine;

public class BowlingBallController : MonoBehaviour
{
    public float moveSpeed = 10f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0, moveZ) * moveSpeed * Time.fixedDeltaTime;
        rb.AddForce(movement, ForceMode.VelocityChange);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            rb.velocity = Vector3.zero; // หยุดการเคลื่อนที่
            rb.AddForce(-collision.contacts[0].normal * 5f, ForceMode.Impulse); // เด้งออกจากกำแพงเล็กน้อย
        }
    }



}
