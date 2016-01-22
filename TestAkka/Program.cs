using System;

using Akka;
using Akka.Actor;

namespace TestAkka
{
  public class Greet
  {
    public Greet(string who)
    {
      Who = who;
    }
    public string Who {get; private set;}
  }
	public class GreetingActor : ReceiveActor
	{
		public GreetingActor()
		{
			Receive<Greet> (greet =>
				Console.WriteLine (" hello {0}", greet.Who)
			);
		}
	}
	class MainClass
	{
		public static void Main (string[] args)
		{
				var system = ActorSystem.Create ("MySystem");
				var greeter = system.ActorOf<GreetingActor> ("greeter");
				greeter.Tell (new Greet ("李兴钢"));
				Console.ReadLine ();
		}
	}
}
