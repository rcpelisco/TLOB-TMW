using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeText {
	public IEnumerator FadeTextToFullAlpha(float time, Text t) {
		while(t.color.a < 1.0f) {
			t.color = new Color(t.color.r, t.color.g, 
				t.color.b, t.color.a + (Time.deltaTime / time));
			yield return null;
		}
	}

	public IEnumerator FadeTextToZeroAlpha(float time, Text t) {
		while(t.color.a > 0.0f) {
			t.color = new Color(t.color.r, t.color.g, 
				t.color.b, t.color.a - (Time.deltaTime / time));
			yield return null;
		}
	}
}
