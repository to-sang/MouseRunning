using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        if (EventSystem.current.currentSelectedGameObject.name.Equals("New Game"))
            System.IO.File.WriteAllText("data.txt", "1");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
