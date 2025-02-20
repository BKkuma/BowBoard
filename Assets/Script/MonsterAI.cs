using UnityEngine;
using System.Collections;

public class MonsterAI : MonoBehaviour
{
    public float speed = 3f;
    public float chaseSpeed = 3f;
    public float jumpForce = 5f;
    public float detectionRange = 5f;
    public Transform player;

    private Rigidbody rb;
    private bool isChasing = false;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // ✅ ตรวจสอบว่าผู้เล่นอยู่ในระยะหรือไม่
        if (player != null && Vector3.Distance(transform.position, player.position) < detectionRange)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

        MoveMonster();
    }

    void MoveMonster()
    {
        if (player == null) return;

        if (isChasing)
        {
            // ✅ ไล่ตามผู้เล่น
            Vector3 direction = (player.position - transform.position).normalized;
            rb.AddForce(new Vector3(direction.x, 0, direction.z) * chaseSpeed, ForceMode.Acceleration);

            // ✅ หันหน้าไปทาง BowlingBall
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 5f); // หมุนให้ Smooth
        }
        else
        {
            // ❌ ลบโค้ดที่ทำให้ Monster เคลื่อนที่เอง
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }

        // ✅ อัปเดต Animation
        if (anim != null)
        {
            anim.SetBool("isWalking", isChasing);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            Flip();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Flip();
        }
        else if (collision.gameObject.CompareTag("BowlingBall"))
        {
            Jump();

            // ✅ ตรวจสอบ HP และลดเลือด
            BowlingBallHealth ballHealth = collision.gameObject.GetComponent<BowlingBallHealth>();
            if (ballHealth != null)
            {
                ballHealth.TakeDamage(1);
            }
        }
    }

    void Flip()
    {
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + 180f, 0);
    }

    void Jump()
    {
        if (rb != null)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
