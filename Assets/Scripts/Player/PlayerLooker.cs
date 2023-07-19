using UnityEngine;
using Zenject;

public class PlayerLooker : IPlayerLooker, IInitializable, ITickable
{
    private PlayerControlsConfig _playerControlsConfig;
    private Player _player;
    private ILookerInput _lookerInput;

    private Vector2 _lookValue;




    [Inject]
    public void Construct(ILookerInput lookerInput, PlayerControlsConfig playerControlsConfig)
    {
        _lookerInput = lookerInput;
        _playerControlsConfig = playerControlsConfig;
    }
    public void SetPlayer(Player player)
    {
        _player = player;
    }

    public void Initialize()
    {
        _lookerInput.PlayerLooked += Looked;
    }

    public void Looked(Vector2 value)
    {
        _lookValue = value;
    }

    public void Tick()
    {
        HorizontalLook();
        VerticalLook();
        ClampVerticalRotation();
    }
    private void HorizontalLook()
    {
        _lookValue.x = _lookValue.x * _playerControlsConfig.mouseHorizontalSensitivity;
        _player.transform.Rotate(0, _lookValue.x * Time.smoothDeltaTime * 50, 0);
    }
    private void VerticalLook()
    {
        _lookValue.y = _lookValue.y * _playerControlsConfig.mouseVerticalSensitivity;
        _player.Camera.transform.Rotate(-_lookValue.y * Time.smoothDeltaTime * 50, 0, 0);
    }
    private void ClampVerticalRotation()
    {
        Vector3 currentRotation = _player.Camera.transform.localRotation.eulerAngles;
        if (currentRotation.x < _playerControlsConfig.mouseVerticalClamp.min)
        {
            currentRotation.x = _playerControlsConfig.mouseVerticalClamp.min;
        }
        if (currentRotation.x > _playerControlsConfig.mouseVerticalClamp.max)
        {
            currentRotation.x = _playerControlsConfig.mouseVerticalClamp.max;
        }
        _player.Camera.transform.localRotation = Quaternion.Euler(currentRotation);
    }
    
}
