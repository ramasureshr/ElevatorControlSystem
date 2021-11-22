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

        public void StayPut()
        {
            throw new NotImplementedException();
        }

        public void Stop(int floor)
        {
            Status = ElevatorStatus.STOPPED;
            CurrentFloor = floor;
            floorReady[floor] = false;
            Console.WriteLine("Stopped at floor {0}", floor);
        }

        public void FloorPress(int floor)
        {
            if (floor > topfloor)
            {
                Console.WriteLine("We only have {0} floors", topfloor);
                return;
            }

            floorReady[floor] = true;

            switch (Status)
            {

                case ElevatorStatus.DOWN:
                    Descend(floor);
                    break;

                case ElevatorStatus.STOPPED:
                    if (CurrentFloor < floor)
                        Ascend(floor);
                    else if (CurrentFloor == floor)
                        StayPut();
                    else
                        Descend(floor);
                    break;

                case ElevatorStatus.UP:
                    Ascend(floor);
                    break;

                default:
                    break;
            }

        }
    }
