using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class Stage {

		public const int FLOOR_COUNT = 3;
		public const float FLOOR_HEIGHT = 3;

		//最低フロアの座標
		private const float ONE_FLOOR_Y = -4.5f;

		/// <summary>
		/// 現在、どの階にいるのかを調べる
		/// 現在のy座標から調べます
		/// </summary>
		/// <param name="arg_vertical">現在のy座標</param>
		/// <returns></returns>
		public static int GetCurrentFloor(float arg_vertical) {
			for(int i = 1; i <= FLOOR_COUNT; i++) {
				//i階にいると仮定
				//i階の床とi+1階の天井の間にいるかを調べる
				//床
				float floor = ONE_FLOOR_Y + (FLOOR_HEIGHT) * (i - 1);
				//天井
				float ceil = ONE_FLOOR_Y + (FLOOR_HEIGHT) * i;

				if(floor < arg_vertical && arg_vertical < ceil) {
					return i;
				}
				else {
					continue;
				}
			}
			return 0;
		}
	}
}