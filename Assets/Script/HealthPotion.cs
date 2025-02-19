using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public int healAmount = 1;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BowlingBall"))
        {
            BowlingBallHealth ballHealth = other.GetComponent<BowlingBallHealth>();
            if (ballHealth != null)
            {
                ballHealth.Heal(healAmount);
                Destroy(gameObject); // ขวดเลือดหายไปเมื่อเก็บ
            }
        }
    }
}
