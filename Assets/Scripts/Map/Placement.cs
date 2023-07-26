using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TeamOdd.Ratocalypse.MapLib
{
    public partial class MapData
    {
        [System.Serializable]
        public class Placement
        {
            protected MapData _mapData;
            [field: ReadOnly, SerializeField]
            public Vector2Int Coord { get; protected set; }
            [field: ReadOnly,SerializeField]
            public Shape Shape { get; protected set; }

            public UnityEvent<Vector2Int> OnCoordChanged = new UnityEvent<Vector2Int>();

            public Placement(MapData mapData, Vector2Int coord, Shape shape = default)
            {
                _mapData = mapData;
                Coord = coord;
                Shape = shape.Copy();
                SetCoord(coord);
            }

            public void SetCoord(Vector2Int newCoord)
            {
                Remove();
                Coord = newCoord;
                UpdatePosition();
                OnCoordChanged.Invoke(Coord);
            }

            public void Remove()
            {
                foreach (Vector2Int shapeCoord in Shape)
                {
                    Placement removed = _mapData.RemovePlaceable(Coord + shapeCoord);
                    if (removed != null && removed != this)
                    {
                        throw new System.Exception("cannot remove another placement");
                    }
                }
            }

            private void UpdatePosition()
            {
                foreach (Vector2Int shapeCoord in Shape)
                {
                    _mapData.SetPlaceble(Coord + shapeCoord, this);
                }
            }
        }
    }

}