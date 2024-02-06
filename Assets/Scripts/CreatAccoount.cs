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
    public InputField inputName;        //이름
    public InputField inputID;      //ID
    public InputField inputPW;      //PW
    public InputField inputPWConfirm;       //PW 확인
    public InputField inputAccount;     //CupperBank 계좌
    public InputField inputPhone;       //핸드폰 번호
    public InputField inputEMail;       //Email 주소
}


public class CreatAccoount : MonoBehaviour
{
    List<InputData> inputDataList = new List<InputData>();
    public InputData inputData;

    public GameObject _createAccount;
    public GameObject _login;
    public GameObject _errorPanel;


    public void InputInformation()      //정보 처리를 위해 임시 저장
    {
        PlayerPrefs.SetString("ID" + inputDataList.Count, inputData.inputID.text);
        PlayerPrefs.SetString("Name" + inputDataList.Count, inputData.inputName.text);
        PlayerPrefs.SetString("PW" + inputDataList.Count, inputData.inputPW.text);
        PlayerPrefs.SetString("Account" + inputDataList.Count, inputData.inputAccount.text);
        PlayerPrefs.SetString("Phone" + inputDataList.Count, inputData.inputPhone.text);
        PlayerPrefs.SetString("E_Mail" + inputDataList.Count, inputData.inputEMail.text);
    }

    public void InformationSave()       //리스트에 입력받은 정보 저장
    {
        inputDataList.Add(inputData);
    }


    public void FinishButton()      //finish 버튼 눌렀을 때 실행
    {
        InputInformation();

        for (int i = 0; i< inputDataList.Count; i++)        //리스트에 있는 정보와 비교하여
        {
            if(inputData.inputID == inputDataList[i].inputID)       //임시 정보의 ID와 리스트의 ID가 같은 경우
            {
                _errorPanel.SetActive(true);        //에러 panel active true
            }
        }

        if(inputData.inputPW.text != inputData.inputPWConfirm.text)     //임시 정보의 PW 와 PWConfirm 같지 않을 경우
        {
            _errorPanel.SetActive(true);        //에러 panel active true
        }

        if(inputData.inputID.text.Length < 3 || inputData.inputID.text.Length > 10)     //ID 3~10글자 제한
            _errorPanel.SetActive(true);        //에러 panel active true

        if(inputData.inputPW.text.Length < 5 || inputData.inputPW.text.Length > 15)     //PW 5~15글자 제한
            _errorPanel.SetActive(true);        //에러 panel active true


        //에러 panel active false 일 경우, 이상 없으므로 정보 리스트에 저장 후 로그인 화면으로 돌아김
        if (_errorPanel.activeSelf == false)
        {
            InformationSave();
            _createAccount.SetActive(false);
            _login.SetActive(true);
        }
            
    }

    public void PanelRetryButton()      //panel 끄는 버튼
    {
        _errorPanel.SetActive(false);
    }

}
