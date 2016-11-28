using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldOfView : MonoBehaviour {
    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;
    [Range(0,1)]

    public float meshResolution;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    public MeshFilter viewMeshFilter;
    Mesh viewMesh;
    
    void  Start() {
        viewMesh = new Mesh();
        viewMesh.name = "DetectionMesh";
        viewMeshFilter.mesh = viewMesh;
    }

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
        List<Vector3> viewPoints = new List<Vector3>();
        for(int a = 0; a <= rayCount; a++) {
            float angle = transform.eulerAngles.y - viewAngle / 2 + rayAngleSize * a;
            CastInfo newCast = Cast(angle);
            viewPoints.Add(newCast.point);

        }
        int vertexCount = viewPoints.Count + 1;
        Vector3[] vertices = new Vector3[vertexCount];
        int[] triangles = new int[(vertexCount - 2) * 3];

        vertices[0] = Vector3.zero;

        for(int a = 0; a < vertexCount - 1; a++) {
            vertices[a + 1] = transform.InverseTransformPoint(viewPoints[a]);
            if (a < vertexCount - 2) {

                triangles[a * 3] = 0;
                triangles[a * 3 + 1] = a + 1;
                triangles[a * 3 + 2] = a + 2;
            }
        }
        viewMesh.Clear();
        viewMesh.vertices = vertices;
        viewMesh.triangles = triangles;
        viewMesh.RecalculateNormals();
        
    }
    CastInfo Cast (float globalAngle) {
        Vector3 dir = DirFromAngle(globalAngle, true);
        RaycastHit hit;

        if(Physics.Raycast(transform.position, dir, out hit, viewRadius, obstacleMask)) {
            return new CastInfo(true, hit.point, hit.distance, globalAngle);
        }
        else {
            return new CastInfo(false, transform.position + dir * viewRadius, viewRadius, globalAngle);
        }
    }

    public struct CastInfo {
        public bool hit;
        public Vector3 point;
        public float dst;
        public float angle;

        public CastInfo(bool _hit, Vector3 _point, float _dst, float _angle) {
            hit = _hit;
            point = _point;
            dst = _dst;
            angle = _angle;
        }
    }
}
    