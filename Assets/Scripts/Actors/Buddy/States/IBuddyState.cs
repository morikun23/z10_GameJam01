using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public interface IBuddyState {

		//ステート開始時に一度だけ呼ばれる
		void OnEnter(ActorBuddy arg_actor);

		//ステート中毎フレーム更新される
		void OnUpdate(ActorBuddy arg_actor);

		//ステート終了時に一度だけ呼ばれる
		void OnExit(ActorBuddy arg_actor);
	}
}