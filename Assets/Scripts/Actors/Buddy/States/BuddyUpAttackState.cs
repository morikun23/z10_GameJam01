using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {

    public class BuddyUpAttackState : IBuddyState
    {

        //攻撃の時間
        float m_attackTime = 0.5f;

        //経過時間
        float m_durationtime = 0;

        private Ladder m_ladder;

        /// <summary>
        /// ステート開始時に一度だけ呼ばれる
        /// </summary>
        /// <param name="arg_actor"></param>
        public void OnEnter(ActorBuddy arg_actor)
        {

        }

        /// <summary>
        /// ステート中毎フレーム更新される
        /// </summary>
        /// <param name="arg_actor"></param>
        public void OnUpdate(ActorBuddy arg_actor)
        {

            m_durationtime += Time.deltaTime;

            if(m_durationtime > m_attackTime)
            {
                Ladder ladder = arg_actor.FindLadderFromUp();
                arg_actor.StateTransition(new BuddyUpstairsState(ladder));
            }

        }

        /// <summary>
        /// ステート終了時に一度だけ呼ばれる
        /// </summary>
        /// <param name="arg_actor"></param>
        public void OnExit(ActorBuddy arg_actor)
        {

        }
    }
}