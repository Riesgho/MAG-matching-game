using Code.Board.Presenters;
using Code.Board.Views;
using Code.Core.Domain;
using Code.Core.Infrastructure;
using Code.Goals.Domain;
using Code.Goals.Infrastructure;
using Code.UI.Presentation;
using Code.UI.Views;
using UnityEngine;

namespace Code.Core.Views
{
    public class GameApp : MonoBehaviour
    {
        [SerializeField] private BoardView boardViewPrefab;
        [SerializeField] private BlockConfig blockConfig;
        [SerializeField] private LevelsMapsView levelsMapsView;
        [SerializeField] private LevelsConfig levelsConfigs;
        [SerializeField] private LevelView levelView;
        
        private InMemoryPlayer _inMemoryPlayer;
        private LevelsMapPresenter _levelsMapPresenter;
        private InMemoryGoals _inMemoryGoals;
        private RandomGenerator _randomGenerator;
        private BlockGenerator _blockGenerator;
        private InMemoryLevels _inMemoryLevels;
        private UpdatePlayerOnWin _updatePlayerOnWin;
        private LevelPresenter _levelPresenter;

        private void Start()
        {
            CreateGoals();
            _randomGenerator = new RandomGenerator();
            _blockGenerator = new BlockGenerator(blockConfig);
            _inMemoryPlayer = new InMemoryPlayer();
            _inMemoryLevels = new InMemoryLevels(levelsConfigs);

            _updatePlayerOnWin = new UpdatePlayerOnWin(_inMemoryPlayer);
                
            _levelsMapPresenter = new LevelsMapPresenter(levelsMapsView, _inMemoryLevels, _inMemoryPlayer);
            _levelsMapPresenter.LevelSelected = InitializeBoard;
            _levelsMapPresenter.Initialize();
            _levelsMapPresenter.UpdateMap();

            _levelPresenter = new LevelPresenter(levelView, _inMemoryGoals);
        }

        private void InitializeBoard(int level)
        {
            var boardView = Instantiate(boardViewPrefab);
            var boardPresenter = new BoardPresenter(boardView, _randomGenerator, _blockGenerator, level, _inMemoryGoals);
            boardPresenter.LevelWon = LevelWon;
            boardPresenter.Initialize(blockConfig);
            boardPresenter.BlocksPopped = _levelPresenter.UpdateGoal;
            
            _levelPresenter.Initialize(level);
            _levelPresenter.Show();
            _levelsMapPresenter.Hide();
        }

        private void LevelWon(int level)
        {
            _updatePlayerOnWin.Execute(level);
            _levelPresenter.Hide();
            _levelsMapPresenter.UpdateMap();
            _levelsMapPresenter.Show();
        }

        private void CreateGoals()
        {
            _inMemoryGoals = new InMemoryGoals();
            _inMemoryGoals.AddGoal(new TotalBlocksGoal(10), 1);
            _inMemoryGoals.AddGoal(new TotalBlocksOfColor(10, blockConfig.GetRandomColor()), 2);
            _inMemoryGoals.AddGoal(new TotalBlocksGoal(20), 3);
            _inMemoryGoals.AddGoal(new TotalBlocksOfColor(20, blockConfig.GetRandomColor()), 4);
            _inMemoryGoals.AddGoal(new TotalBlocksGoal(25), 5);
        }
    }
}