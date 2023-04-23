using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _targets;
    public bool _isGameActive;
    private float _spawnRate;
    public float _timeLeft;
    private UIManager _uiManager;
    public int _winScore = 500;

    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        StartGame();

    }

    void Update()
    {
        IncreaseSpawning();
    }

    IEnumerator SpawnTargets()
    {

        while (_isGameActive)
        {
            yield return new WaitForSeconds(_spawnRate);
            int index = Random.Range(0, _targets.Count);
            Instantiate(_targets[index]);
        }
    }

    void IncreaseSpawning()
    {
        if (_timeLeft >= 40)
        {
            _spawnRate = 0.8f;
        }
        else if (_timeLeft >= 20 && _timeLeft < 40)
        {
            _spawnRate = 0.6f;
        }
        else if (_timeLeft < 20 && _timeLeft > 0)
        {
            _spawnRate = 0.4f;
        }

    }

    public void GameOver()
    {
        _isGameActive = false;

        if (_uiManager._score >= _winScore)
        {
            _uiManager.Win();
        }
        else
        {
            _uiManager.Lose();
        }

    }
    public void StartGame()
    {
        _isGameActive = true;
        StartCoroutine("SpawnTargets");
        _uiManager._score = 0;
        _timeLeft = 60;
        _uiManager.UpdateScore(0);
    }



}
