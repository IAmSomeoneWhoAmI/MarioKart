using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KartControlP1 : MonoBehaviour
{



    [SerializeField]
    private LayerMask _layerMask;
    [SerializeField]
    private Rigidbody _rb;

    private float _speed, _accelerationLerpInterpolator, _rotationInput;
    [SerializeField]
    private float _speedMaxBasic = 3, _speedMaxTurbo = 10, _accelerationFactor, _rotationSpeed = 0.5f;
    private bool _isAccelerating, _isTurbo;
    private float _terrainSpeedVariator;

    [SerializeField]
    private AnimationCurve _accelerationCurve;



    public void Turbo()
    {
        if (!_isTurbo)
        {
            StartCoroutine(Turboroutine());
        }
    }

    private IEnumerator Turboroutine()
    {
        _isTurbo = true;
        yield return new WaitForSeconds(3);
        _isTurbo = false;
    }
    void Update()
    {


        _rotationInput = Input.GetAxis("HorizontalP1");

        if (Input.GetButtonDown("ActionP1"))
        {
            _isAccelerating = true;
        }
        if (Input.GetButtonUp("ActionP1"))
        {
            _isAccelerating = false;
        }

        if (Physics.Raycast(transform.position, transform.up * -1, out var info, 1, _layerMask))
        {

            Terrain terrainBellow = info.transform.GetComponent<Terrain>();
            if (terrainBellow != null)
            {
                _terrainSpeedVariator = terrainBellow.speedVariator;
            }
            else
            {
                _terrainSpeedVariator = 1;
            }
        }
        else
        {
            _terrainSpeedVariator = 1;
        }

       
    }

    private void FixedUpdate()
    {

        if (_isAccelerating)
        {
            _accelerationLerpInterpolator += _accelerationFactor;
        }
        else
        {
            _accelerationLerpInterpolator -= _accelerationFactor * 2;
        }

        _accelerationLerpInterpolator = Mathf.Clamp01(_accelerationLerpInterpolator);


        if (_isTurbo)
        {
            _speed = _speedMaxTurbo;
        }
        else
        {
            _speed = _accelerationCurve.Evaluate(_accelerationLerpInterpolator) * _speedMaxBasic * _terrainSpeedVariator;
        }

        transform.eulerAngles += Vector3.up * _rotationSpeed * Time.deltaTime * _rotationInput;
        _rb.MovePosition(transform.position + transform.forward * _speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stunt"))
        {
            StartCoroutine(Stun());
        }
    }

    private IEnumerator Stun()
    {
        _speedMaxBasic -= 15;
        yield return new WaitForSeconds(2);
        _speedMaxBasic += 15;
    }
}
