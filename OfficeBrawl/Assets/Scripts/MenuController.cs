using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject loosePanel;
    public GameObject winPanel;
    public TextMeshProUGUI[] countText;
    public GameObject[] pauseUI; //index 0 button, index 1 panel

    public void TransitionScene(int level)
    {
        SceneManager.LoadScene(level);
        //loosePanel.SetActive(false);
        //winPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseUI[0].SetActive(false);
        pauseUI[1].SetActive(true);
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        pauseUI[0].SetActive(true);
        pauseUI[1].SetActive(false);
    }

    public void LooseGame()
    {
        loosePanel.SetActive(true);
    }

    public void WinGame()
    {
        winPanel.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}