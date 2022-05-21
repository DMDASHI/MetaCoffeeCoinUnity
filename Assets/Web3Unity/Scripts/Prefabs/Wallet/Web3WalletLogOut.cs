using System.Collections;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Web3.Operations
{
    public class Web3WalletLogOut : MonoBehaviour
    {

        public void OnLogOut()
        {

            PlayerPrefs.SetString("Account", "");
            SceneManager.LoadScene(0);
        }
    }
}
