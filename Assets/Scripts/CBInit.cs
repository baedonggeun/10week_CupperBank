using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Loading        //로딩 게이지
{
    [HideInInspector]
    public float curLoading = 0f;       //현재 게이지
    public float maxLoading = 1f;       //최대 게이지
    public Image uiBar;     //UI Bar 이미지
    public TextMeshProUGUI loadingText;        //UI Loading Text

    private Coroutine coroutine;

    public float RandAddRate()      //0~0.3f의 임의의 값 생성
    {
        float randN = Random.Range(0f, 0.5f);

        return randN;
    }

    public void LoadingIncrease(float added)        //로딩 게이지 증가값
    {
        curLoading += added;
    }

    public float GetPercentage()        //로딩 비율
    {
        return curLoading / maxLoading;
    }
}


public class CBInit : MonoBehaviour
{
    public GameObject _CBInitUI;
    public GameObject _CBLoginUI;

    public Loading loading;

    float time = 0f;

    void Update()
    {
        time += Time.deltaTime;

        if (loading.curLoading < 1f)       //현재 게이지가 1보다 작다면
        {
            if (time >= 1f)
            {
                loading.LoadingIncrease(loading.RandAddRate() * time);      //시간에 따라 값 증가
                loading.loadingText.text = (loading.curLoading * 100).ToString("N0");     //로딩 게이지 text 업데이트
                time = 0f;
            }
        }
        else if (loading.curLoading >= 1f)     //현재 게이지가 1과 같거나 크다면
        {
            if(time >= 1f)
            {
                loading.curLoading = loading.maxLoading;       //현재 게이지를 최대 게이지 값으로 고정
                loading.loadingText.text = (loading.maxLoading * 100).ToString("N0");     //로딩 게이지 text 업데이트
            }
            
            CBInitFunction();       //로그인 화면으로 화면 전환
        }
        
        loading.uiBar.fillAmount = loading.GetPercentage();       //현재 게이지에 따라 loading bar 이미지 업데이트
    }

    void CBInitFunction()       //Init UI 끄고 Login UI 킴
    {
        _CBInitUI.SetActive(false);
        _CBLoginUI.SetActive(true);
    }
}
