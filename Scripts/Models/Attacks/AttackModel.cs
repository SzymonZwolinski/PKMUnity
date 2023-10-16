public class AttackModel 
{
	public string Name;
    public uint Damage;
    public uint Accuracy;
	public Types Type;
    public AttackPriority Priority;
    public AttackStatus? Status;
    public AttackKind Kind;

	public AttackModel(
		string name,
		uint damage,
		uint accuracy,
		Types type,
		AttackPriority priority,
		AttackStatus? status,
		AttackKind kind)
	{
		Name = name;
		Damage = damage;
		Accuracy = accuracy;
		Type = type;
		Priority = priority;
		Status = status;
		Kind = kind;
	}
}