using UnityEngine;

public static class Bezier
{
    public static Vector3 GetPoint(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4, float t)
    {
        var p12 = Vector3.Lerp(p1, p2, t);
        var p23 = Vector3.Lerp(p2, p3, t);
        var p34 = Vector3.Lerp(p3, p4, t);

        var p123 = Vector3.Lerp(p12, p23, t);
        var p234 = Vector3.Lerp(p23, p34, t);

        var p1234 = Vector3.Lerp(p123, p234, t);
        return p1234;
    }
}
