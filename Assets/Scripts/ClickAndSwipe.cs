using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(TrailRenderer), typeof(BoxCollider))]
public class ClickAndSwipe : MonoBehaviour
{
    private GameManager _gameManager;
    private bool _swiping = false;
    private Vector3 _mousePos;
    private TrailRenderer _trail;
    private Camera _cam;
    private BoxCollider _col;
    void Awake()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _trail = GetComponent<TrailRenderer>();
        _col = GetComponent<BoxCollider>();
        _trail.enabled = false;
        _col.enabled = false;
        _cam = Camera.main;
    }
    void Update()
    {
        if (_gameManager._isGameActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _swiping = true;
                UpdateComponents();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _swiping = false;
                UpdateComponents();
            }
            if (_swiping)
            {
                UpdateMousePosition();
            }
        }

    }
    void UpdateMousePosition()
    {
        _mousePos = _cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        transform.position = _mousePos;
    }
    void UpdateComponents()
    {
        _trail.enabled = _swiping;
        _col.enabled = _swiping;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Targets>())
        {
            collision.gameObject.GetComponent<Targets>().DestroyTarget();
        }
    }
}
