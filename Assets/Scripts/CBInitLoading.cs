using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CBInitLoading : MonoBehaviour
{
    
    [HideInInspector] public float curLoading = 0f;       //현재 게이지
    [HideInInspector] public float maxLoading = 1f;       //최대 게이지
    public Image uiBar;     //UI Bar 이미지
    public TextMeshProUGUI loadingText;        //UI Loading Text

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
