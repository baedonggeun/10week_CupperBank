using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject _transaction;
    public GameObject _main;

    public GameObject _accountInquiry;
    public GameObject _utilityBills;
    public GameObject _loans;
    public GameObject _savings;
    public GameObject _deposit;
    public GameObject _withdrawal;
    public GameObject _treanfer;
    public GameObject _foreignCurrencyExchange;
    public GameObject _popup;

    protected bool deposit = false;
    protected bool withdrawal = false;
    protected bool transfer = false;

    public void DepositButton()
    {
        _main.SetActive(false);
        _transaction.SetActive(true);
        deposit = true;
    }

    public void WithdrawalButton()
    {
        _main.SetActive(false);
        _transaction.SetActive(true);
        withdrawal = true;
    }
    public void TransferButton()
    {
        _main.SetActive(false);
        _transaction.SetActive(true);
        transfer = true;
    }

    public void AccountInquiryButton()
    {
        _main.SetActive(false);
        _accountInquiry.SetActive(true);
    }

    public void Unimplemented()
    {
        _popup.SetActive(true);
    }

    public void PopupButton()
    {
        _popup.SetActive(false);
    }

    public void BooleanInitialize()
    {
        deposit = false;
        withdrawal = false;
        transfer = false;
    }

}
