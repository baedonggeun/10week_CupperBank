using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Login : CreatAccoount
{
    public GameObject _main;
    public GameObject _popupButton;
    public GameObject _loginErrorPanel;

    public InputField inputLoginID;
    public InputField inputLoginPW;


    public void LoginButton()       //로그인 버튼 클릭 시
    {
        for(int i = 0; i< inputDataList.Count; i++)
        {
            if(inputLoginID.text == inputDataList[i].inputID.text && 
                inputLoginPW.text == inputDataList[i].inputPW.text)     //리스트의 ID 와 PW 값과 입력값을 비교하여 같은 경우
            {
                _login.SetActive(false);        //login UI setactive false
                _main.SetActive(true);      //main UI setactive true
            }
        }

        //for문이 끝날 때까지 main 화면으로 넘어가지 않으면 잘못된 값이 입력된 것이므로
        //login 에러 판넬 setactive true
        _loginErrorPanel.SetActive(true);       
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
