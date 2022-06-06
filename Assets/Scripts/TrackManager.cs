using UnityEngine;
using UnityEngine.SceneManagement;

namespace BoundfoxStudios.MiniGolf._Game.Scripts
{
  public class TrackManager : MonoBehaviour
  {
    public Track[] Tracks;
    public Player Player;
    private int _currentTrack;
    public static TrackManager Instance;

    private void Awake()
    {
      Instance = this;
    }

    private void Start()
    {
      if (Player && Tracks.Length > 0)
      {
        Player.SpawnTo(Tracks[0].SpawnPoint.position);
      }
    }

    public void NextTrack()
    {
      _currentTrack = (_currentTrack + 1) % Tracks.Length;
      ScoreManager.instance.ResetScore();
      Timer.Instance.ResetTimer();
      Player.Instance.resetBallMovement();

      if (_currentTrack == 4)
      {
        SceneManager.LoadScene("EndGame");
      }
      else
      {
        Player.SpawnTo(Tracks[_currentTrack].SpawnPoint.position);
      }
    }
  }
}
