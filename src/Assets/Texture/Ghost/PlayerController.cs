using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody _rigidbody;
    private Transform _transform;
    private Animator _animator;
    private float _horizontal;
    private float _vertical;
    private Vector3 _velocity;
    private float _speed = 2f;

    private Vector3 _aim; // �ǋL
    private Quaternion _playerRotation; // �ǋL

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
        _animator = GetComponent<Animator>();

        _playerRotation = _transform.rotation; // �ǋL

    }

    void FixedUpdate()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        var _horizontalRotation = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up); // �ǋL

        _velocity = _horizontalRotation * new Vector3(_horizontal, _rigidbody.velocity.y, _vertical).normalized; // �C��

        _aim = _horizontalRotation * new Vector3(_horizontal, 0, _vertical).normalized; // �ǋL

        if (_aim.magnitude > 0.5f)
        { // �ȉ��ǋL
            _playerRotation = Quaternion.LookRotation(_aim, Vector3.up);
        }

        _transform.rotation= Quaternion.RotateTowards(_transform.rotation, _playerRotation, 600 * Time.deltaTime); // �ǋL

        if (_velocity.magnitude > 0.1f)
        {
            _animator.SetBool("moving", true);
        }
        else
        {
            _animator.SetBool("moving", false);
        }

        _rigidbody.velocity = _velocity * _speed;
    }
}