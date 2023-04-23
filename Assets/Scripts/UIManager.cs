using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField]
    private TextMeshProUGUI _scoreText, _timerText;
    public int _score;
    [SerializeField]
    private GameObject _loseScreen, _winScreen, _mainMenu;
    [SerializeField]
    private Slider _scoreSlider;
    [SerializeField]
    private Image _sliderImg, _timerImg;
    [SerializeField]
    private Sprite[] _sliderSprites, _timerSprites;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _scoreSlider.maxValue = _gameManager._winScore;
        _scoreSlider.value = 0;
        _scoreSlider.fillRect.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        UpdateSliderSprite();
        UpdateTimerSprite();
    }

    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        _scoreSlider.fillRect.gameObject.SetActive(true);
        _scoreSlider.value = _score;
        _scoreText.text = _score.ToString();
    }

    void Timer()
    {
        if (_gameManager._timeLeft > 0)
        {
            _gameManager._timeLeft -= Time.deltaTime;
        }
        else
        {
            _gameManager._timeLeft = 0;
            _gameManager.GameOver();
        }

        float minutes = Mathf.FloorToInt(_gameManager._timeLeft / 60);
        float seconds = Mathf.FloorToInt(_gameManager._timeLeft % 60);

        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }

    public void Lose()
    {
        _loseScreen.SetActive(true);
        _mainMenu.SetActive(true);
    }

    public void Win()
    {
        _winScreen.SetActive(true);
        _mainMenu.SetActive(true);
    }

    private void UpdateSliderSprite()
    {
        if (_score < 0)
        {
            _sliderImg.sprite = _sliderSprites[0];
        }
        else if (_score > _gameManager._winScore)
        {
            _sliderImg.sprite = _sliderSprites[1];
        }
        else
        {
            _sliderImg.sprite = _sliderSprites[2];
        }

    }

    private void UpdateTimerSprite()
    {
        if (_gameManager._timeLeft < 10)
        {
            _timerImg.sprite = _timerSprites[0];
        }
        else
        {
            _timerImg.sprite = _timerSprites[1];
        }
    }


}
