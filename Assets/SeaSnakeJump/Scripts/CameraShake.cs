using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

	public float shake_decay_start = 0.002f;
	public float shake_intensity_start = 0.03f;

	private float shake_decay;
	private float shake_intensity;

	private Vector3 originPosition;
	private Quaternion originRotation;
	private bool shaking;
	private Transform transformAtOrigin;

	void OnEnable() {
		transformAtOrigin = transform;
	}

	//	void OnGUI () {
	//		if (GUI.Button (new Rect (20,40,80,20), "Shake")){
	//			Shake ();
	//		}
	//	}

	void Update () {
		if(!shaking)
			return;
		if (shake_intensity > 0f){
			transformAtOrigin.localPosition = originPosition + Random.insideUnitSphere * shake_intensity;
			transformAtOrigin.localRotation = new Quaternion(
				originRotation.x + Random.Range (-shake_intensity,shake_intensity) * .2f,
				originRotation.y + Random.Range (-shake_intensity,shake_intensity) * .2f,
				originRotation.z + Random.Range (-shake_intensity,shake_intensity) * .2f,
				originRotation.w + Random.Range (-shake_intensity,shake_intensity) * .2f);
			shake_intensity -= shake_decay;
		} else {
			shaking = false;
			transformAtOrigin.localPosition = originPosition;
			transformAtOrigin.localRotation = originRotation;
		}
	}

	public void Shake() {
		if(!shaking) {
			originPosition = transformAtOrigin.localPosition;
			originRotation = transformAtOrigin.localRotation;
		}
		shaking = true;
		shake_decay = shake_decay_start;
		shake_intensity = shake_intensity_start;
	}
	
}