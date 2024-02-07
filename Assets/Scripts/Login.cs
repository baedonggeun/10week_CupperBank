using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Login : MonoBehaviour
{
    public GameObject _main;
    public GameObject _login;
    public GameObject _createAccount;
    public GameObject _popupButton;
    public GameObject _loginErrorPanel;

    [SerializeField] protected InputField inputLoginID;
    [SerializeField] protected InputField inputLoginPW;


    public void LoginButton()       //로그인 버튼 클릭 시
    {
        string compareIDKey = inputLoginID.text + "_ID";
        string comparePWKey = inputLoginPW.text;

        if(PlayerPrefs.HasKey(compareIDKey))     //입력된 ID가 레지스트리에 존재한다면(회원가입이 되어 있다면)
        {
            if (comparePWKey == PlayerPrefs.GetString(inputLoginID.text + "_PW"))        //입력된 PW가 회원가입 시 입력한 PW와 같다면
            {
                _login.SetActive(false);        //login UI setactive false
                _main.SetActive(true);      //main UI setactive true
            }
            else
            {
                _loginErrorPanel.SetActive(true);       //login 에러 판넬 setactive true
            }
        }
        else
        {
            _loginErrorPanel.SetActive(true);       //login 에러 판넬 setactive true
        }
    }

    public void ErrorPanelButton()      //error 판넬 버튼 클릭 시 
    {
        _loginErrorPanel.SetActive(false);      //판넬 setactive false
    }

    public void CreatAccountButton()        //회원가입 버튼 클릭 시
    {
        _login.SetActive(false);        //login UI setactive false
        _createAccount.SetActive(true);     //createaccount UI setactive true
    }

    public void PopupButton()       //popup 창의 버튼 클릭 시 
    {
        _popupButton.SetActive(false);      //popup setactive false
    }

    public void FindButton()        //findID or findPW 버튼 클릭 시
    {
        _popupButton.SetActive(true);       //미구현으로 인해 popup창 setactive true

    }
}
