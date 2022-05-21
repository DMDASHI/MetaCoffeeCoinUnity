using System.Collections;
using System.Numerics;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Web3.Operations
{
    public class ERC20Balance : MonoBehaviour
    {
        private string account;

        private readonly string chain = "binance";

        private readonly string network = "testnet";

        private readonly string contract = "0x58ac157b0Afb84A501E4E40A09336de66E6adE48";

        public Text balance;

        void Start()
        {
            account = PlayerPrefs.GetString("Account");
            ShowBalance();
        }

        async private void ShowBalance()
        {
            BigInteger balanceOf = await ERC20.BalanceOf(chain, network, contract, account);
            string balancecad = balanceOf.ToString();
            string symbol = await ERC20.Symbol(chain, network, contract);
            balance.text = balancecad.Substring(0, balancecad.Length - 18) + "." + balancecad.Substring(balancecad.Length - 18, 2) + " " + symbol;
        }
    }

}
