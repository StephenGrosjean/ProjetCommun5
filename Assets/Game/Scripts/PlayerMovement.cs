using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private Animator animatorComponent;
    [SerializeField] private LineRenderer line;

    private Vector2 prevPos, newPos, target;


    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit)) {
                agent.SetDestination(hit.point);
                target = hit.point;
            }
        }


        prevPos = newPos;
        newPos = transform.position;
        animatorComponent.SetBool("IsWalking", prevPos != newPos);

        if(prevPos != newPos) {
            line.enabled = true;
            line.SetPosition(0, transform.position);
            line.SetPosition(1, target);
        }
        else {
            line.enabled = false;
        }
    }
}
