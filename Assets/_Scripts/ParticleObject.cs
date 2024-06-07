
using UnityEngine;

public class ParticleObject : MonoBehaviour
{
    Vector3[] directions = {
        Vector3.left * 5,
        Vector3.right * 5,
        Vector3.up * 5,
        Vector3.down * 5
    };
    public void direction(int i)
    {
         Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = directions[i];
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        other.gameObject.GetComponent<ICollision>()?.HandleCollision(transform);
        Destroy(gameObject);
    }
    
}
