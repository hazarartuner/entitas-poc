using Entitas;
using UnityEngine;

namespace Systems
{
	public class InitializeMapSystem : IInitializeSystem  {
		private Contexts _contexts;

		public InitializeMapSystem(Contexts contexts) {
			_contexts = contexts;
		}

		public void Initialize()
		{
			var config = _contexts.game.gameConfig.value;

			var colCount = config.colCount;
			var rowCount = config.rowCount;
			var candies = config.Candies;
			
			for (var i=0; i<rowCount; i++)
			{
				for (var j=0; j<colCount; j++)
				{
					var entity = _contexts.game.CreateEntity();
					entity.AddCell(new Vector2(j, i));
					entity.AddResource(candies[Random.Range(0, candies.Length - 1)]);
					entity.AddPosition(Vector3.zero);
				}
			}
		}
	}
}