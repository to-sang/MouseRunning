using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    private Button[] buttonList;
    private int curLv;
    // Start is called before the first frame update
    void Start()
    {
        buttonList = GetComponentsInChildren<Button>();
        curLv = int.Parse(System.IO.File.ReadAllLines("data.txt")[0]);
        Debug.Log(curLv + " " + buttonList.Length);
        for (int i = 0; i < curLv - 1; i++)
        {
            buttonList[i].enabled = true;
            buttonList[i].image.color = Color.green;
        }
        buttonList[curLv - 1].enabled = true;
        buttonList[curLv - 1].image.color = Color.white;
        for (int i = curLv; i < buttonList.Length - 1; i++)
        {
            buttonList[i].enabled = false;
            buttonList[i].image.color = Color.gray;
        }
    }

    public void Btn0Click()
    {
        SceneManager.LoadScene("Start Screen");
    }

    public void Btn1Click()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Btn2Click()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void Btn3Click()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void Btn4Click()
    {
        SceneManager.LoadScene("Level 4");
    }

    public void Btn5Click()
    {
        SceneManager.LoadScene("Level 5");
    }

    public void Btn6Click()
    {
        SceneManager.LoadScene("Level 6");
    }

    public void Btn7Click()
    {
        SceneManager.LoadScene("Level 7");
    }

    public void Btn8Click()
    {
        SceneManager.LoadScene("Level 8");
    }

    public void Btn9Click()
    {
        SceneManager.LoadScene("Level 9");
    }

    public void Btn10Click()
    {
        SceneManager.LoadScene("Level 10");
    }
}
