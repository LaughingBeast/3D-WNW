using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class Player : MonoBehaviour
{
    
    public Camera Cam;
    private CharacterController _characterController;

    private Vector3 _playerVelocity;
    [SerializeField]
    private float _playerSpeed = 2.0f;
    private float _gravityValue = -9.81f;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        #region Player Movement
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _characterController.Move(move * Time.deltaTime * _playerSpeed);

        if (!_characterController.isGrounded)
        {
            _playerVelocity.y += _gravityValue * Time.deltaTime;
            _characterController.Move(_playerVelocity * Time.deltaTime);

        } 
        
        if (_characterController.isGrounded)
        { 
            _playerVelocity.y = -2f; 
        }


        #endregion

        #region Mouse Rotate
        Vector3 MouseInput = Input.mousePosition;
        MouseInput.z = 11;
        Vector3 _mousePosition = Cam.ScreenToWorldPoint(MouseInput);
        Vector3 lookAngle = _mousePosition - _characterController.transform.position;
        float _rotation = Mathf.Atan2(lookAngle.y, lookAngle.x) * Mathf.Rad2Deg - 90f;

        _characterController.transform.eulerAngles = new Vector3(0, -_rotation, 0);
        #endregion
    }
}