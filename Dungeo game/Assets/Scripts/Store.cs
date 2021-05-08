using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;

public class Store : MonoBehaviour
{
    public Text ScoreText;
    public Text CurrentDamage;
    public Text CurrentFov;
    public Text CurrentSpeed;
    public static Store instance;
    public CinemachineVirtualCamera Fov;
    public int TotalCoins;
    public float FOV;
    public float Speed;
    public float Run;
    public float ArrowDamage;
    void Start()
    {
        instance = this;
        
        FOV = PlayerPrefs.GetFloat("FOV", 7);
        Fov.m_Lens.OrthographicSize = FOV;
        
        TotalCoins = PlayerPrefs.GetInt("Coins");
        
        ArrowDamage = PlayerPrefs.GetFloat("ArrowDamage" , 1);

        Speed = PlayerPrefs.GetFloat("Speed", 5);
        Run = PlayerPrefs.GetFloat("Run", 7);
        
        ScoreText.text = TotalCoins.ToString();
    }
    public void Update()
    { 
        ScoreText.text = TotalCoins.ToString();
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
