using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpPower = 20f;
    public int amountAmmo;
    public GameObject bullets;
    public GameObject hand;
    public Transform firePoint;
    public sound gunShot;
    public AudioSource pickupAmmo;
    public anima anima;
    public bool shooting = false;

    public float dirX;
    public float recoilForce;
    public bool isFacingRight;
    private bool canShoot = true;
    private bool canDash = true;
    private bool isDashing;
    private bool isShooting;
    public float dashingPower = 23f;
    private float dashingTime = 0.2f;
    private float shootingTime = 0.3f;
    private float dashingCD = 0.5f;

    public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        if (isDashing)
        {
            return;
        }
        if (isShooting)
        {
            return;
        }
        dirX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Fire1") && amountAmmo > 0)
        {
            if(canShoot == true)
            {
                StartCoroutine(shoot());
                shooting = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && canDash)
        {
            StartCoroutine(Dash());
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
        anima.animationUpdate1();
    }

    private IEnumerator shoot()
    {
        canShoot = false;
        isShooting = true;
        gunShot.gunshot.Play();
        Instantiate(bullets, firePoint.position, firePoint.rotation);
        amountAmmo -= 1;
        Vector2 direction = (Vector2)transform.position - (Vector2)firePoint.position;
        direction = direction.normalized;
        rb.AddForce(direction * recoilForce);
        yield return new WaitForSeconds(shootingTime);
        isShooting = false;
        canShoot = true;
    }



    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        if (isShooting)
        {
            return;
        }
        rb.velocity = new Vector2(dirX * moveSpeed * Time.deltaTime, rb.velocity.y);
        Flip();
    }

    public void Flip()
    {
        if (dirX > 0f && isFacingRight || dirX < 0f && !isFacingRight)
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0, 180, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ammo")
        {
            amountAmmo += 3;
            Destroy(collision.gameObject);
            pickupAmmo.Play();
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
