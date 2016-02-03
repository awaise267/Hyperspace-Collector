using UnityEngine;
using System.Collections;

public interface Subject {

	void attachHealthObserver(HealthObserver ho);
	void detachHealthObserver(HealthObserver ho);
	void notifyHealthObservers();

}
