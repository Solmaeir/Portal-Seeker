using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Switch : MonoBehaviour
{

    
    public Transform areaCenter; 
    public float areaRadius = 5f; 
    public LayerMask targetLayer;
    public TextMeshProUGUI text;

    SwitchManager switchManager;
    

    private void Start()
    {
        switchManager = GetComponent<SwitchManager>();    
        text.gameObject.SetActive(false);
    }
    private void Update()
    {   
        RangeControl();
    }

    private void ToggleScript(bool active)
    {
        
        if (switchManager != null)
        {
            switchManager.enabled = active; 
        }
    }
    public void RangeControl() 
    {
        Collider2D target = Physics2D.OverlapCircle(areaCenter.position, areaRadius, targetLayer);

        if (target != null)
        {
           
            text.gameObject.SetActive(true);
            ToggleScript(true);

        }
        else
        { 
            text.gameObject.SetActive(false);
            ToggleScript(false);
        }

    }
    private void OnDrawGizmosSelected()
    {
        if (areaCenter == null)
            return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(areaCenter.position, areaRadius);
    }

   
}
