using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpPower;
    public int amountAmmo;
    public GameObject bullets;
    public GameObject hand;
    public Transform firePoint;
    public AmmoPickup amountAmmoLocal;
    public sound gunShot;

    public float dirX;
    private bool isFacingRight;

    public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        int amountAmmoLocal1 = amountAmmoLocal.amountAmmo;
    }

    private void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Fire1") && amountAmmo > 0)
        {
            shoot();
            amountAmmo -= 1;
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            gunShot.gunshot.Play();
        }
        
    }

    private void shoot()
    {
        Instantiate(bullets, firePoint.position, firePoint.rotation);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        Flip();
    }

    public void Flip()
    {
        if (isFacingRight && dirX > 0f || !isFacingRight && dirX < 0f)
        {
            isFacingRight = !isFacingRight;

            transform.Rotate(0f, 180f, 0f);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ammo")
        {
            amountAmmo += 1;
            Destroy(collision.gameObject);
        }
    }
}
