using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public CharacterController player;
    public Vector2 focusAreaSize;
    FocusArea focusArea;

    public Color boundingboxColor;
    public float yOffset = 1.5f, zOffset = 10.5f, peekDistance = 4, smoothTimeX = .5f, smoothTimeY =.1f;
    float currentPeek, peekDirection, targetPeek, currentSmoothVelocityX, currentSmoothVelocityY;
    bool peekStopped;

    public void ChangeVals(float yOff,float zOff, float peekDist)
    {
        yOffset = yOff;
        zOffset = zOff;
        peekDistance = peekDist;
    }

    void Start()
    {
        focusArea = new FocusArea(player.GetComponent<Collider>().bounds, focusAreaSize);
    }

    void LateUpdate()
    {
        focusArea.Update(player.GetComponent<Collider>().bounds);
        Vector2 focusPosition = focusArea.centre + Vector2.up * yOffset;
        if (focusArea.velocity.x != 0)
        {
            peekDirection = Mathf.Sign(focusArea.velocity.x);
            if(Mathf.Sign(Input.GetAxis("Horizontal")) == Mathf.Sign(focusArea.velocity.x) && Input.GetAxis("Horizontal") != 0)
            {
                peekStopped = false;
                targetPeek = peekDirection * peekDistance;
            }
            else if (!peekStopped)
            {
                peekStopped = true;
                targetPeek = currentPeek + (peekDirection * peekDistance - currentPeek) / 5f;
            }
        }
        targetPeek = peekDirection * peekDistance;
        currentPeek = Mathf.SmoothDamp(currentPeek, targetPeek, ref currentSmoothVelocityX, smoothTimeX);
        focusPosition.y = Mathf.SmoothDamp(transform.position.y, focusPosition.y, ref currentSmoothVelocityY, smoothTimeY);
        focusPosition += Vector2.right * currentPeek;
        transform.position = (Vector3)focusPosition + Vector3.forward * -zOffset;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = boundingboxColor;
        Gizmos.DrawCube(focusArea.centre, focusAreaSize);
    }

    struct FocusArea
    {
        public Vector2 centre, velocity; 
        float left, right, top, bottom;

        public FocusArea(Bounds targetBounds, Vector2 size)
        {
            left = targetBounds.center.x - size.x / 2;
            right = targetBounds.center.x + size.x / 2;
            bottom = targetBounds.min.y;
            top = targetBounds.min.y + size.y;

            velocity = Vector2.zero;
            centre = new Vector2((left + right) / 2, (top + bottom) / 2);
        }
        public void Update(Bounds targetBounds)
        {
            float shiftX = 0;
            if (targetBounds.min.x < left)
            {
                shiftX = targetBounds.min.x - left;
            }
            else if (targetBounds.max.x > right)
            {
                shiftX = targetBounds.max.x - right;
            }
            left += shiftX;
            right += shiftX;

            float shiftY = 0;
            if (targetBounds.min.y < bottom)
            {
                shiftY = targetBounds.min.y - bottom;
            }
            else if (targetBounds.max.y > top)
            {
                shiftY = targetBounds.max.y - top;
            }
            top += shiftY;
            bottom += shiftY;

            centre = new Vector2((left + right) / 2, (top + bottom) / 2);
            velocity = new Vector2(shiftX, shiftY);
        }
    }
}