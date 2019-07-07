using Systems;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameConfig config;

    private Feature _feature;
    private Contexts _context;
    
    // Start is called before the first frame update
    void Start()
    {
        _context = Contexts.sharedInstance;
        _context.game.SetGameConfig(config);
        _feature = getFeatures();
        _feature.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        _feature.Execute();
    }

    Feature getFeatures()
    {
        var feature = new Feature("Game");
        feature.Add(new InitializeMapSystem(_context));
        feature.Add(new CellToPositionSystem(_context));
        feature.Add(new CreateViewSystem(_context));
        feature.Add(new ApplyPositionSystem(_context));

        return feature;
    }
}


