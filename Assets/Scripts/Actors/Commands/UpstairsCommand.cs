using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class UpstairsCommand : IActorCommand {

		//到着地点
		private Vector2 m_destination;

		//開始地点
		private Vector2 m_startPosition;

		//座標のバッファ
		private Vector2 m_positionBuf;

		//フレーム数
		private int m_frame;

		//現在のフレーム
		private int m_currentFrame;

		/// <summary>
		/// コンストラクタ
		/// 初期化を行う
		/// </summary>
		/// <param name="arg_actor"></param>
		public UpstairsCommand(LadderUser arg_actor , int arg_frame , int arg_currentFrame) {
			int m_currentFloor = arg_actor.m_currentFloor;
			m_startPosition = new Vector2(arg_actor.transform.position.x , (-3.75f + (m_currentFloor - 1) * 2.95f));
			m_destination = new Vector2(arg_actor.transform.position.x,(-3.75f + (m_currentFloor + 1 - 1) * 2.95f));
			m_positionBuf = arg_actor.transform.position;
			m_frame = arg_frame;
			m_currentFrame = arg_currentFrame;
		}

		/// <summary>
		/// コマンドの実行
		/// </summary>
		/// <param name="arg_actor"></param>
		public void Execute(LadderUser arg_actor) {

			float vertical = (m_destination.y - m_startPosition.y) / m_frame;
			arg_actor.transform.position = m_startPosition + Vector2.up * vertical * m_currentFrame;
			
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