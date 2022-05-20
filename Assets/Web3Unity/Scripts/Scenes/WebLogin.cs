using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WebLogin : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Web3Connect();

    [DllImport("__Internal")]
    private static extern string ConnectAccount();

    [DllImport("__Internal")]
    private static extern void SetConnectAccount(string value);

    private int expirationTime;
    private string account; 

    public void OnLogin()
    {
#if UNITY_WEBGL
        Web3Connect();
#endif
        OnConnected();
    }

    async private void OnConnected()
    {
#if UNITY_WEBGL
        account = ConnectAccount();

        while (account == "") {
            await new WaitForSeconds(1f);
            account = ConnectAccount(); 
        };
#else
        account = PlayerPrefs.GetString("Account");
#endif
        // save account for next scene
        PlayerPrefs.SetString("Account", account);
        // reset login message 
        
        // load next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        //SetConnectAccount(""); 
    }

    public void OnSkip()
    {
        // burner account for skipped sign in screen
        PlayerPrefs.SetString("Account", "");
        // move to next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

