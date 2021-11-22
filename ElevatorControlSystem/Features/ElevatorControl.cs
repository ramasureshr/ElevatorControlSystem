using ElevatorControlSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElevatorControlSystem.Features
{
    public class ElevatorControl : IElevatorControl
    {
        private bool[] floorReady;
        public int CurrentFloor = 1;
        private int topfloor;
        public ElevatorStatus Status = ElevatorStatus.STOPPED;

        public ElevatorControl(int NumberOfFloors = 10)
        {
            floorReady = new bool[NumberOfFloors + 1];
            topfloor = NumberOfFloors;
        }
        public void GoDown(int floor)
        {
            for (int i = CurrentFloor; i >= 1; i--)
            {
                if (floorReady[i])
                    Stop(floor);
                else
                    continue;
            }

            Status = ElevatorStatus.STOPPED;
            Console.WriteLine("Waiting..");
        }

        public void GoUp(int floor)
        {
            for (int i = CurrentFloor; i <= topfloor; i++)
            {
                if (floorReady[i])
                    Stop(floor);
                else
                    continue;
            }

            Status = ElevatorStatus.STOPPED;
            Console.WriteLine("Waiting..");
        }

        public string StayPut(int cFloor)
        {
            return $"This is Current Floor:{cFloor}";
        }

        public void Stop(int floor)
        {
            Status = ElevatorStatus.STOPPED;
            CurrentFloor = floor;
            floorReady[floor] = false;
            Console.WriteLine("Stopped at floor {0}", floor);
        }

        public string FloorPress(int floor)
        {
            string LiftMovement = $"Current Floor:{CurrentFloor},Requested Floor is {floor};LiftGoing";
            if (floor > topfloor)
            {

                return $"We only have {topfloor} floors";
            }

            floorReady[floor] = true;

            switch (Status)
            {

                case ElevatorStatus.DOWN:
                    GoDown(floor);
                    break;

                case ElevatorStatus.STOPPED:
                    if (CurrentFloor < floor)
                    {
                        LiftMovement = LiftMovement + " UP";
                        GoUp(floor);
                    }
                    else if (CurrentFloor == floor)
                    {
                        LiftMovement = LiftMovement + "is not Going Anywhere";
                        StayPut(CurrentFloor);
                    }
                    else
                    {
                        LiftMovement = LiftMovement + " Down";
                        GoDown(floor);
                    }
                    break;

                case ElevatorStatus.UP:
                    GoUp(floor);
                    break;

                default:
                    break;
            }

            return LiftMovement + " Elevator now is at Request Floor:"+CurrentFloor;

        }
    }
}
