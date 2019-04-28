using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adjust_Panel2_IF_ELSE : MonoBehaviour
{
	public RectTransform rectPanel2;
	public Transform panel1;
	public float originalHeight, space;

	void Start(){
		originalHeight = rectPanel2.localPosition.y;
	}

    // Update is called once per frame
    void Update()
    {
    	float h = panel1.childCount * space;
    	Debug.Log("Altura: "+h+" size: "+rectPanel2.transform.position+" size: "+rectPanel2.rect+" size: "+rectPanel2.localPosition+" size: "+rectPanel2.position);
        if (panel1.childCount > 1) rectPanel2.localPosition = new Vector3(rectPanel2.localPosition.x, -63 -h, 0) ;
    }

}
