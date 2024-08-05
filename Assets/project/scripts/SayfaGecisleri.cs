using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SayfaGecisleri : MonoBehaviour
{
    public void Start()
    {
        SceneManager.LoadScene("start");  
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Register()
    {
        SceneManager.LoadScene("Register");
    }

    public void Giris()
    {
        SceneManager.LoadScene("Giris");
    }

}
