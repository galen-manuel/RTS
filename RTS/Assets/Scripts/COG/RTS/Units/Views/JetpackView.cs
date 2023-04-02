using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace COG.RTS.Units
{
    public class JetpackView : UnitView
    {
        public Transform Visual;

        private void Start()
        {
            Visual.DOLocalMoveY(-0.25f, 5.0f).SetRelative(true).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutQuad);
        }

        private void OnDestroy()
        {
            Visual.DOKill();
        }
    }
}
