using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{

    [SerializeField] private RectTransform background;
    [SerializeField] private RectTransform handle;
    [SerializeField] RectTransform Container;
    private Vector2 _joystickCenter = Vector2.zero;
    private Vector3 _containerDefaultPosition;
    [SerializeField] private float handleLimit = 1f;
    private Vector2 inputVector = Vector2.zero;

    public float Horizontal { get { return inputVector.x; } }
    public float Vertical { get { return inputVector.y; } }
    private Vector2 Direction { get { return new Vector2(Horizontal, Vertical); } }
    void Start()
    {
        _containerDefaultPosition = Container.position;
    }

    
    

    public virtual void OnDrag(PointerEventData eventData)
    {
        Vector2 direction = eventData.position - _joystickCenter;
        inputVector = (direction.magnitude > background.sizeDelta.x / 2f) ? direction.normalized : direction / (background.sizeDelta.x / 2f);
        handle.anchoredPosition = (inputVector * background.sizeDelta.x / 2f) * handleLimit;
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        Container.position = eventData.position;
        handle.anchoredPosition = Vector2.zero;
        _joystickCenter = eventData.position;
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        Container.position = _containerDefaultPosition;
        handle.anchoredPosition = Vector2.zero;
        inputVector = Vector2.zero;
    }
}

