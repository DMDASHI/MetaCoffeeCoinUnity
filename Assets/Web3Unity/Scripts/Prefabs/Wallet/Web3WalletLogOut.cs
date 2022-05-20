using System.Collections;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Web3WalletLogOut : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern string Disconnect();

    [DllImport("__Internal")]
    private static extern void Web3Disconect();
    public void OnLogOut()
    {
         Web3Disconect();
         
         PlayerPrefs.SetString("Account", "");
         SceneManager.LoadScene(0);
    } 
}
