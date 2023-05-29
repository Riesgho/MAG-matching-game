using System;
using System.Collections.Generic;
using Code.Board.Domain;
using Code.Board.Presenters;
using UnityEngine;

namespace Code.Board.Views
{
    public class BlockViewWorldSpace : MonoBehaviour, IBlockView
    {
        public Action BlockClicked { get; set; }
        public Action Popped { get; set; }

        [SerializeField] private SpriteRenderer image;

        private Block _block;
        private List<string> _neighbours;
        private string Id => _block.ID;
        public void Initialize(Block block, float blockConfigBaseSize)
        {
            _block = block;
            transform.position = new Vector2(_block.InitPositionX, _block.InitPositionY);
            transform.localScale = new Vector2(_block.Width / blockConfigBaseSize, _block.Height/ blockConfigBaseSize);
            image.color = _block.Color.Color;
        }
    
        private void OnMouseDown()
        {
            BlockClicked();
        }
    
        public IEnumerable<string> FindNeighbours()
        {
            _neighbours = new List<string>();
            RaycastOnDirection(Vector2.up);
            RaycastOnDirection(Vector2.down);
            RaycastOnDirection(Vector2.left);
            RaycastOnDirection(Vector2.right);
            return _neighbours;
        }

        public void Pop()
        {
            gameObject.SetActive(false);
            Popped();
        }

        public void MoveTo(float position)
        {
            transform.position = new Vector2(_block.InitPositionX, transform.position.y + position);
            gameObject.SetActive(true);
       
        }

        public void UpdateColor(Color blockColor)
        {
            image.color = blockColor;
        }

        private void RaycastOnDirection(Vector2 direction)
        {
            var blockHeight = _block.Height;
            var hit = Physics2D.Raycast(transform.position, direction, blockHeight);
            if (hit.collider != null && hit.collider.gameObject != gameObject)
            {
                var hitBlockView = hit.collider.GetComponent<BlockViewWorldSpace>();
                if (hitBlockView != null)
                {
                    _neighbours.Add(hitBlockView.Id);
                }
            }
        }
    }
}
