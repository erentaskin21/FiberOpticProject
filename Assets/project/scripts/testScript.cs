using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class testScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClickAtla()
    {
        Debug.Log("basildi");
        SceneManager.LoadScene("Menu");
    }


}
