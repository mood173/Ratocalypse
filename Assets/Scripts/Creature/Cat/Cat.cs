using System.Collections.Generic;
using TeamOdd.Ratocalypse.MapLib;
using UnityEngine;
using static TeamOdd.Ratocalypse.MapLib.MapData;
using DG.Tweening;

namespace TeamOdd.Ratocalypse.CreatureLib.Cat
{
    public class Cat : Creature
    {
        [SerializeField]
        protected CatData _catData;

        public override void Initiate(Placement placement, IMapCoord mapCoord)
        {
            _catData = (CatData)placement; 
            base.Initiate(placement, mapCoord);
        }
        
        protected override void RegisterCallbacks()
        {
            base.RegisterCallbacks();
        }

        protected override void OnCoordChanged(Vector2Int coord)
        {
            transform.DOMove(_mapCoord.GetTileWorldPosition(coord), 0.2f);
        }

        protected override void OnHpReduced(float hp)
        {
            var hit = transform.DORotate(new Vector3(0, 0, 10), 0.2f).SetLoops(2, LoopType.Yoyo);
            DOTween.Sequence().AppendInterval(0.5f).Append(hit);
        }
    }
}