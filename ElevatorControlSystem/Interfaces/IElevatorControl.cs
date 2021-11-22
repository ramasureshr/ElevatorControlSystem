using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElevatorControlSystem.Interfaces
{
    public interface IElevatorControl
    {
        public void Stop(int floor);
        public void GoDown(int floor);
        public void GoUp(int floor);
        public void StayPut();
    }
}
