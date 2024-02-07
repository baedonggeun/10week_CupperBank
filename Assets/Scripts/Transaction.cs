using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transaction : Main
{
    
    public GameObject _enterInformation;
    public GameObject _id;
    public GameObject _account;
    public GameObject _phoneNumber;
    public GameObject _transactionpopup;


    public void BeforeButton()
    {
        _main.SetActive(true);
        _transaction.SetActive(false);

        BooleanInitialize();
    }

    public void IDButton()
    {
        _enterInformation.SetActive(true);
        _transaction.SetActive(false);
    }

    public void TransactionUnimplemented()
    {
        _transactionpopup.SetActive(true);
    }

    public void TransactionPopupButton()
    {
        _transactionpopup.SetActive(false);
    }


}
