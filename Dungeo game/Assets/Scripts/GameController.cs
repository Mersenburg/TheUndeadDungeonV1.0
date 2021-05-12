using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public GameObject ImageF;
    public GameObject ImageE;
    public GameObject ImageFullLife;
    public GameObject ImageMaxLife;
    public GameObject NoMoney;
    public GameObject DamagePannel;
    public GameObject FovPannel;
    public GameObject SpeedPannel;
    public GameObject EnemyPannel;
    public GameObject StorePannel;
    public GameObject InstructionsPannel;
    public GameObject CollectablesPannel;
    public GameObject MechanicalPannel;
    public GameObject PausePannel;
    public GameObject OptionsPannel;
    public GameObject ControlPannel;
    public GameObject ContinuePannel;
    public GameObject DeadPannel;
    public GameObject NextLevelPannel;
    public GameObject FinalLevelPannel;
    public static GameController instance;
    public string cena;
    public string NextL;
    public string ThisLevel;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
    public void ShowImageF()
    {
        ImageF.SetActive(true);
    }
    public void unShowImageF()
    {
        ImageF.SetActive(false);
    }
    public void ShowImageE()
    {
        ImageE.SetActive(true);
    }
    public void unShowImageE()
    {
        ImageE.SetActive(false);
    }
    public void ShowImageFullLife()
    {
        ImageFullLife.SetActive(true);
    }
    public void unShowImageFullLife()
    {
        ImageFullLife.SetActive(false);
    }
    public void ShowImageMaxLife()
    {
        ImageMaxLife.SetActive(true);
    }
    public void unShowImageMaxLife()
    {
        ImageMaxLife.SetActive(false);
    }
    public void ShowEnemyPannel()
    {
        EnemyPannel.SetActive(true);
    }
    public void unShowEnemyPannel()
    {
        EnemyPannel.SetActive(false);
    }
    public void ShowStorePannel()
    {
        StorePannel.SetActive(true);
    }
    public void unShowStorePannel()
    {
        StorePannel.SetActive(false);
    }
    public void ShowMechanicalPannel()
    {
        MechanicalPannel.SetActive(true);
    }
    public void unShowMechanicalPannel()
    {
        MechanicalPannel.SetActive(false);
    }
    public void ShowCollectablesPannel()
    {
        CollectablesPannel.SetActive(true);
    }
    public void unShowCollectablesPannel()
    {
        CollectablesPannel.SetActive(false);
    }
    public void ShowPause()
    {
        PausePannel.SetActive(true);
        Time.timeScale = 0;
    }
    public void unShowPause()
    {
        PausePannel.SetActive(false);
        Time.timeScale = 1;
    }
    public void ShowOptions()
    {
        OptionsPannel.SetActive(true);
    }
    public void unShowOptions()
    {
        OptionsPannel.SetActive(false);
    }
    public void ShowInstructions()
    {
        InstructionsPannel.SetActive(true);
    }
    public void unShowInstructions()
    {
        InstructionsPannel.SetActive(false);
    }
    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(cena);
        Time.timeScale = 1;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(NextL);
        Time.timeScale = 1;
    }
    public void FinalLevel()
    {
        FinalLevelPannel.SetActive(true);
        Store.instance.UpdateScore100();
        Time.timeScale = 0;
    }
    public void ShowNextLevel()
    {
        NextLevelPannel.SetActive(true);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(ThisLevel);
        Time.timeScale = 1;
    }
    public void ShowControls()
    {
        ControlPannel.SetActive(true);
    }
    public void unShowControls()
    {
        ControlPannel.SetActive(false);
    }
    public void ShowContinue()
    {
        ContinuePannel.SetActive(true);
    }
    public void unShowContinue()
    {
        ContinuePannel.SetActive(false);
    }
    public void ShowNoMoney()
    {
        NoMoney.SetActive(true);
    }
    public void unShowNoMoney()
    {
        NoMoney.SetActive(false);
    }
    public void ShowDamage()
    {
        DamagePannel.SetActive(true);
        Store.instance.UpdateDamageText();
    }
    public void unShowDamage()
    {
        DamagePannel.SetActive(false);
    }
    public void ShowFov()
    {
        FovPannel.SetActive(true);
        Store.instance.UpdateFovText();
    }
    public void unShowFov()
    {
        FovPannel.SetActive(false);
    }
    public void ShowSpeed()
    {
        SpeedPannel.SetActive(true);
        Store.instance.UpdateSpeedText();
    }
    public void unShowSpeed()
    {
        SpeedPannel.SetActive(false);
    }
    public void ShowDead()
    {
        DeadPannel.SetActive(true);
    }
    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Menu");
    }
}
