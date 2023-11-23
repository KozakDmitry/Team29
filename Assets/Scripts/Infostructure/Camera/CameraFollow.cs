using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public float distance;
    public float height;
	public float smoothness;

	[SerializeField]
	private Transform camTarget;
	
	Vector3 velocity;
 
    void LateUpdate(){
        if(!camTarget)
            return;
		
		Vector3 pos = Vector3.zero;
		pos.x = camTarget.position.x;
		pos.y = camTarget.position.y + height;
		pos.z = camTarget.position.z - distance;
		
		transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smoothness);
    }

    public void Follow(GameObject followObject) => 
		this.camTarget = followObject.transform;
}
