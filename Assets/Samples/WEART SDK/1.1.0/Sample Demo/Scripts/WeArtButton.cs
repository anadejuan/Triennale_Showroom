using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeArt.Components;
using WeArt.Core;
using UnityEngine.Events;

public class WeArtButton : MonoBehaviour
{
    [SerializeField] private WeArtTouchableObject _touchableObject;
    [SerializeField] private Transform _buttonTop;
    [SerializeField] private float _topPressHeight;
    private float _topInitialHeight;
    private bool _isPressed = false;

    public UnityEvent OnPressed = new UnityEvent();
    public UnityEvent OnStay = new UnityEvent();
    public UnityEvent OnRelease = new UnityEvent();

    void Start()
    {
        _topInitialHeight = _buttonTop.localPosition.y;
    }

    
    void Update()
    {
        if(_isPressed)
        {
            if (_touchableObject.AffectedHapticObjects.Count <= 0)
            {
                _isPressed = false;
                OnRelease.Invoke();
                _buttonTop.localPosition = new Vector3(0, _topInitialHeight, 0);
            }
            else 
            {
                OnStay.Invoke();
            }
        }
        else
        {
            if (_touchableObject.AffectedHapticObjects.Count > 0)
            {
                _isPressed = true;
                OnPressed.Invoke();
                _buttonTop.localPosition = new Vector3(0, _topPressHeight, 0);
            }
        }
        
    }
}
