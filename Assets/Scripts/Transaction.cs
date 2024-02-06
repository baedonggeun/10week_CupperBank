using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transaction : MonoBehaviour
{
    public GameObject _transaction;
    public GameObject _main;
    public GameObject _EnterInformation;

    public GameObject _id;
    public GameObject _account;
    public GameObject _phoneNumber;
    public GameObject _popup;


    public void BeforeButton()
    {
        _main.SetActive(true);
        _transaction.SetActive(false);
    }

    public void IDButton()
    {
        _EnterInformation.SetActive(true);
        _transaction.SetActive(false);
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
