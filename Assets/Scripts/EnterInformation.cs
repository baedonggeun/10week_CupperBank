using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    

    public void BeforeButton()
    {
        _main.SetActive(true);
        _enterInformation.SetActive(false);

        BooleanInitialize();
    }

    public void DoneButton()
    {
        PanelTextChanger();
        if(base.deposit || base.transfer)
        {
            //if id 존재
            //    금액 추가
            //    성공판넬
            //    존재x
            //    실패판넬
        }
        else if(base.withdrawal)
        {
            //if id 존재
            //    계좌 잔액 amount of money 보다 큼
            //    계좌 잔액 감소
            //    성공판넬
            //    둘 중 하나라도 안 맞으면
            //    실패판넬
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
}
