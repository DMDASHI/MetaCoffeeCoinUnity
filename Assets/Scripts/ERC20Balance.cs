using System.Collections;
using System.Numerics;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ERC20Balance : MonoBehaviour
{
    private string account;

    private string chain = "binance";

    private string network = "testnet";

    private string contract = "0x58ac157b0Afb84A501E4E40A09336de66E6adE48";

    public Text balance;

    void Start()
    {
        account = PlayerPrefs.GetString("Account");



        //print(balanceOf);
    }


    // Update is called once per frame
    async void Update()
    {
        BigInteger balanceOf = await ERC20.BalanceOf(chain, network, contract, account);

        string balancecad = balanceOf.ToString();

        balance.text = balancecad.Substring(0, balancecad.Length - 18) + "." + balancecad.Substring(balancecad.Length - 18, 2) + " MTFs";
    }
}
