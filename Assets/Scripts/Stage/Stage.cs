using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class Stage {

		public const int FLOOR_COUNT = 3;
		public const float FLOOR_HEIGHT = 3;

		//最低フロアの座標
		private const float ONE_FLOOR_Y = -4.5f;

		public static int GetCurrentFloor(float arg_vertical) {
			for(int i = 1; i < FLOOR_COUNT; i++) {
				//i階にいると仮定
				//i階の床とi+1階の天井の間にいるかを調べる
				//下層
				float floor = ONE_FLOOR_Y + i;
			}
			return 0;
		}
	}
}