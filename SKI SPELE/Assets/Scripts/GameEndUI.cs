using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndUI : MonoBehaviour
{

    [SerializeField] private GameObject gameOverMenu;

    [SerializeField] private Image crossFade;
    // Start is called before the first frame update
    void Start()
    {
        gameOverMenu.SetActive(false);
        crossFade.CrossFadeAlpha(0, 1f, true);
    }
    
    private void OnEnable()
    {
        GameEvents.RaceFinish += EnableGameOver;
        GameEvents.Quit += Quit;
    }

    private void OnDisable()
    {
        GameEvents.RaceFinish -= EnableGameOver;
        GameEvents.Quit -= Quit;
    }

    private void EnableGameOver()
    {
        gameOverMenu.SetActive(true);
    }

    public void QuitButton()
    {
        GameEvents.CallQuit();
    }

    public void RestartLevel()
    {
        StartCoroutine(RestartCouroutine());
    }

    private IEnumerator RestartCouroutine()
    {
        crossFade.CrossFadeAlpha(1, 1f, true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void NextLevel()
    {
        StartCoroutine(NextLevelCouroutine());
    }

    private IEnumerator NextLevelCouroutine()
    {
        crossFade.CrossFadeAlpha(1, 1f, true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void Quit()
    {
        StartCoroutine(QuitCouroutine());
    }
    
    private IEnumerator QuitCouroutine()
    {
        crossFade.CrossFadeAlpha(1, 1f, true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
