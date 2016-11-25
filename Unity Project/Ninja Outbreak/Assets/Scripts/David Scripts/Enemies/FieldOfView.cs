using UnityEngine;
using System.Collections;

public class FieldOfView : MonoBehaviour {
    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;

    public float meshResolution;
    
    

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal) {
        if (!angleIsGlobal)
            angleInDegrees += transform.eulerAngles.y;
        return new Vector3(Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0) ;
    }
    void Update() {
        DrawFieldOfView();
    }
    void DrawFieldOfView() {
        int rayCount = Mathf.RoundToInt(viewAngle * meshResolution);
        float rayAngleSize = viewAngle / rayCount;
        for(int a = 0; a <= rayCount; a++) {
            float angle = transform.eulerAngles.y - viewAngle / 2 + rayAngleSize * a;
            Debug.DrawLine(transform.position, transform.position + DirFromAngle(angle, true) * viewRadius,Color.red);

        }

    }
}
    