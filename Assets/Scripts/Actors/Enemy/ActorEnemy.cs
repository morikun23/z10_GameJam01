using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public abstract class ActorEnemy : LadderUser {

		[SerializeField]
		protected int m_score;
		
		public override void Initialize() {

		}

		public override void UpdateByFrame() {

			//向きを更新
			UpdateDirection();

			//TODO:目の前にプレイヤーがいるか
			Player target = FindPlayer(new Vector2((int)m_direction , 0) * 3);
			if (target) {
				return;
			}

			//TODO:梯子チェック
			Ladder ladder = FindLadderFromUp();
			if (ladder) {
				return;
			}

			//TODO:歩く
			
		}

		public Player FindPlayer(Vector2 arg_length) {
			RaycastHit2D hitInfo =
				Physics2D.Raycast(transform.position , arg_length.normalized ,
				arg_length.magnitude , 1 << LayerMask.NameToLayer("Player"));

			if (hitInfo) {
				return hitInfo.collider.gameObject.GetComponent<Player>();
			}
			return null;
		}

		public void UpdateDirection() {
			if (Physics2D.BoxCast(this.transform.position ,
				new Vector2(this.m_width , this.m_height) ,
				0 , Vector2.left , this.m_speed , 1 << LayerMask.NameToLayer("Wall"))) {
				//逆方向へ向かせる
				m_direction = (Direction)System.Enum.ToObject(typeof(Direction) , -(int)m_direction);
			}
		}

		public void ExecuteTask(IActorCommand arg_command) {
			arg_command.Execute(this);
		}
	}
}