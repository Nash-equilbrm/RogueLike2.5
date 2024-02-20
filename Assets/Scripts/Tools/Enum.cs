public enum UIType
{
    Unknow,
    Screen,
    Popup,
    Notify,
    Overlap
}

public enum GameFlowState
{
    MainMenu,
    Lobby,
    Gameplay
}

public enum EventID
{ 
    PlayerTakeDamageFromEnemy,
    PlayerTakeDamageFromBullet,

}
public enum LanguageId
{
    VIE,
    ENG
}

public enum EnemyState
{
    Patrol,
    ChasePlayer,
    Attack,
    Die
}