using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

[System.Serializable]
public class TransactionData
{
    public string Name;        //이름
    public string Account;     //CupperBank 계좌
    public string Phone;       //핸드폰 번호
    public string EMail;       //Email 주소
    public string accountBalance;     //계좌에 들어있는 금액
    public string Holdings;      //계좌 소유주가 가지고 있는 금액
}

public class EnterInformation : Main
{
    public GameObject _enterInformation;

    public GameObject _failedPanel;
    public GameObject _successPanel;

    public GameObject _id;
    public GameObject _amountOfMoney;

    public InputField inputID;
    public InputField inputAmountOfMoney;

    public TextMeshProUGUI successPanelText;
    public TextMeshProUGUI failedPanelText;

    public TextMeshProUGUI successAccountIDText;
    public TextMeshProUGUI successAmountOfMoneyText;
    public TextMeshProUGUI balanceText;

    TransactionData transactionData = new TransactionData();

    string keyID;
    string details;

    public void BeforeButton()
    {
        _main.SetActive(true);
        _enterInformation.SetActive(false);

        BooleanInitialize();
    }

    public void DoneButton()
    {
        PanelTextChanger();

        if(base.deposit)        //입금
        {
            if(CheckIDForCorrect(inputID.text))     //레지스트리에 있는 아이디므로 입금 시작
            {
                int alreadyHaveAccountBalance = int.Parse(transactionData.accountBalance);
                int holdingsMoney = int.Parse(transactionData.Holdings);
                int depositMoney = int.Parse(inputAmountOfMoney.text);

                if(holdingsMoney < depositMoney)        //입금하려는 돈보다 가지고 있는 돈이 적으면 입금 불가
                {
                    _failedPanel.SetActive(true);
                }
                else        //입력받은 금액 만큼 계좌 잔액 추가 및 가지고 있는 돈 감소
                {
                    transactionData.accountBalance = (alreadyHaveAccountBalance + depositMoney).ToString();
                    transactionData.Holdings = (holdingsMoney - depositMoney).ToString();

                    JsonDataSave(inputID.text);

                    successAccountIDText.text = inputID.text;
                    successAmountOfMoneyText.text = inputAmountOfMoney.text;
                    balanceText.text = transactionData.accountBalance;
                    _successPanel.SetActive(true);
                }

            }
            else        //레지스트리에 없는 아이디이므로 입금 불가 및 판넬 active true
            {
                _failedPanel.SetActive(true);
            }
        }
        else if (base.withdrawal)
        {
            if (CheckIDForCorrect(inputID.text))     //레지스트리에 있는 아이디므로 출금 시작
            {
                int alreadyHaveAccountBalance = int.Parse(transactionData.accountBalance);
                int holdingsMoney = int.Parse(transactionData.Holdings);
                int withdrawalMoney = int.Parse(inputAmountOfMoney.text);

                if (holdingsMoney < withdrawalMoney)        //출금하려는 돈보다 계좌 잔액이 적으면 출금 불가
                {
                    _failedPanel.SetActive(true);
                }
                else        //입력받은 금액 만큼 계좌 잔액 감소 및 가지고 있는 돈 증가
                {
                    transactionData.accountBalance = (alreadyHaveAccountBalance - withdrawalMoney).ToString();
                    transactionData.Holdings = (holdingsMoney + withdrawalMoney).ToString();

                    JsonDataSave(inputID.text);

                    successAccountIDText.text = inputID.text;
                    successAmountOfMoneyText.text = inputAmountOfMoney.text;
                    balanceText.text = transactionData.accountBalance;
                    _successPanel.SetActive(true);
                }

            }
            else        //레지스트리에 없는 아이디이므로 출금 불가 및 판넬 active true
            {
                _failedPanel.SetActive(true);
            }
        }
        else if(base.transfer)
        {

        }
        

    }

    public void SuccessConfirmButton()
    {
        _main.SetActive(true);
        _enterInformation.SetActive(false);

        BooleanInitialize();
    }

    public void FailedTryAgainButton()
    {
        _failedPanel.SetActive(false);
    }
    public void FailedGoToMainButton()
    {
        _main.SetActive(true); 
        _enterInformation.SetActive(false);

        BooleanInitialize();
    }

    public void PanelTextChanger()
    {
        if (base.deposit)
        {
            successPanelText.text = "Deposit";
            failedPanelText.text = "Deposit";
        }
        else if(base.withdrawal)
        {
            successPanelText.text = "Withdrawal";
            failedPanelText.text = "Withdrawal";
        }
        else if(base.transfer)
        {
            successPanelText.text = "Transfer";
            failedPanelText.text = "Transfer";
        }
    }

    public bool CheckIDForCorrect(string inputID)       //입력한 아이디가 레지스트리에 있으면 true 없으면 false 반환
    {
        string checkID;

        if (PlayerPrefs.HasKey(inputID + "_ID"))        //inputID 레지스트리에 있으면 값을 받아옴
        {
            checkID = PlayerPrefs.GetString(inputID) + "_ID";

            keyID = checkID;
            details = PlayerPrefs.GetString(keyID);      //details에 keyID를 키로 갖는 값을 덮어씀
            transactionData = JsonUtility.FromJson<TransactionData>(details);       //details의 json을 accountData 오브젝트로 전환

            return true;
        }
        else { return false; }
    }

    public void JsonDataSave(string inputID)
    {
        string toJson = JsonUtility.ToJson(transactionData);

        PlayerPrefs.SetString(inputID + "_ID", toJson);

    }
}
