using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _baseColor, _offsetColor, _portalColor;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public void Init(bool isOffset, bool isPortal)
    {
        _spriteRenderer.sortingLayerName = "Background";
        _spriteRenderer.color = isPortal ?  _portalColor  : (isOffset ? _offsetColor : _baseColor);
    }
}
