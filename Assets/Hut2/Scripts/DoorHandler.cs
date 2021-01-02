using UnityEngine;
using System.Collections;

public class DoorHandler : MonoBehaviour {

	//GABROMEDIA@GMAIL.COM

	//Raycast and find animator component - if found, set boolean 'openDoor' to trigger animation states.

	const string MAINDOOR_EQUALS = "Door";
	const string CHEST = "Chest";
	const string MEDICALCABINET = "Cabinet";
	const string FIREPLACE = "Fireplace";

	Camera cam;
	public float distance;

	public AudioClip doorSound;
	public AudioClip chestSound;
	public AudioClip cabinetSound;
	public AudioClip fireplaceSound;

	bool interactable;

	void Start() {
		cam = Camera.main;
		if (cam == null)
			Debug.LogError("MainCamera tag not found in scene");
	}

	void Update() {
		Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, distance)) {
			if (hit.transform.GetComponent<Animator>()) {
				interactable = true;
				if (Input.GetKeyDown(KeyCode.E))			Interact(hit.transform.GetComponent<Animator>());
			}
			else interactable = false;
		}
		else interactable = false;
	}

	void OnGUI() {
		if (interactable) {
			GUI.Label(new Rect(100, 100, 200, 40), "Press E to open or close!");
		}
	}

	void Interact(Animator animator) {
		bool state = animator.GetBool("openDoor");
		if (state)	animator.SetBool("openDoor", false);
		else 		animator.SetBool("openDoor", true);
		PlayAudio(animator.transform);
	}

	void PlayAudio(Transform t) {
		MeshFilter mf = t.GetComponent<MeshFilter>();

		if (mf.name.Equals(MAINDOOR_EQUALS))		AudioSource.PlayClipAtPoint(doorSound, t.position);
		else if (mf.name.Contains(CHEST))			AudioSource.PlayClipAtPoint(chestSound, t.position);
		else if (mf.name.Contains(MEDICALCABINET))	AudioSource.PlayClipAtPoint(cabinetSound, t.position);
		else if (mf.name.Contains(FIREPLACE))		AudioSource.PlayClipAtPoint(fireplaceSound, t.position);

	}
}
