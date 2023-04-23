using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    private Rigidbody _targetRB;
    private GameManager _gameManager;
    private UIManager _uiManager;
    private VolumeController _volumeController;
    private float _minSpeed = 14.0f;
    private float _maxSpeed = 18.0f;
    private float _torqueRange = 10.0f;
    private float _xRange = 4.6f;
    private float ySpawnPos = -2.0f;
    [SerializeField]
    private ParticleSystem _smokePoofVFX, _skullVFX;

    void Start()
    {
        _targetRB = GetComponent<Rigidbody>();
        _targetRB.AddForce(RandomForce(), ForceMode.Impulse);
        _targetRB.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _volumeController = GameObject.Find("VolumeController").GetComponent<VolumeController>();

    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(_minSpeed, _maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-_torqueRange, _torqueRange);
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-_xRange, _xRange), ySpawnPos);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sensor"))
        {
            Destroy(gameObject);
        }
    }

    public void DestroyTarget()
    {
        if (_gameManager._isGameActive)
        {
            Destroy(gameObject);
            if (gameObject.tag == "Bad")
            {
                Instantiate(_skullVFX, transform.position, _skullVFX.transform.rotation);
                _volumeController.PLayTargetSfx(false);
                _uiManager.UpdateScore(-30);
            }


            else
            {
                Instantiate(_smokePoofVFX, transform.position, _smokePoofVFX.transform.rotation);
                _volumeController.PLayTargetSfx(true);
                _uiManager.UpdateScore(10);
            }


        }
    }
}
