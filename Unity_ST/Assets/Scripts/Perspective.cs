using UnityEngine;
public class Perspective : Sense
{
    public int fieldOfView = 45;
    public int viewDistance = 100;

    private Transform playerTransform;
    private Vector3 rayDirection;
    // komt bij deze class terecht als er een Game object is tegengekomen met de tagg PLAYER
    protected override void Initialize() 
    {
    playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    //   Functiie die print("Enemy Detected") wanneer object bevat een aspect type die ongelijk is aan de apsect type van de AI. .
    protected override void UpdateSense() 
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= detectionRate) 
        {
        DetectAspect();
        }
    }
    //Detect perspective field of view for the AI Character
    void DetectAspect()
    {
        RaycastHit hit;
        rayDirection = playerTransform.position - transform.position;

        if ((Vector3.Angle(rayDirection, transform.forward)) < fieldOfView)
        {
            // Detect if player is within the field of view
            if (Physics.Raycast(transform.position, rayDirection, out hit, viewDistance))
            {
                Aspect aspect = hit.collider.GetComponent<Aspect>();
                if (aspect != null)
                {
                    //Check the aspect
                    if (aspect.aspectType != aspectName)
                    {
                    print("Enemy Detected");
                    }
                }   
            }
        }
    }

    void OnDrawGizmos()
    //in deze functie zullen we de zicht van de AI character gevisualiseerd.Er wordt lijnen getekend van alle kannten waar de AI-character  kan zien.
    {
            if (playerTransform == null) 
            {
                return;
            }
    Debug.DrawLine(transform.position, playerTransform.position, Color.red);

    Vector3 frontRayPoint = transform.position + (transform.forward * viewDistance);

    //Approximate perspective visualization
    Vector3 leftRayPoint = frontRayPoint;
    leftRayPoint.x += fieldOfView * 0.5f;

    Vector3 rightRayPoint = frontRayPoint;
    rightRayPoint.x -= fieldOfView * 0.5f;

    Debug.DrawLine(transform.position, frontRayPoint, Color.green);
    Debug.DrawLine(transform.position, leftRayPoint, Color.green);
    Debug.DrawLine(transform.position, rightRayPoint, Color.green);
    }
}
