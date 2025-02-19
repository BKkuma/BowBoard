using UnityEngine;
using System.Collections;

public class SpeedBoost : MonoBehaviour
{
    public float boostAmount = 5f;
    public float boostDuration = 3f;
    private bool isUsed = false;

    void OnTriggerEnter(Collider other)
    {
        if (isUsed) return; // ป้องกันไม่ให้ชนแล้วทำซ้ำ  
        if (other.CompareTag("BowlingBall"))
        {
            BowlingBallController ball = other.GetComponent<BowlingBallController>();
            if (ball != null)
            {
                Debug.Log("Starting Speed Boost Coroutine");
                StartCoroutine(BoostSpeed(ball));
            }
        }
    }

    IEnumerator BoostSpeed(BowlingBallController ball)
    {
        isUsed = true; // ป้องกันการชนซ้ำ
        float originalSpeed = ball.moveSpeed;
        ball.moveSpeed += boostAmount;
        Debug.Log("Speed Boosted: " + ball.moveSpeed);

        yield return new WaitForSeconds(boostDuration);
        Debug.Log("Finished waiting for boost duration");

        if (ball != null) // ป้องกันข้อผิดพลาดถ้า BowlingBall ถูกลบ
        {
            ball.moveSpeed = originalSpeed;
            Debug.Log("Speed Reset: " + ball.moveSpeed);
        }

        Destroy(gameObject); // ทำลาย SpeedBoost หลังจากจบ Coroutine
    }
}
