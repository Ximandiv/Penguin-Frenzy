using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anima : MonoBehaviour
{
    public Animator Animation;
    public PlayerController player;

    private void Start()
    {
        Animation = GetComponent<Animator>();
    }

    private enum animations
    {
        idle, shot
    }

    public void animationUpdate1()
    {
        animations state;
        if (player.shooting)
        {
            state = animations.shot;
            player.shooting = false;
        }
        else
        {
            state = animations.idle;
        }

        Animation.SetInteger("state", (int)(state));
    }
}
