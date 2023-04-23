using UnityEngine;

namespace COG.RTS.BuildMenu
{
    /// <summary>
    /// Set of data describing something that can be built.
    /// </summary>
    [CreateAssetMenu(fileName = "BuildableData", menuName = "RTS/Buildables/BuildableData")]
    public class BuildableData : ScriptableObject
    {
        [SerializeField] private float _buildTime;
        [Min(0)] [SerializeField] private int _cost;
        [SerializeField] private Buildable _buildable;
        [SerializeField] private Sprite _icon;
        //[SerializeField] private GameObject _gamePrefab;
        [SerializeField] private string _playerFacingName;

        public float BuildTime => _buildTime;
        public int Cost => _cost;
        public Buildable Buildable => _buildable;
        public BuildableCategory Category => _buildable.Category();
        public Sprite Icon => _icon;
        //public GameObject GamePrefab => _gamePrefab;
        public string PlayerFacingName => _playerFacingName;
    }
}