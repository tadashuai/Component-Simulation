using UnityEngine;

public class OneBitLatch : MonoBehaviour
{
	[SerializeField]bool input = false;
	[SerializeField]bool timer;
	[SerializeField]bool output = false;
	bool lastOutput = false;
	bool and1, and2, nor1, nor2;

	void Update()
	{
		timer = IntIntoBool( ( int ) ( Time.time * 50f ) % 2 );

		if ( Input.GetKeyDown( KeyCode.Keypad0 ) )
			input = false;
		else if ( Input.GetKeyDown( KeyCode.Keypad1 ) )
			input = true;

		and1 = input && timer;
		and2 = !input && timer;
		do
		{
			lastOutput = output;
			nor1 = !( and1 || output );
			nor2 = !( and2 || nor1 );
			output = nor2;
		} while ( output != lastOutput );
	}

	bool IntIntoBool( int x )
	{
		if ( x == 0 )
		{
			return false;
		}
		else if ( x == 1 )
		{
			return true;
		}
		else
		{
			Debug.LogError( "" );
			return false;
		}
	}
}
