using UnityEngine;

public class PinFall : MonoBehaviour
{
    private bool hasFallen = false;

    void OnCollisionEnter(Collision collision)
    {
        if (!hasFallen && collision.gameObject.CompareTag("BowlingBall"))
        {
            GetComponent<Rigidbody>().isKinematic = false;
            hasFallen = true;

            FindObjectOfType<GameManager>().PinFallen();
        }
    }
}
