 #pragma strict
 
public var distance : float = 5.0f;
public var theAngle : int = 45;
public var segments : int = 10;
 
function Update() 
{
    RaycastSweep();
}
 
function RaycastSweep() 
{
    var startPos : Vector3 = transform.position; // umm, start position !
    var targetPos : Vector3 = Vector3.zero; // variable for calculated end position
     
    var startAngle : int = parseInt( -theAngle * 0.5 ); // half the angle to the Left of the forward
    var finishAngle : int = parseInt( theAngle * 0.5 ); // half the angle to the Right of the forward
     
    // the gap between each ray (increment)
    var inc : int = parseInt( theAngle / segments );
     
    var hit : RaycastHit;
     
    // step through and find each target point
    for ( var i : int = startAngle; i < finishAngle; i += inc ) // Angle from forward
    {
        targetPos = (Quaternion.Euler( 0, i, 0 ) * transform.forward ).normalized * distance;    
         
        // linecast between points
        if ( Physics.Linecast( startPos, targetPos, hit ) )
    {
            Debug.Log( "Hit " + hit.collider.gameObject.name );
    }    
         
// to show ray just for testing
Debug.DrawLine( startPos, targetPos, Color.green );    
}        
}