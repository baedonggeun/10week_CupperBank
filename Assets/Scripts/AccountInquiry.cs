using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[System.Serializable]
public class AccountData
{
    public string Name;        //이름
    public string Account;     //CupperBank 계좌
    public string Phone;       //핸드폰 번호
    public string EMail;       //Email 주소
    public string accountBalance;     //계좌에 들어있는 금액
    public string Holdings;      //계좌 소유주가 가지고 있는 금액
}

public class AccountInquiry : Login
{
    public GameObject _accountInquiry;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI idText;
    public TextMeshProUGUI accountText;
    public TextMeshProUGUI phoneText;
    public TextMeshProUGUI emailText;
    public TextMeshProUGUI accountBalanceText;
    public TextMeshProUGUI holdingsText;

    AccountData accountData = new AccountData();

    string keyID;
    string details;

    private void Start()
    {
        if(_accountInquiry.activeSelf == true)
            OverwriteData();
    }


    public void OverwriteData()
    {
        keyID = base.inputLoginID.text + "_ID";
        details = PlayerPrefs.GetString(keyID);      //details에 keyID를 키로 갖는 값을 덮어씀
        accountData = JsonUtility.FromJson<AccountData>(details);       //details의 json을 accountData 오브젝트로 전환
        //JsonUtility.FromJsonOverwrite(details, accountData);        //details Json으로 accountData 클래스 덮어씀

        //accountData의 값들을 text에 넣어 디스플레이
        nameText.text = accountData.Name;
        idText.text = inputLoginID.text;
        accountText.text = accountData.Account;
        phoneText.text = accountData.Phone;
        emailText.text = accountData.EMail;
        accountBalanceText.text = accountData.accountBalance;
        holdingsText.text = accountData.Holdings;
    }

    public void BeforeButton()
    {
        _accountInquiry.SetActive(false);
        _main.SetActive(true);
    }


}
