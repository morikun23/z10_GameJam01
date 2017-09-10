using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class Balloon : Item {

		// Use this for initialization
		void Start() {

		}

		// Update is called once per frame
		public override void Update() {
			base.Update();
			transform.position += Vector3.left * 0.03f;
		}

		protected override void OnGotten() {
			AudioSource.PlayClipAtPoint(Resources.Load<AudioClip>("Audios/item") , transform.position);
			base.OnGotten();
		}
	}
}