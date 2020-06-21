using System;
using Kolokwium.Models;

namespace Kolokwium.Services
{
    public interface IDbService
    {
        Musician GetMusicianWithTracksById(int musicianId);
        void AddMusicianWithTracks(Musician musician);
    }

    class NotFoundException : Exception
    {
    }
}