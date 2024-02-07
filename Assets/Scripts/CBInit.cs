using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CBInit : MonoBehaviour
{
    public GameObject _CBInitUI;
    public GameObject _CBLoginUI;

    public CBInitLoading loading;

    float time = 0f;
    void Update()
    {
        if(loading == null) 
        {
            return;
        }

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
