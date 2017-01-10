using UnityEngine;

[RequireComponent(typeof(Player))]
public class CollisionDetector : MonoBehaviour
{
    Player player;
    [Tooltip("layermask waar de rays NIET mee moeten collider (Player)")]
    public LayerMask layermask;
    public float playerHeight, rayLenght;

    [Range(2,12)]
    public int rayCount;

    void Awake(){player = GetComponent<Player>();}

    void Update()
    {
        float top = transform.position.y + (playerHeight * transform.localScale.y);
        for (int i = 0; i <= rayCount-1; i++)
        {
            Vector3 horizontalPos = new Vector3(transform.position.x, top - (i * (((playerHeight*2) * transform.localScale.y) / ( rayCount - 1))), transform.position.z);

            RaycastHit rayhit;
            if (Physics.Raycast(horizontalPos, -Vector3.right, out rayhit, rayLenght *transform.localScale.x, ~layermask)) //left
            {
                player.Hit(rayhit);
                break;
            }
            if (Physics.Raycast(horizontalPos, Vector3.right, out rayhit, rayLenght * transform.localScale.x, ~layermask)) //right
            {
                player.Hit(rayhit);
                break;
            }
            Debug.DrawLine(horizontalPos, new Vector3(horizontalPos.x + rayLenght * transform.localScale.x, horizontalPos.y, horizontalPos.z), Color.green);
            Debug.DrawLine(horizontalPos, new Vector3(horizontalPos.x - rayLenght * transform.localScale.x, horizontalPos.y, horizontalPos.z), Color.green);
        }
    }
}