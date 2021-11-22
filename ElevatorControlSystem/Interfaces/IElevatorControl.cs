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
        public string StayPut(int cFloor);
        public string FloorPress(int floor);
    }
}
