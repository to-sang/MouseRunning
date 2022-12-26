using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackController : MonoBehaviour
{
    public void BtnClick()
    {
        SceneManager.LoadScene("Start Screen");
    }
    public void BtnTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
