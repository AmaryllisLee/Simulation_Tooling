using UnityEngine;
public class Aspect : MonoBehaviour {
    // Deze class wordt gebruikt om te definieren wat voor type PLAYER object het is en welke actie de AI agent moet nemen.
    public enum AspectTypes {
        PLAYER,
        ENEMY,
    }

    public AspectTypes aspectType;
}
