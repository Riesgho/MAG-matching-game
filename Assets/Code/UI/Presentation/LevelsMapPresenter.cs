using System;
using Code.Core.Domain;

namespace Code.UI.Presentation
{
    public class LevelsMapPresenter
    {
        public Action<int> LevelSelected { get; set; }
        private readonly ILevelsMapView _view;
        private readonly ILevelsRepository _inMemoryLevels;
        private readonly IPlayerRepository _playerRepository;

        public LevelsMapPresenter(ILevelsMapView view, ILevelsRepository inMemoryLevels, IPlayerRepository playerRepository)
        {
            _view = view;
            _inMemoryLevels = inMemoryLevels;
            _playerRepository = playerRepository;
        }

        public void Initialize()
        {
            _view.LevelClicked = LevelSelected;
            _view.DrawLevels(_inMemoryLevels.GetAll());
        }

        public void UpdateMap()
        {
            _view.DeactivateNotAvailableLevels(_playerRepository.GetPlayer().ReachedLevel);
        }

        public void Hide()
        {
            _view.Hide();
        }

        public void Show()
        {
            _view.Show();
        }
    }
}