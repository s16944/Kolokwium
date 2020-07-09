using System;
using Kolokwium.Models;

namespace Kolokwium.Services
{
    public interface IDbService
    {
        Musician GetMusicianWithTracksById(int musicianId);
        void AddMusicianWithTrack(Musician musician);
    }

    class NotFoundException : Exception
    {
    }

    class ConflictException : Exception
    {
        public ConflictException()
        {
        }

        public ConflictException(string message) : base(message)
        {
        }
    }
}