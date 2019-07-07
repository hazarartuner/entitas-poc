using Entitas;
using System.Collections.Generic;
using Entitas.Unity;
using UnityEngine;

public class CreateViewSystem : ReactiveSystem<GameEntity> {
	private Contexts _contexts;
	
	public CreateViewSystem (Contexts contexts) : base(contexts.game) {
		_contexts = contexts;
	}
		
	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
		return context.CreateCollector(GameMatcher.Resource);
	}

	protected override bool Filter(GameEntity entity) {
        return entity.hasResource;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		
		foreach (var e in entities)
		{
			var candy = GameObject.Instantiate(e.resource.Value);
			
			if (e.hasView)
			{
				e.view.Value.Unlink();
				GameObject.Destroy(e.view.Value);
				e.ReplaceView(candy);
			}
			else
			{
				e.AddView(candy);
			}
			
			candy.Link(e);
		}
	}
}
