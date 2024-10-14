using UnityEngine;
public class EnemySpawnPoint : MonoBehaviour
{
    [SerializeField] private RegularBehaviour _regularBehaviour;
    [SerializeField] private ReactionBehaviour _reactionBehaviour;

    public ReactionBehaviour ReactionBehaviour => _reactionBehaviour;
    public RegularBehaviour RegularBehaviour => _regularBehaviour;
}
