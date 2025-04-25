using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI interactionText;
    [SerializeField]
    private GameObject gamePanel;
    [SerializeField]
    private GameObject pausePanel;
    private static HUDManager _Instance;
    public static HUDManager Instance
    {

        get 
        { 
            return _Instance;
        } 
    }
    private void Awake()
    {
        if (_Instance == null)
        {
            _Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        try
        {
            interactionText = GameObject.Find("Text_Interaction").GetComponent<TextMeshProUGUI>();
            gamePanel = GameObject.Find("Panel_Game").GetComponent<GameObject>();
            pausePanel = GameObject.Find("Panel_PauseMenu").GetComponent<GameObject>();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    public void RestartButton()
    {
        GameManager.Instance.RestartGame();
    }

    public void OpenMenu()
    {
        gamePanel.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void CloseMenu()
    {
        gamePanel.SetActive(true);
        pausePanel.SetActive(false);
    }

    public void GoToMainMenu()
    {
        GameManager.Instance.GoToMenu();
    }

    public void SetInteractionText(string text)
    {
        interactionText.SetText(text);
    }

}
