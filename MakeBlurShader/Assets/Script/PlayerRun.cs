using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerRun : MonoBehaviour
{
    private const float SPEED = 5.0f;
    private Vector2 _playerPos = Vector2.zero;
    private float _moveAmount = 0.0f;
    private float _movedAmount = 0.0f;
    private SpriteRenderer _renderer = null;
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _playerPos = this.gameObject.transform.position;
    }

    void Update()
    {
        _moveAmount = Mathf.Sin(Time.time) * SPEED;
        _movedAmount = _moveAmount - _movedAmount;
        Debug.Log(_movedAmount);
        if (Math.Sign(_movedAmount) == 1.0f) _renderer.flipX = false;
        if (Math.Sign(_movedAmount) == -1.0f) _renderer.flipX = true;
        _playerPos.x = _moveAmount;
        this.gameObject.transform.position = _playerPos;
    }

    private void LateUpdate()
    {
        _movedAmount = _moveAmount;
    }
}
