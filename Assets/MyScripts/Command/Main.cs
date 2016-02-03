using UnityEngine;
using System.Collections;

class Main : MonoBehaviour {

	public void play()
	{

		PlayGame plyobj = new PlayGame ();

		PlayCommand plycmd = new ConcretePlay (plyobj);

		PlayInvoker invobj = new PlayInvoker ();
		invobj.SetCommand (plycmd);
		invobj.Execute ();


	}


	public void help()
	{
		
		HelpGame helpobj = new HelpGame ();
		
		HelpCommand helpcmd = new ConcerteHelp (helpobj);
		
		HelpInvoker invobj = new HelpInvoker ();
		invobj.SetCommand (helpcmd);
		invobj.Execute ();
		
		
	}



	public void GoBackToMainMenu()
	{
		
		Application.LoadLevel(0);
	}
}
