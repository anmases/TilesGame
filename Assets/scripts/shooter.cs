
using System;
using UnityEngine;

public class shooter : MonoBehaviour
{
    public GameObject bullet;
    public float force;
    public float interval;
    public float angle;
    private float timer;

    void Start()
    {
        timer = 0.0f;
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if(timer > interval)
        {
            shoot();
            timer = 0.0f;
        }
    }
    private void shoot()
    {
        float angleRad = angle * MathF.PI / 180;    //Convertimos de grados a radianes
        // x = magnitud * cos(angle)
        // y = magnitud * sin(angle)
        Vector2 direction = new Vector2(-force * Mathf.Cos(angleRad), force * Mathf.Sin(angleRad));
        GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
        newBullet.GetComponent<Rigidbody2D>().AddForce(direction, ForceMode2D.Impulse);
    }
}
