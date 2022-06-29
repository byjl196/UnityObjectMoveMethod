using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCurve : MonoBehaviour
{
	public AnimationCurve curve;

	[SerializeField]
	Transform targetTrans;

	[SerializeField]
	GameObject moveobj;

	[SerializeField]
	GameObject slideControlObj;

	[SerializeField]
	float duration = 0;

	float runningtime;
	[Range (0, 1), SerializeField]
	float input = 0;

	Vector3 autoMoveCachPos;
	Vector3 slideMoveCachPos;
	// Start is called before the first frame update
	void Start()
	{
		autoMoveCachPos = moveobj.transform.position;
		slideMoveCachPos = slideControlObj.transform.position;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (duration != 0)
		{
			runningtime += Time.deltaTime;
			UpdateTransform (moveobj.transform, autoMoveCachPos,runningtime / duration);
		}
		UpdateTransform (slideControlObj.transform, slideMoveCachPos, input);		
	}

	void UpdateTransform(Transform movetrans, Vector3 cachPostion, float time)
	{
		if (cachPostion == null)
		{
			cachPostion = movetrans.position;
		}

		var moveDif = time > 1 ? 1 : curve.Evaluate (time);
		Vector3 distanceVec = targetTrans.position - cachPostion;

		movetrans.position = cachPostion + distanceVec * moveDif;
	}

}

