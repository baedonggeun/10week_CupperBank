using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

[System.Serializable]
public class InputData
{
    public string inputName;        //이름
    public string inputAccount;     //CupperBank 계좌
    public string inputPhone;       //핸드폰 번호
    public string inputEMail;       //Email 주소
}

public class CreatAccoount : MonoBehaviour
{
    [HideInInspector] protected InputData inputData = new InputData();

    public GameObject _createAccount;
    public GameObject _login;
    public GameObject _errorPanel;

    [SerializeField] private InputField inputName;
    [SerializeField] private InputField inputID;
    [SerializeField] private InputField inputPW;
    [SerializeField] private InputField inputPWConfirm;
    [SerializeField] private InputField inputAccount;
    [SerializeField] private InputField inputPhone;
    [SerializeField] private InputField inputEmail;


    public void FinishButton()      //finish 버튼 눌렀을 때 실행
    {
        if (PlayerPrefs.HasKey(inputID.text + "_ID"))       //아이디 키 값이 존재할 경우
        {
            _errorPanel.SetActive(true);        //에러 panel active true
        }

        if (inputPW.text != inputPWConfirm.text)     //입력된 정보의 PW 와 PWConfirm 같지 않을 경우
        {
            _errorPanel.SetActive(true);        //에러 panel active true
        }

        if (inputID.text.Length < 3 || inputID.text.Length > 10)     //ID 3~10글자 제한
            _errorPanel.SetActive(true);        //에러 panel active true

        if (inputPW.text.Length < 5 || inputPW.text.Length > 15)     //PW 5~15글자 제한
            _errorPanel.SetActive(true);        //에러 panel active true


        //에러 panel active false 일 경우, 이상 없으므로 정보 리스트에 저장 후 로그인 화면으로 돌아김
        if (_errorPanel.activeSelf == false)
        {
            InputInformation();
            _createAccount.SetActive(false);
            _login.SetActive(true);
        }

    }

    public void InputInformation()      //효율적인 정보 처리를 위해 입력 받은 값을 json으로 저장
    {
        inputData.inputName = inputName.text;
        inputData.inputAccount = inputAccount.text;
        inputData.inputPhone = inputPhone.text;
        inputData.inputEMail = inputEmail.text;

        string json = JsonUtility.ToJson(inputData);

        PlayerPrefs.SetString(inputID.text + "_ID", json);
        PlayerPrefs.SetString(inputID.text + "_PW", inputPW.text);

    }


    public void PanelRetryButton()      //panel 끄는 버튼
    {
        _errorPanel.SetActive(false);
    }

}
