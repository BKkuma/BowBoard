using UnityEngine;

public class BowlingBallController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 100f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal"); // A, D
        float moveZ = Input.GetAxis("Vertical");   // W, S

        Vector3 movement = new Vector3(moveX, 0, moveZ) * moveSpeed * Time.fixedDeltaTime;

        rb.AddForce(movement, ForceMode.VelocityChange); // ใช้ฟิสิกส์ในการขยับลูกโบว์ลิ่ง
    }
}
