using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Transform player;
    public float speed;
    private float health = 30;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, transform.position - player.position, speed * Time.deltaTime, 0.0f));
    }

    public void TakeDamage(int damage) {
        health -= damage;
        Debug.Log("Took Damage");

        if (health <= 0) {
            die();
        }
    }

    private void die() {
        Destroy(gameObject);
    }
}
