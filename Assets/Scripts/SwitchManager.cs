using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class SwitchManager : MonoBehaviour
{
    public GameObject Door;
    private Gate gate;
    public float rotationSpeed = 30f;
    private float minRotation = -21f;
    private float maxRotation = 21f;

    public bool isOpen;
    public bool canGo;

    private void Start()
    {
        gate=Door.GetComponent<Gate>();
    }
    private void Update()
    {
        if (isOpen) 
        { 
            Rotate(1);
            gate.OpenGate();
        }
        else if (!isOpen) 
        {
            Rotate(-1);
            gate.CloseGate();
        }
    }

    private void OnEnable()
    {
        EventManager.OnJoystickClick += HandleJoystickClick;
    }
    private void OnDisable()
    {
        EventManager.OnJoystickClick -= HandleJoystickClick;
    }
    private void HandleJoystickClick()
    {
        if (isOpen) { isOpen = false; }
        else if (!isOpen) { isOpen = true; }

      
       
        StartCoroutine(ResetButtonPress());
        

    }

    private void Rotate(int direction)
    {

        float currentRotation = transform.eulerAngles.z;

       
        currentRotation += rotationSpeed * Time.deltaTime* direction;

       
        if (currentRotation > 180) currentRotation -= 360;
        if (currentRotation < -180) currentRotation += 360;

     
        currentRotation = Mathf.Clamp(currentRotation, minRotation, maxRotation);

       
        transform.rotation = Quaternion.Euler(0, 0, currentRotation);


    }
    private IEnumerator ResetButtonPress()
    {
        yield return new WaitForSeconds(0.5f);
        canGo = false;
    }
}
