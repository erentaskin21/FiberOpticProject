using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuscripts : MonoBehaviour
{
    public void OnClickGiris()
    {
        Debug.Log("Basildi");
        SceneManager.LoadScene("Giris");
    }

    public void OnClickKayit()
    {
        Debug.Log("Basildi");
        SceneManager.LoadScene("Register");
    }
}
