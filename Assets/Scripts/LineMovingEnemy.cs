using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UDEV.PlatformGame
{
    [RequireComponent(typeof(LineMoving))]
    public class LineMovingEnemy : Enemy
    {
        private LineMoving lineMoving;

        protected override void Awake()
        {
            base.Awake();
            lineMoving = GetComponent<LineMoving>();
            FSMInit(this);
        }

        public override void Start()
        {
            base.Start();
            movingDist = lineMoving.movingDist;
        }

        public override void Move()
        {
            if (m_isKnockBack) return;

            lineMoving.Move();
            Flip(lineMoving.moveDir);
        }

        #region FSM
        protected override void Moving_Update()
        {
            base.Moving_Update();
            m_targetDir = lineMoving.BackDir;
            lineMoving.speed = m_curSpeed;
            lineMoving.SwitchDirChecking();
        }

        protected override void Chasing_Enter()
        {
            base.Chasing_Enter();
            GetTargetDir();
            lineMoving.SwitchDir(m_targetDir);
        }

        protected override void Chasing_Update()
        {
            base.Chasing_Update();
            GetTargetDir();
            lineMoving.speed = m_curSpeed;
        }

        protected override void Chasing_Exit()
        {
            base.Chasing_Exit();
            lineMoving.SwitchDirChecking();
        }

        protected override void GotHit_Update()
        {
            base.GotHit_Update();
            lineMoving.SwitchDirChecking();
            GetTargetDir();
            if (m_isKnockBack)
            {
                KnockBackMove(0.55f);
            }else
            {
                m_fsm.ChangeState(EnemyAnimState.Moving);
            }
        }
        #endregion
    }
}
