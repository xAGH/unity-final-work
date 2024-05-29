using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public Transform player;
    public float speed;
    private float lastDamege;

    void Awake() { lastDamege = -2f; }


    void Update()
    {
        if (player == null) return;

        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.Translate(speed * Time.deltaTime * direction.normalized);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Time.time - lastDamege < 2f) return;
            lastDamege = Time.time;
            Health.health --;
            if (Health.health < 0) {
                // gameOver
                Camera.main.transform.parent = null;
                collision.gameObject.SetActive(false);
            }
        }
        
    }
}
