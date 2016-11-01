<Query Kind="Program" />

void Main()
{
	Network n = new NetworkProxy(new Network());
	n.Connect();
	n.Connect();
}

public class Network
{
	public virtual void Connect()
	{
		$"{this.GetType().Name} Connect Method".Dump();
	}
}

public class NetworkProxy : Network
{
	public NetworkProxy(Network proxied)
	{
		this.proxied_ = proxied;
	}

	public override void Connect()
	{
		if (connected_)
		{
			"Already connected".Dump();
			return;
		}
		connected_ = true;
		proxied_.Connect();
	}

	private bool connected_;
	private Network proxied_;
}