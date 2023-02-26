using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;

public class Store : MonoBehaviour
{
    public Text ScoreText;
    public Text ArrowsText;
    public Text CurrentDamage;
    public Text CurrentFov;
    public Text CurrentSpeed;
    public static Store instance;
    public CinemachineVirtualCamera Fov;
    public int TotalCoins;
    public int TotalArrows;
    public float FOV;
    public float Speed;
    public float Run;
    public float ArrowDamage;
    void Start()
    {
        instance = this;
        
        FOV = PlayerPrefs.GetFloat("FOV", 4);
        Fov.m_Lens.OrthographicSize = FOV;
        
        TotalCoins = PlayerPrefs.GetInt("Coins");

        TotalArrows = PlayerPrefs.GetInt("Arrows", 20);
        
        ArrowDamage = PlayerPrefs.GetFloat("ArrowDamage" , 1);

        Speed = PlayerPrefs.GetFloat("Speed", 5);
        Run = PlayerPrefs.GetFloat("Run", 7);
        
        ScoreText.text = TotalCoins.ToString();
    }
    public void Update()
    { 
        TotalArrows = PlayerPrefs.GetInt("Arrows", 100);
        ScoreText.text = TotalCoins.ToString();
        ArrowsText.text = TotalArrows.ToString();
    }
    // Update is called once per frame
    public void UpgradeDamage()
    {
       if(TotalCoins >= 50)
       {
           TotalCoins -= 50;
           ArrowDamage += 1;
           PlayerPrefs.SetFloat("ArrowDamage", ArrowDamage);
           GameController.instance.ShowDamage();
           PlayerPrefs.SetInt("Coins", TotalCoins);
       }
       else
       {
           GameController.instance.ShowNoMoney();
       }           
    }
    public void UpdateScoreText()
    {
        TotalCoins++;
        PlayerPrefs.SetInt("Coins", TotalCoins);
    }
    public void UpdateArrowsText()
    {
        TotalArrows--;
        PlayerPrefs.SetInt("Arrows", TotalArrows);
    }
    public void UpdateArrowsText10()
    {
        if(TotalCoins >= 5)
       {
           TotalCoins -= 5;
           TotalArrows += 10;
           PlayerPrefs.SetInt("Arrows", TotalArrows);
           PlayerPrefs.SetInt("Coins", TotalCoins);
       }
       else
       {
           GameController.instance.ShowNoMoney();
       }        
    }
        public void UpdateArrowsText100()
    {
        if(TotalCoins >= 50)
       {
           TotalCoins -= 50;
           TotalArrows += 100;
           PlayerPrefs.SetInt("Arrows", TotalArrows);
           PlayerPrefs.SetInt("Coins", TotalCoins);
       }
       else
       {
           GameController.instance.ShowNoMoney();
       }        
    }
    public void UpdateArrowsText1()
    {
        TotalArrows += 5;
        PlayerPrefs.SetInt("Arrows", TotalArrows);
    }
    public void UpdateScore100()
    {
        TotalCoins+= 100;
        PlayerPrefs.SetInt("Coins", TotalCoins);
    }
    public void UpdateDamageText()
    {
        CurrentDamage.text = ("Damage current = ") + ArrowDamage.ToString();
    }
    public void UpgradeFov()
    {
       if(TotalCoins >= 250)
       {
           TotalCoins -= 250;
           Fov.m_Lens.OrthographicSize += 1 ;
           FOV++;
           PlayerPrefs.SetFloat("FOV", Fov.m_Lens.OrthographicSize);
           GameController.instance.ShowFov();
           PlayerPrefs.SetInt("Coins", TotalCoins);
       }
       else
       {
           GameController.instance.ShowNoMoney();
       }           
    }
    public void UpdateFovText()
    {
        CurrentFov.text = ("Fov current = ") + FOV.ToString();
    }
    public void UpgradeSpeed()
    {
       if(TotalCoins >= 150)
       {
           TotalCoins -= 150;
           Speed += 1;
           Run += 1;
           PlayerPrefs.SetFloat("Run", Run);
           PlayerPrefs.SetFloat("Speed", Speed);
           GameController.instance.ShowSpeed();
           PlayerPrefs.SetInt("Coins", TotalCoins);
       }
       else
       {
           GameController.instance.ShowNoMoney();
       }
    }
    public void UpdateSpeedText()
    {
        CurrentSpeed.text = ("Speed current = ") + Speed.ToString();
    }   
}
