using UnityEngine;

public class FpsCounter : MonoBehaviour {

	public int AverageFps { get; private set; }
	public int HighestFps { get; private set; }
	public int LowestFps { get; private set; }

	public int _frameRange = 60;
	int[] _fpsBuffer;
	int _fpsBuffIndex;

	void InitializeBuffer() {
		if (_frameRange <=0) {
			_frameRange = 1;
		}

		_fpsBuffer = new int[_frameRange];
		_fpsBuffIndex = 0;
	}

	void Update () {

		if (_fpsBuffer==null || _fpsBuffer.Length != _frameRange) {
			InitializeBuffer();
		}

		UpdateBuffer();
		CalculateFPS();
	}

	void UpdateBuffer() {
		_fpsBuffer[_fpsBuffIndex++] = (int) (1f / Time.unscaledDeltaTime);
		if(_fpsBuffIndex >= _frameRange) {
			_fpsBuffIndex = 0;
		}
	}

	void CalculateFPS() {
		int sum = 0;
		int highest = 0;
		int lowest = int.MaxValue;
		for (int i =0 ;i < _frameRange;i++) {
			sum += _fpsBuffer[i];
			if(_fpsBuffer[i] > highest)  {
				highest = _fpsBuffer[i];
			}

			if (_fpsBuffer[i] < lowest) {
				lowest = _fpsBuffer[i];
			}
		}
		AverageFps = sum/_frameRange;
		HighestFps = highest;
		LowestFps = lowest;
	}

}
