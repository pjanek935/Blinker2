using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    [SerializeField] CanvasGroup canvasGroup;

    [SerializeField] Button exitButton;
    [SerializeField] Button optionsButton;
    [SerializeField] Button tutorialButton;
    [SerializeField] Button newGameButton;
    [SerializeField] Button continueButton;

    void OnEnable()
    {
        if (exitButton != null)
        {
            exitButton.onClick.AddListener(() => onExitButtonClicked ());
        }

        if (optionsButton != null)
        {
            optionsButton.onClick.AddListener(() => onOptionsButtonClicked ());
        }

        if (tutorialButton != null)
        {
            tutorialButton.onClick.AddListener(() => onTutorialButtonClicked ());
        }

        if (newGameButton != null)
        {
            newGameButton.onClick.AddListener(() => onNewGameButtonClicked ());
        }

        if (continueButton != null)
        {
            continueButton.onClick.AddListener(() => onContinueButtonClicked ());
        }
    }

    void onExitButtonClicked ()
    {
        Application.Quit();
    }

    void onOptionsButtonClicked ()
    {

    }

    void onTutorialButtonClicked()
    {
        SceneLoader.Instance.LoadTutorial (canvasGroup);
    }

    void onNewGameButtonClicked ()
    {

    }

    void onContinueButtonClicked ()
    {

    }


}
