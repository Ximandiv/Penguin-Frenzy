using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{
    public AudioSource pickup;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            pickup.Play();
            new WaitForSeconds(0.2f);
            SceneManager.LoadScene(1);
        }
    }
}
