using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Transform player;

    public float moveSpeed = 5f;
    public float shootRate = 2f;
    public float shootForce = 500f;

    private float nextShootTime = 0f;

    private Rigidbody enemyRb;

    private void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Логика движения противника
        Vector3 direction = (player.position - transform.position).normalized;
        enemyRb.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);

        // Логика атаки противника
        if (Time.time > nextShootTime)
        {
            nextShootTime = Time.time + 1f / shootRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        bullet.transform.position = transform.position + transform.forward * 2f;
        bullet.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        bullet.AddComponent<Rigidbody>();
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.AddForce((player.position - transform.position).normalized * shootForce, ForceMode.Impulse);
        bulletRb.useGravity = false;

        // Уничтожение снаряда спустя 5 секунд
        Destroy(bullet.gameObject, 5f);
    }
}
