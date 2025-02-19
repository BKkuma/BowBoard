using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public float speed = 3f;
    private bool movingRight = true;

    void Update()
    {
        if (movingRight)
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        else
            transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            movingRight = !movingRight;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            movingRight = !movingRight;
        }
    }

}
