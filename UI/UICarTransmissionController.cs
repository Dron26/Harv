using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class UICarTransmissionController : MonoBehaviour
{
    [SerializeField] private GameObject _up;
    [SerializeField] private GameObject _down;
    [SerializeField] private GameObject _parking;
    [SerializeField] private GameObject _left;
    [SerializeField] private GameObject _right;

    private Button _upButton;
    private Button _downButton;
    //private Button _leftButton;
    //private Button _rightButton;

    //private Image _imageUpButton;
    //private Image _imageDownButton;
    //private Image _imageLeftButton;
    //private Image _imageRightButton;

    //private Color _colorUpButton;
    //private Color _colorDownButton;
    //private Color _colorLeftButton;
    //private Color _colorRightButton;

    private bool _isParking;
    private bool _isReversed;

    public event UnityAction ChangeSpeed;
    public event UnityAction<int> ChangeRotation;
    public event UnityAction<bool> ChangeParking;
    public event UnityAction<bool> ChangeRevers;
    public event UnityAction<int> ChangeDirection;
    private int _turn;
    private int direction;

    private void Awake()
    {

        //_upButton=_up.GetComponent<Button>();
        //_downButton=_down.GetComponent<Button>();
        //_leftButton=_left.GetComponent<Button>();
        //_rightButton=_right.GetComponent<Button>();
        _isParking = true;

}

    //private void OnEnable()
    //{
    //    _upButton.onClick.AddListener(OnDriveClick);
    //    //_parking.onClick.AddListener(OnParkingClick);
    //    _downButton.onClick.AddListener(OnReversClick);
    //}

    //private void OnDisable()
    //{
    //    _upButton.onClick.RemoveListener(OnDriveClick);
    //    //_parking.onClick.RemoveListener(OnParkingClick);
    //    _downButton.onClick.RemoveListener(OnReversClick);
    //}

    //public void OnDriveClick()
    //{
    //    ChangeSpeed?.Invoke();
    //    Debug.Log("OnDriveClick");
    //}

    //public void OnReversClick()
    //{

    //    //_isReversed = !_isReversed;
    //    //ChangeReversed?.Invoke(_isReversed);
    //    Debug.Log("OnReversClick");
    //}

    //public void OnParkingClick()
    //{
     
    //    Debug.Log("OnParkingClick");
        
    //    _isParking = !_isParking;
    //    ChangeParking?.Invoke(_isParking);

    //}

    public void OnChangeRotation(int angleRotation)
    {
       int rotation = angleRotation;
        
        ChangeRotation?.Invoke(direction);
    }

    public void OnChangeDirection(int buttonDirection)
    {
         direction += buttonDirection;
        ChangeDirection?.Invoke(direction);
    }
}