using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class CellToPositionSystem : ReactiveSystem<GameEntity> {
    private Contexts _contexts;

	public CellToPositionSystem (Contexts contexts) : base(contexts.game) {
        _contexts = contexts;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
		return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Cell));
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasCell;
	}

	protected override void Execute(List<GameEntity> entities) {
		foreach (var e in entities) {
			var gameConfig = _contexts.game.gameConfig.value;
			var offsetX = gameConfig.itemWidth * (gameConfig.colCount - 1) / 2;
			var offsetY = gameConfig.itemHeight * (gameConfig.rowCount - 1) / 2;
			var position = new Vector2(
					e.cell.Value.x * gameConfig.itemWidth,
					e.cell.Value.y * gameConfig.itemHeight
				);
			
			e.ReplacePosition(position - new Vector2(offsetX, offsetY));
		}
	}
}