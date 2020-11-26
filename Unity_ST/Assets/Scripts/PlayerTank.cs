using UnityEngine;
public class PlayerTank : MonoBehaviour 
{
    public Transform targetTransform; //Transform is de Positie, rotation/angle and scale van een object. Deze componenten wordt er gepakt van onze aangeraakte object adhv raycast
    public float targetDistanceTolerance = 3.0f;
    
    private float movementSpeed;
    private float rotationSpeed;

    // Use this for initialization
    void Start () 
    {
        // De tank beweegt en draait met een constante snelheid.
        movementSpeed = 10.0f;
        rotationSpeed = 2.0f;
    }

    // Update is called once per frame
    // De tank beweegt als de afstand tussen de tank en de aangeraakt groter is dan 3.0f
    void Update () 
    {
        if (Vector3.Distance(transform.position, targetTransform.position) < targetDistanceTolerance) 
        {
            return;
        }
    Vector3 targetPosition = targetTransform.position;
    targetPosition.y = transform.position.y;
    Vector3 direction = targetPosition - transform.position;
     // De tank draait naar de object toe
    Quaternion tarRot = Quaternion.LookRotation(direction);
    transform.rotation = Quaternion.Slerp(transform.rotation, tarRot, rotationSpeed * Time.deltaTime);
    // De tank beweegt naar de object toe . De transform.position van de tank wordt aangepast.
    transform.Translate(new Vector3(0, 0, movementSpeed * Time.deltaTime));
    }
}