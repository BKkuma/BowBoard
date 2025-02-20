using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public float chaseSpeed = 6f;
    public float detectionRange = 5f;
    public Transform player;
    public LayerMask obstacleMask;

    private Rigidbody rb;
    private bool isChasing = false;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        // ✅ หาตัว BowlingBall โดยอัตโนมัติ
        if (player == null)
        {
            GameObject ball = GameObject.FindGameObjectWithTag("BowlingBall");
            if (ball != null)
            {
                player = ball.transform;
            }
            else
            {
                Debug.LogError("MonsterAI: ไม่พบ BowlingBall ใน Scene!");
            }
        }
    }

    void Update()
    {
        if (player != null)
        {
            isChasing = CanSeePlayer();
        }

        MoveMonster();
    }

    void MoveMonster()
    {


        if (player == null || rb == null) return;

        if (isChasing)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            Vector3 newPosition = rb.position + direction * chaseSpeed * Time.deltaTime;
            rb.MovePosition(newPosition); // ✅ ใช้ MovePosition แทน
            Debug.Log("Monster วิ่งตาม BowlingBall!");


            // ✅ หันหน้าไปทาง BowlingBall ตลอดเวลา
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
        }

        // ✅ อัปเดต Animation
        if (anim != null)
        {
            anim.SetBool("isWalking", isChasing);
        }
    }

    bool CanSeePlayer()
    {
        if (player == null) return false;

        Vector3 direction = (player.position - transform.position).normalized;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRange)
        {
            if (!Physics.Linecast(transform.position, player.position, obstacleMask))
            {
                Debug.Log("Monster เห็น BowlingBall!");
                return true;
            }
            else
            {
                Debug.Log("มีสิ่งกีดขวางขวางระหว่าง Monster กับ BowlingBall");
            }
        }
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BowlingBall"))
        {
            // ✅ ลด HP BowlingBall
            BowlingBallHealth ballHealth = collision.gameObject.GetComponent<BowlingBallHealth>();
            if (ballHealth != null)
            {
                ballHealth.TakeDamage(1);
                Debug.Log("Monster hit BowlingBall! HP: " + ballHealth);
            }
        }
    }

}
