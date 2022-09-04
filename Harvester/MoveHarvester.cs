using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]


public class MoveHarvester : MonoBehaviour
{
    [SerializeField] private UICarTransmissionController _driveController;
    [SerializeField] public float speed;
    private int _direction;
    private BoxCollider _collider;
    int outputPower;
    Vector3 moveVector;
    Rigidbody rb;
    bool isWork=true;
    float turn;
    int _numberPosition;

    private int _currentSpeedPosition;
    private bool _isParking;
    private bool _isReversed = false;
    float _currentTurn;
    private int minSpeedPosition;
    private void Start()
    {
        _numberPosition = 0;
        outputPower = 2;
        _isParking = true;
        _currentSpeedPosition = 0;
        turn = 0;
        rb =GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (isWork)
        {
            Move();
        }
    }

    private void OnEnable()
    {

        _driveController.ChangeParking += OnChangeParking;
        _driveController.ChangeRotation += OnChangeRotation;
        _driveController.ChangeDirection += OnChangeDirection;

        //_driveController.ChangeReversed += OnChangeRevers;

    }

    private void OnDisable()
    {
        _driveController.ChangeParking -= OnChangeParking;
        _driveController.ChangeRotation -= OnChangeRotation;
        _driveController.ChangeDirection -= OnChangeDirection;

        //_driveController.ChangeReversed -= OnChangeRevers;
    }

    public void Move()
    {

            if (_currentSpeedPosition != 0)
            {

                int speedturn = 30; 
                rb.velocity = transform.TransformDirection(Vector3.forward * speed);
                transform.Rotate(Vector3.up * Time.deltaTime* speedturn* _direction);
            }
        
    }

    private void LookAt(Vector3 direction)
    {
        transform.rotation = Quaternion.LookRotation(direction);
    }
    
    public void OnChangeRotation(int direction)
    {
        _direction = direction;
    }

    private void OnChangeDirection(int direction)
    {

        int minSpeed = 0;
        int maxSpeed = 15;



        //int maxSpeedPositionRevers = -4;
        //_numberPosition--;
        //_currentSpeedPosition = Mathf.Clamp(_numberPosition, maxSpeedPositionRevers, minSpeedPosition);
        int minSpeedPosition = -4;
            int maxSpeedPosition = 4;

        _numberPosition += direction;
            _currentSpeedPosition = Mathf.Clamp(_numberPosition, minSpeedPosition, maxSpeedPosition);
            
        

        

        speed = outputPower * _currentSpeedPosition;
    }

    private void OnChangeParking(bool isParking)
    {
        _isParking = isParking;
    }

    private  void OnChangeRevers(bool isReversed)
    {
        _isReversed=isReversed;
        if (_isReversed)
        {
            _numberPosition = 0;
            speed = -2;
        }
        else
        {
            _numberPosition = 0;
            speed = 0;
        }
    }



    //private  IEnumerator SetRevers()
    //{
    //    //yield return new WaitForSeconds();


    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.TryGetComponent<DestroyLayer>(out DestroyLayer harvesterReel))
    //    {
    //        Destroy(gameObject);
    //    }
    //}

}


