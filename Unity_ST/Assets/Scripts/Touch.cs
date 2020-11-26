using UnityEngine;
public class Touch : Sense
{ // komt bij deze class terecht wanneer de collider  van de object is aangeraakt met de collider met een andere object.
void OnTriggerEnter(Collider other)
{

Aspect aspect = other.GetComponent<Aspect>();//  haal de Aspect van de object
//Check  of   dit object een aspect type heeft en als het apsct type  ongelijk is aaan de aspect van de object .
if (aspect != null)
{
//Check the aspect
if (aspect.aspectType != aspectName)
{
print("Enemy Touch Detected"); //print  bericht 
}
}
}
}