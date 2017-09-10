using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class ActorEnemy : LadderUser {

		[SerializeField]
		protected int m_score;

		public IEnemyState m_currentState { get; private set; }

		public override void Initialize() {
			m_currentState = new EnemyRunState();
			m_currentState.OnEnter(this);
		}

		public override void UpdateByFrame() {

			//向きを更新
			UpdateDirection();

			m_currentState.OnUpdate(this);

		}

		public Player FindPlayer(Vector2 arg_length) {
			RaycastHit2D hitInfo =
				Physics2D.Raycast(transform.position , arg_length.normalized ,
				arg_length.magnitude , 1 << LayerMask.NameToLayer("Player"));

			if (hitInfo) {
				Debug.Log("HIT");
				return hitInfo.collider.gameObject.GetComponent<Player>();
			}
			return null;
		}

		public void UpdateDirection() {
			if (Physics2D.BoxCast(this.transform.position ,
				new Vector2(this.m_width , this.m_height) ,
				0 , Vector2.right * (int)m_direction , this.m_speed , 1 << LayerMask.NameToLayer("Wall"))) {
				//逆方向へ向かせる
				m_direction = (Direction)System.Enum.ToObject(typeof(Direction) , -(int)m_direction);
			}
		}

		public void ExecuteTask(IActorCommand arg_command) {
			Debug.Log(arg_command);
			arg_command.Execute(this);
		}

		public void StateTransition(IEnemyState arg_state) {
			m_currentState.OnExit(this);
			m_currentState = arg_state;
			m_currentState.OnEnter(this);
		}

	}
}