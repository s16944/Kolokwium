using System;
using Kolokwium.Models;

namespace Kolokwium.Services
{
    public interface IDbService
    {
        Musician GetMusicianWithTracksById(int musicianId);
    }

    class NotFoundException : Exception
    {
    }
}