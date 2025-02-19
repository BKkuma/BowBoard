using UnityEngine;
using System.Collections;

public class MonsterAI : MonoBehaviour
{
    public float speed = 3f;
    public float chaseSpeed = 6f;
    public float jumpForce = 5f;
    public float detectionRange = 5f;
    public Transform player;

    private Rigidbody rb;
    private bool isChasing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(RandomDirectionChange());
    }

    void Update()
    {
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
        if (player == null) return; // ถ้าไม่มีผู้เล่น ให้หยุดทำงาน

        if (isChasing)
        {
            // ✅ ไล่ตามผู้เล่น
            Vector3 direction = (player.position - transform.position).normalized;
            rb.velocity = new Vector3(direction.x * chaseSpeed, rb.velocity.y, direction.z * chaseSpeed);
        }
        else
        {
            // ✅ เดินไปมาปกติ
            rb.velocity = new Vector3(speed * (transform.localScale.x > 0 ? 1 : -1), rb.velocity.y, 0);
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
        }
        if (collision.gameObject.CompareTag("BowlingBall"))
        {
            BowlingBallHealth ballHealth = collision.gameObject.GetComponent<BowlingBallHealth>();
            if (ballHealth != null)
            {
                ballHealth.TakeDamage(1); // Monster โจมตี 1 ดาเมจ
            }
        }
    }

    IEnumerator RandomDirectionChange()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2f, 5f));
            if (!isChasing)
            {
                Flip();
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

    // ✅ แสดงระยะไล่ล่า
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }


}
