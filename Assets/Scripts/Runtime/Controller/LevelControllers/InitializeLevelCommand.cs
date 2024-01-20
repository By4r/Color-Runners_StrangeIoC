using Runtime.Model;
using Runtime.Model.Level;
using strange.extensions.command.impl;
using Object = UnityEngine.Object;

namespace Runtime.Controller.LevelControllers
{
    public class InitializeLevelCommand : Command
    {
        [Inject] private ILevelModel LevelModel { get; set; }
        private byte _currentLevelID;

        public override void Execute()
        {
            _currentLevelID = GetActiveLevel();
            InitializeLevel();
        }

        private byte GetActiveLevel()
        {
            return LevelModel.GetActiveLevel();
        }

        private void InitializeLevel()
        {
            Object.Instantiate(LevelModel.LevelObjects[_currentLevelID % LevelModel.TotalLevelCount], LevelModel.LevelHolder.transform,
                true);
        }
    }
}