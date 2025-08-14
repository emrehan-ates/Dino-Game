using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject _gameOverCanvas;
    [SerializeField] private GameObject _hudCanvas;
    [SerializeField] private TextMeshProUGUI _hudScore;
    [SerializeField] private TextMeshProUGUI _finalScore;
    [SerializeField] private UnityEngine.UI.Image _tick;
    [SerializeField] private UnityEngine.UI.Image _sfx;
    [SerializeField] private Sprite offImage;
    [SerializeField] private Sprite onImage;

    public bool displayTick = false;
    public bool musicOn = true;
    public bool sfxOn = true;
    public bool displaySFX = true;


    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        Time.timeScale = 1f;
        //_gameOverCanvas.SetActive(false);
    }

    public void GameOver()
    {
        _finalScore.text = _hudScore.text;
        _hudCanvas.SetActive(false);
        _gameOverCanvas.SetActive(true);
       //_tick.enabled = displayTick;
        

        Time.timeScale = 0f;
    }


    void Update()
    {
        _tick.enabled = displayTick;
        if (displaySFX)
        {
            _sfx.sprite = onImage;
        }
        else
        {
            _sfx.sprite = offImage;
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MusicSwitch()
    {
        musicOn = !musicOn;
        displayTick = !displayTick;
    }

    public void SFXSwitch()
    {
        sfxOn = !sfxOn;
        displaySFX = !displaySFX;
    }
}
