using UnityEngine;

public class SpawnerPlant : MonoBehaviour
{
    [SerializeField] private PropPlant _propPlantWheat;
    [SerializeField] private float maxSizeX;
    [SerializeField] private float maxSizeZ;

    private int _random;
    float step;
    float maxAngle;
    float angle;
    private Vector3 wheatPosition;
    private Vector3 _rotation;
    private float _currentposX;
    private float _currentposZ;
    private Quaternion startRotation;
    private PropPlant plant;
    Vector3 target;
    private Quaternion _quaternion;

    private void Awake()
    {
        _quaternion= Quaternion.identity;
        wheatPosition=transform.position;

        _currentposX= wheatPosition.x;

        _currentposZ = wheatPosition.z;
        step = 2;
         maxAngle = 100;

        PlacementPlant();
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void PlacementPlant()
    {
        for (float stepZ = 0; stepZ < maxSizeZ; stepZ+= step)
        {
            

            for (float stepX = 0; stepX < maxSizeX; stepX += step)
            {           
                wheatPosition.x += step;
                angle = Random.Range(0, maxAngle);
                _rotation = new Vector3(0, angle, 0);
                startRotation = Quaternion.Euler(_rotation);
                plant = Instantiate(_propPlantWheat, wheatPosition, startRotation);
                plant.transform.SetParent(transform);
            }
            wheatPosition.x = _currentposX;
            wheatPosition.z += step;
        }  
    }
}
