using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishRound;
    private bool levelCompleted = false;
    // Start is called before the first frame update
    void Start()
    {
        finishRound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            finishRound.Play();
            int curLv = int.Parse(System.IO.File.ReadAllLines("data.txt")[0]);
            int lv = int.Parse(SceneManager.GetActiveScene().name.Substring(6));
            if (lv == curLv)
            {
                curLv++;
                System.IO.File.WriteAllText("data.txt", curLv.ToString());
            }
            levelCompleted = true;
            Invoke("CompleteLevel", 2f);
        }
    }
    private void CompleteLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneManager.LoadScene("Level");
    }
}
