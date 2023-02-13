using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flip : MonoBehaviour
{
    // Define the starting position of the gun
    Vector2 startingPosition;
    public PlayerController player;

    void Start()
    {
        startingPosition = transform.position;
    }

    private void Update()
    {
        FlipFiringPoint();
    }

    public void FlipFiringPoint()
    {
        // Change the position of the gun to the opposite side
        Vector2 newPosition = new Vector2(startingPosition.x * -1, startingPosition.y);
        transform.position = newPosition;
        // Rotate the gun to face the right or left side
        if (player.dirX > 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if(player.dirX < 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
    }
}
