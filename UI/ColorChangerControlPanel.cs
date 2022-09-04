using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColorChangerControlPanel : MonoBehaviour
{
    [SerializeField] private UICarTransmissionController _driveController;

    [SerializeField] private GameObject _up;
    [SerializeField] private GameObject _down;
    [SerializeField] private GameObject _parking;
    [SerializeField] private GameObject _left;
    [SerializeField] private GameObject _right;

    private Button _upButton;
    private Button _downButton;
    private Button _leftButton;
    private Button _rightButton;

    private Image _imageUp;
    private Image _imageDown;
    private Image _imageLeft;
    private Image _imageRight;

    private Color _colorUp;
    private Color _colorDown;
    private Color _colorLeft;
    private Color _colorRight;

    private int _direction;
    private int _rotation;

    private void OnEnable()
    {


        //_driveController.ChangeSpeed += OnChangeSpeed;
        //_driveController.ChangeParking += OnChangeParking;
        _driveController.ChangeRotation += OnChangeDirection;
        //_driveController.ChangeReversed += OnChangeRevers;

    }

    private void OnDisable()
    {
        _driveController.ChangeDirection -= OnChangeRotation;
        _driveController.ChangeRotation -= OnChangeDirection;
        //_driveController.ChangeParking -= OnChangeParking;
        //_driveController.ChangeReversed -= OnChangeRevers;
    }

    private void Awake()
    {
        _upButton = _up.GetComponent<Button>();
        _downButton=_down.GetComponent<Button>();
        _leftButton=_left.GetComponent<Button>();
        _rightButton=_right.GetComponent<Button>();

        _imageUp = _up.GetComponent<Image>();
        _imageDown = _down.GetComponent<Image>();
        _imageLeft = _left.GetComponent<Image>();
        _imageRight = _right.GetComponent<Image>();

        _colorUp = _imageUp.GetComponent<Color>();
        _colorDown = _imageDown.GetComponent<Color>();
        _colorLeft= _imageLeft.GetComponent<Color>();
        _colorRight= _imageRight.GetComponent<Color>();

    }
    public void OnChangeDirection(int direction)
    {
        _direction = direction;

        if (direction > 0)
        {
            _leftButton.enabled= false;
            _colorLeft.a = 50;
        }
        else if (direction < 0)
        {
            _rightButton.enabled = false;
            _colorRight.a = 50;
        }
        else
        {
            _leftButton.enabled = true;
            _colorLeft.a = 255;

            _rightButton.enabled = true;
            _colorRight.a = 255;
        }
    }

    private void OnChangeRotation(int rotation)
    {
        _rotation = rotation;

        if (_rotation > 0)
        {
            _downButton.enabled = false;
            _colorDown.a = 50;
        }
        else if (_rotation < 0)
        {
            _imageUp.enabled = false;
            _colorUp.a = 50;
        }
        else
        {
            _imageUp.enabled = true;
            _colorUp.a = 255;

            _downButton.enabled = true;
            _colorDown.a = 255;
        }
    }
}
