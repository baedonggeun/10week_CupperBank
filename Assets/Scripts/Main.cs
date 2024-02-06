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

    public void TransactionButton()
    {
        _main.SetActive(false);
        _transaction.SetActive(true);
    }



    public void Unimplemented()
    {
        _popup.SetActive(true);
    }

    public void PopupButton()
    {
        _popup.SetActive(false);
    }



}
