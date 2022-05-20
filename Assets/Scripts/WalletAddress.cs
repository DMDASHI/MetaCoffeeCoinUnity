using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WalletAddress : MonoBehaviour
{
    private string address;

    public Text billetera;
    // Start is called before the first frame update
    void Start()
    {
        address = PlayerPrefs.GetString("Account");
    }

    // Update is called once per frame
    void Update()
    {
        billetera.text = address;
    }
}
