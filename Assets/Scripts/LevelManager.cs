using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class LevelManager : MonoBehaviour
{

    [SerializeField] RectTransform fader;

    public Animator musicAnim;

    public Button buttonStart;

    public TMP_InputField playerNameInputField;



    private void Start()
    {
        buttonStart.gameObject.SetActive(false);
        playerNameInputField.GetComponent<Text>();
        buttonStart.GetComponent<Button>();
        fader.gameObject.SetActive(true);

        LeanTween.alpha(fader, 1, 0);
        LeanTween.alpha(fader, 0, 0.5f).setOnComplete(() =>
        {
            fader.gameObject.SetActive(false);
        });
    }

    private void Update()
    {
        
        if (playerNameInputField.text != "")
        {
            buttonStart.gameObject.SetActive(true);
        }
        else
        {
            buttonStart.gameObject.SetActive(false);
            
        }
        
    }


    public void LoadNextLevel()
    {
        fader.gameObject.SetActive(true);
        LeanTween.alpha(fader, 0, 0);
        LeanTween.alpha(fader, 1, 0.5f).setOnComplete(() =>
        {
            Invoke("LoadGameTime", 2f);

        });
        

    }

    public void LoadMainMenu()
    {
        fader.gameObject.SetActive(true);
        LeanTween.alpha(fader, 0, 0);
        LeanTween.alpha(fader, 1, 0.5f).setOnComplete(() =>
        {
            SceneManager.LoadScene(0);
        });
              
    }

    public void LoadPlayerName()
    {
        musicAnim.SetTrigger("FadeMusic");
        fader.gameObject.SetActive(false);
        LeanTween.alpha(fader, 0, 0);
        LeanTween.alpha(fader, 1, 0.5f).setOnComplete(() =>
        {

            SceneManager.LoadScene(1);
            
        });
        

    }

    public void LoadSelectShip()
    {
        
        musicAnim.SetTrigger("FadeMusic");
        fader.gameObject.SetActive(true);
        LeanTween.alpha(fader, 0, 0);
        LeanTween.alpha(fader, 1, 0.5f).setOnComplete(() =>
        {
            SceneManager.LoadScene(2);

        });
    }
    

    public void GameOver()
    {
        Invoke("LoadGameOverTime", 2f);
    }


    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Exit");
    }


    private void LoadGameOverTime()
    {
        SceneManager.LoadScene(4);
    }

    private void LoadGameTime()
    {
        SceneManager.LoadScene(3);
    }






}
