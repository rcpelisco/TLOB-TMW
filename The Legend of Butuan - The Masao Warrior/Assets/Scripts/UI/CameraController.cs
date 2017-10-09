using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour {

	public float cameraSpeed = 5f;
	public bool isDestroyOnLoad;

	private GameObject target; 
	private BoxCollider2D boundBox;
	private Vector3 minBounds;
	private Vector3 maxBounds;
	private Camera theCamera;
	private float halfHeight;
	private float halfWidth;
	private static bool isCameraExist;

	void OnEnable() {
		SceneManager.sceneLoaded += OnLevelFinishLoading;
	}

	void OnDisable() {
		SceneManager.sceneLoaded -= OnLevelFinishLoading;
	}

	void OnLevelFinishLoading(Scene scene, LoadSceneMode mode) {
		if(target != null) {
			StartCoroutine(MoveCamera());
		}
	}

	IEnumerator MoveCamera() {
		yield return null;
		transform.position = target.transform.position;
	}

	public void SetBoundBox(BoxCollider2D boundBox) {
		this.boundBox = boundBox;
		ResetPosition();
	}

	void ResetPosition() {
		theCamera = GetComponent<Camera>();
		if(boundBox == null) {
			return;
		}
		minBounds = boundBox.bounds.min;
		maxBounds = boundBox.bounds.max;
		halfHeight = theCamera.orthographicSize;
		halfWidth = halfHeight * Screen.width / Screen.height;
	}

	void Awake() {
		target = GameObject.FindGameObjectWithTag("Player");
		if(isDestroyOnLoad) {
			return;
		}
		if(!isCameraExist) {
			isCameraExist = true;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
		ResetPosition();
	}

	void LateUpdate() {
		if(target == null) {
			return;
		}
		Vector3 targetPos = new Vector3(target.transform.position.x, target.transform.position.y, -10);
		Vector3 camPos = new Vector3(transform.position.x, transform.position.y, -10);
		transform.position = Vector3.Lerp(camPos, targetPos, cameraSpeed * Time.deltaTime);

		float clampedX = Mathf.Clamp(transform.position.x, minBounds.x + halfWidth,maxBounds.x - halfWidth);
		float clampedY = Mathf.Clamp(transform.position.y, minBounds.y + halfHeight,maxBounds.y - halfHeight);
		transform.position = new Vector3(clampedX, clampedY, transform.position.z);
		
	}
}
