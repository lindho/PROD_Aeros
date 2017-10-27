using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public PlayerController target;
	private FocusArea focusArea;
	public Vector2 focusAreaSize;

	void Start() {
		focusArea = new FocusArea (target.collider.bounds, focusAreaSize);
	}

	void LateUpdate() {
		focusArea.Update (target.collider.bounds);

		Vector2 focusPosition = focusArea.centre;
		transform.position = (Vector3)focusPosition + Vector3.forward * -10;

	}

	struct FocusArea {
		public Vector2 centre;
		public Vector2 velocity;
		float left,right;
		float top,bottom;

		public FocusArea(Bounds targetBounds, Vector2 size) {
			left = targetBounds.center.x - size.x/2;
			right = targetBounds.center.x + size.x/2;
			bottom = targetBounds.center.y - size.y/2;
			top = targetBounds.center.y + size.y/2;

			velocity = Vector2.zero;
			centre = new Vector2((left + right)/2,(top + bottom)/2);
		}

		public void Update(Bounds targetBounds) {
			float shiftX = 0;
			if (targetBounds.min.x < left) {
				shiftX = targetBounds.min.x - left;
			} else if (targetBounds.max.x > right) {
				shiftX = targetBounds.max.x - right;
			}
			left += shiftX;
			right += shiftX;

			float shiftY = 0;
			if (targetBounds.min.y < bottom) {
				shiftY = targetBounds.min.y - bottom;
			} else if (targetBounds.max.y > top) {
				shiftY = targetBounds.max.y - top;
			}
			top += shiftY;
			bottom += shiftY;
			centre = new Vector2((left + right)/2,(top + bottom)/2);
			velocity = new Vector2 (shiftX, shiftY);
		}
	}
}