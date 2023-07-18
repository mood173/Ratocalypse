using System.Collections.Generic;
using TeamOdd.Ratocalypse.MapLib;
using UnityEngine;
using DG.Tweening;
using static TeamOdd.Ratocalypse.MapLib.MapData;
using System;
using UnityEngine.Events;

namespace TeamOdd.Ratocalypse.Creature
{
    public class Creature : MonoBehaviour
    {

        [SerializeField]
        private Placement _placement;

        public Vector2Int Coord => _placement.Coord;

        [SerializeField]
        private float _duration = 0.1f;

        private CreatureData _creatureData;
        private IMapCoord _mapCoord;

        public virtual void MoveTo(Vector2Int destination)
        {
            _placement.SetCoord(destination);
            UpdateObjectPosition(destination);
        }

        public void UpdateObjectPosition(Vector2Int coord)
        {
            transform.DOMove(_mapCoord.GetTileWorldPosition(coord), _duration);
        }

        public void Initiate(CreatureData creatureData, MapData mapData, IMapCoord mapCoord, Vector2Int coord)
        {
            _creatureData = creatureData;
            _mapCoord = mapCoord;
            _placement = new Placement(mapData, coord, _placement.Shape);//shape for testing
            _placement.OnCoordChanged.AddListener(UpdateObjectPosition);
            UpdateObjectPosition(coord);
        }
    }
}