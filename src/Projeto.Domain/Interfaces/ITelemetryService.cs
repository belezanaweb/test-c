using System;

namespace Projeto.Domain.Interfaces
{
    public interface ITelemetryService
    {
        void TrackException(Exception exception, string message);
    }
}
