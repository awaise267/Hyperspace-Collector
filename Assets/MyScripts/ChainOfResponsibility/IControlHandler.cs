using UnityEngine;
using System.Collections;

public interface IControlHandler {

	void handleInput(string input);
	void setNextInput(IControlHandler next);

}
