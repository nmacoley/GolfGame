using System;
using UnityEngine;

namespace BoundfoxStudios.MiniGolf._Game.Scripts
{
  public class TrackManager : MonoBehaviour
  {
    public Track[] Tracks;
    public Player Player;

    private int _currentTrack;

    private void Start()
    {
      if (Player && Tracks.Length > 0)
      {
        Player.SpawnTo(Tracks[0].SpawnPoint.position);
      }
    }
  }
}
