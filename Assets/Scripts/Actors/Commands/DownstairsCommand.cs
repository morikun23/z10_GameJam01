using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class DownstairsCommand : IActorCommand {

		//到着地点
		private Vector2 m_destination;

		//開始地点
		private Vector2 m_startPosition;

		//座標のバッファ
		private Vector2 m_positionBuf;

		/// <summary>
		/// コンストラクタ
		/// 初期化を行う
		/// </summary>
		/// <param name="arg_actor"></param>
		public DownstairsCommand(LadderUser arg_actor) {
			int m_currentFloor = arg_actor.m_currentFloor;
			m_startPosition = new Vector2(m_startPosition.x , (-3.75f + (m_currentFloor - 1) * 2.95f));
			m_destination = new Vector2(m_startPosition.x , (-3.75f + (m_currentFloor - 1 - 1) * 2.95f));
			m_positionBuf = arg_actor.transform.position;
		}

		/// <summary>
		/// コマンドの実行
		/// </summary>
		/// <param name="arg_actor"></param>
		public void Execute(LadderUser arg_actor) {
			
			Vector2 decrease = (m_destination - m_startPosition) / 50;
			arg_actor.transform.position += (Vector3)decrease;

		}

		/// <summary>
		/// コマンドの取り消し
		/// </summary>
		/// <param name="arg_actor"></param>
		public void Undo(LadderUser arg_actor) {
			arg_actor.transform.position = m_positionBuf;
		}
	}
}
