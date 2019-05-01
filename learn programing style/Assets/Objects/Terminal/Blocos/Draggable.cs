using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	
	public Transform parentToReturnTo = null;
	public Transform placeholderParent = null;
	public Transform blockList;

	GameObject placeholder = null;
	public GameObject copy;

	public bool isOriginal;

	public List<GameObject> panels = new List<GameObject>();

	void Start(){
		TurnPanelsOFF();
	}


	public void OnBeginDrag(PointerEventData eventData) {
		//Debug.Log ("OnBeginDrag");
		if (parentToReturnTo.gameObject.tag == "List"){
			copy = (GameObject) Instantiate (this.transform.gameObject, eventData.position, Quaternion.Euler (0,0,0), blockList);
			copy.GetComponent<Draggable>().isOriginal = false;
			copy.gameObject.name = gameObject.name;
		}
		if (copy != null) OrderList();
		if (this.gameObject.tag == "condition") transform.localScale = new Vector3(0.375f, 0.5f, 1.0f);
		//if (isOriginal) return;
		placeholder = new GameObject();
		placeholder.transform.SetParent( this.transform.parent );
		LayoutElement le = placeholder.AddComponent<LayoutElement>();
		le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
		le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
		le.flexibleWidth = 0;
		le.flexibleHeight = 0;

		placeholder.transform.SetSiblingIndex( this.transform.GetSiblingIndex() );
		
		parentToReturnTo = this.transform.parent;
		placeholderParent = parentToReturnTo;
		this.transform.SetParent( this.transform.parent.parent );
		
		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}
	
	public void OnDrag(PointerEventData eventData) {
		//Debug.Log ("OnDrag");
		//if (isOriginal) return;
		if (this.transform.gameObject == null) return;
		this.transform.position = eventData.position;

		//if (placeholder == null || placeholderParent == null) return;
		if(placeholder.transform.parent != placeholderParent)
			placeholder.transform.SetParent(placeholderParent);
		
		int newSiblingIndex = placeholderParent.childCount;

		for(int i=0; i < placeholderParent.childCount; i++) {
			if(this.transform.position.x < placeholderParent.GetChild(i).position.x) {

				newSiblingIndex = i;

				if(placeholder.transform.GetSiblingIndex() < newSiblingIndex)
					newSiblingIndex--;

				break;
			}
		}

		placeholder.transform.SetSiblingIndex(newSiblingIndex);

	}
	
	public void OnEndDrag(PointerEventData eventData) {
		//Debug.Log ("OnEndDrag");
		//if (isOriginal) return;
		if (parentToReturnTo.tag != "List") TurnPanelsON();
		else {
			Destroy(gameObject); return;
		}
		this.transform.SetParent( parentToReturnTo );
		this.transform.SetSiblingIndex( placeholder.transform.GetSiblingIndex() );
		GetComponent<CanvasGroup>().blocksRaycasts = true;

		Destroy(placeholder);
	}

	private void TurnPanelsON(){
		for (int i = 0; i < panels.Count; i++) panels[i].SetActive(true);
	}
	private void TurnPanelsOFF(){
		for (int i = 0; i < panels.Count; i++) panels[i].SetActive(false);
	}
	
	private void OrderList(){
		if(copy.tag == "seEntao") copy.transform.SetSiblingIndex(0);
		if(copy.tag == "mova")    copy.transform.SetSiblingIndex(1);
		if(copy.tag == "girar")   copy.transform.SetSiblingIndex(2);
		if(copy.tag == "repita")  copy.transform.SetSiblingIndex(3);
	
	}
}
