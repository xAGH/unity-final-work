using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFollower : MonoBehaviour
{
    private Transform player;
    public float speed;
    private float lastDamege;

    void Awake() {
        lastDamege = -2f;
    }

    void Update()
    {
        if (player == null) {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        };

        Vector2 direction = player.transform.position - transform.position;
        transform.Translate(speed * Time.deltaTime * direction.normalized);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Time.time - lastDamege < 2f) return;
            lastDamege = Time.time;
            Health.health --;
            if (Health.health < 0) {
                Camera.main.transform.parent = null;
                collision.gameObject.SetActive(false);
                SceneManager.LoadScene("CharacterSelector", LoadSceneMode.Single);
            }
        }
        
    }
}
