using UnityEngine;
using System.Collections;

public class PickObject : MonoBehaviour {


	
	private GameObject hitObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			RaycastHit hit;

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit, 20)) {
				Vector3 orto = hit.normal;
				float dist = hit.distance;
				Collider colly = hit.collider;

				hitObject = colly.gameObject;

				Debug.Log("Hit! Distance" + dist + " from " + colly.name);
			} else {
				hitObject = null;
		}
	}
}

	void OnGUI() {
		if (hitObject != null) {
			if (hitObject.GetComponent<ObjectData> () != null) {
				ObjectData data =
					(ObjectData)hitObject.GetComponent<ObjectData> ();

				float screenThird = Screen.width / 3;
				GUILayout.BeginArea(new Rect(
					screenThird, 250, screenThird, 240));
				GUILayout.Label (hitObject.name);
				GUILayout.Label (data.shortName);
				data.description =
					GUILayout.TextArea(data.description,
					               		GUILayout.MinHeight(80));
				GUILayout.Label (data.totalCost.ToString ());
				GUILayout.EndArea();
			} else {
				GUILayout.Label (hitObject.name);
			}
		}
	}
}