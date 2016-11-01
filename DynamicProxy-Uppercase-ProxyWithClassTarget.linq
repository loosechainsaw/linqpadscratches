<Query Kind="Program">
  <NuGetReference>Castle.Core</NuGetReference>
  <Namespace>Castle.DynamicProxy</Namespace>
</Query>

void Main()
{
	var p1 = new Person("Blair", "Davidson");
	var p2 = p1.Uppercaseify();

	$"{p2.Firstname} {p2.Lastname}".Dump();
	
}

public class Person
{

	public Person() {}
	
	public Person(string firstname, string lastname)
	{
		Firstname = firstname;
		Lastname = lastname;
	}

	public virtual string Firstname { get;private set; }
	public virtual string Lastname { get; private set;}
}

public static class ObjectProxyExtensions
{
	public static T Uppercaseify<T>(this T obj) where T : class
	{
		var options = new ProxyGenerationOptions(new UppercaseProxyGenerationHook());
		var generator = new ProxyGenerator();
		

		return generator.CreateClassProxyWithTarget<T>(obj, options, new UppercaseInterceptor());
	}

	private class UppercaseProxyGenerationHook : IProxyGenerationHook
	{
		public bool ShouldInterceptMethod(Type type, MethodInfo memberInfo)
		{
			return (memberInfo.IsPublic && memberInfo.IsSpecialName && memberInfo.Name.StartsWith("get_"));
		}

		public void MethodsInspected()
		{
			"Completed proxying".Dump();
		}

		public void NonProxyableMemberNotification(Type type, MemberInfo memberInfo)
		{
			$"{type.FullName} unable to proxy method {memberInfo.Name}".Dump();
		}
		
	}

	public class UppercaseInterceptor : IInterceptor
	{
		public void Intercept(IInvocation invocation)
		{
			invocation.Proceed();
			invocation.ReturnValue = invocation.ReturnValue.ToString().ToUpper();
		}
	}
}