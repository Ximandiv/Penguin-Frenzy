using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotgun : MonoBehaviour
{
    Vector3 mousePosition;
    [SerializeField] private Camera mainCamera;
    private int direction = 1;
    public SpriteRenderer shotgunSprite;
    void Start()
    {

    }

    void Update()
    {
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            direction = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction = 1;
        }
        if ((mousePosition.x > transform.position.x && direction > 0)
            )
        {
            transform.right = mousePosition - transform.position;
            shotgunSprite.flipY = false;



        }
        else
        {

            if ((mousePosition.x < transform.position.x && direction < 0))
            {
                transform.right = (mousePosition - transform.position);
                shotgunSprite.flipY = true;


            }
        }
    }
}
