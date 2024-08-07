using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SayfaGecisleri : MonoBehaviour
{
    public void Start()
    {
        //  SceneManager.LoadScene("Start");  
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


    public void OnClickKayitOl()
    {
        if(!CheckSifre() || !CheckIsim() || !CheckTc())
        {
            //uyarý ver hatalý giriþ
        }
        else
        {
            //aferin
        }
    }

    public bool CheckTc()
    {
        string tc = "";
        if(string.IsNullOrEmpty(tc))
        {
            return false;
        }
        return true;

    }



    public bool CheckIsim()
    {
        return true;

    }


    public bool CheckSifre()
    {
        return true;


    }
}
