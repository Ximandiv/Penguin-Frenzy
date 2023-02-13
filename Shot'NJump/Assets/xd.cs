using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xd : MonoBehaviour
{
    public PlayerController player;
    void Update()
    {
        if (player.dirX < 0)
        {
            transform.Rotate(0, 180, 0);
        }
        if (player.dirX > 0)
        {
            transform.Rotate(0, 0, 0);
        }
    }
}
