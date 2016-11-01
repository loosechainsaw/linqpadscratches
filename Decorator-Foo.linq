<Query Kind="Program" />

void Main()
{
	IComponent c = new ComponentLogger(new ComponentLogger( new CoreComponent()));
	c.Operation();
}

public interface IComponent
{
	void Operation();
}

public abstract class ComponentDecorator : IComponent
{

	public ComponentDecorator(IComponent decoratee)
	{
		if(decoratee == null)
			throw new ArgumentNullException(nameof(decoratee));
		decoratee_ = decoratee;
	}

	public virtual void Operation()
	{
		decoratee_.Operation();
	}

	private IComponent decoratee_;

}

public class CoreComponent : IComponent
{
	public virtual void Operation()
	{
		"CoreComponent Operation()".Dump();
	}
}

public class ComponentLogger : ComponentDecorator
{

	public ComponentLogger(IComponent decoratee) : base(decoratee) {}
	
	public override void Operation()
	{
		"Logger Operation() - Before".Dump();
		base.Operation();
		"Logger Operation() - Before".Dump();
	}
}