using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] Transform checker = null;
    [SerializeField] [Range(0.01f, 5f)] float checkerRadius = 1;
    [SerializeField] LayerMask interactablesMask = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (Physics.CheckSphere(checker.position, checkerRadius, interactablesMask))
            {
                Debug.Log("Interacting");
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (checker == null) { return; }

        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(checker.position, checkerRadius);
    }
}
