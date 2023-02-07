using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sys : MonoBehaviour
{
    public PlayerController xd;
    public Text text;
    private string bruh;
    private int bruh2;
    private void Update()
    {
        bruh2 = xd.amountAmmo;
        bruh = bruh2.ToString();
        text.text = "x" + bruh;
    }
}
