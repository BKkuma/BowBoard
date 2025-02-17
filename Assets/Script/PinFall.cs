using UnityEngine;

public class PinFall : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BowlingBall"))
        {
            GetComponent<Rigidbody>().isKinematic = false; // ทำให้พินล้มได้
        }
    }
}
