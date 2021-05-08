using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    public void Lvl1()
    {
        SceneManager.LoadScene("lvl1");
    }
    public void Lvl2()
    {
        SceneManager.LoadScene("lvl2");
    }
    public void Lvl3()
    {
        SceneManager.LoadScene("lvl3");
    }
    public void Lvl4()
    {
        SceneManager.LoadScene("lvl4");
    }
    public void Lvl5()
    {
        SceneManager.LoadScene("lvl5");
    }
}
