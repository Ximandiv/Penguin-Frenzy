using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpPower = 20f;
    public int amountAmmo;
    public GameObject bullets;
    public GameObject hand;
    public Transform firePoint;
    public AmmoPickup amountAmmoLocal;
    public sound gunShot;

    public float dirX;
    private bool isFacingRight;
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 23f;
    private float dashingTime = 0.2f;
    private float dashingCD = 0.5f;

    public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isDashing)
        {
            return;
        }
        dirX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Fire1") && amountAmmo > 0)
        {
            shoot();
            amountAmmo -= 1;
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            gunShot.gunshot.Play();
        }
        if (Input.GetKeyDown(KeyCode.E) && canDash)
        {
            StartCoroutine(Dash());
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void shoot()
    {
        Instantiate(bullets, firePoint.position, firePoint.rotation);
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
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

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(dirX * dashingPower, rb.velocity.y);
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCD);
        canDash = true;
    }
}
