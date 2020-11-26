using UnityEngine;
public class Target : MonoBehaviour
/* Deze class */
{
    public Transform targetMarker;

    void Start (){}

    void Update ()
    {
        int button = 0;

        //Get the point of the hit position when the mouse is being clicked
        if(Input.GetMouseButtonDown(button)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo; // pakt de info van de collider/ribben van de aangeraakt object.

            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo)) 
            {
                //sla de positie van de object in targetPosition en vevolgens in targetMarker.position
                Vector3 targetPosition = hitInfo.point; 
                targetMarker.position = targetPosition; 
            }
        }
    }
}