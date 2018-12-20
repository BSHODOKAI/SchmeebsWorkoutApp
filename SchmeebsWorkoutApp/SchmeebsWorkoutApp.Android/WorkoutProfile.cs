using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SchmeebsWorkoutApp.Droid.Enumerations;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SchmeebsWorkoutApp.Droid
{
    public class WorkoutProfile
    {
        public int DeadliftMax { get; set; }
        public int SquatMax { get; set; }
        public int BenchPressMax { get; set; }
        public int OverheadPressMax { get; set; }

        public WorkoutProfile()
        {
            throw new NotImplementedException("Default Constructor Not Supported");
        }

        public WorkoutProfile(Dictionary<string, int> OneRepMaxes)
        {
            DeadliftMax = OneRepMaxes["Deadlift"];
            SquatMax = OneRepMaxes["Squat"];
            BenchPressMax = OneRepMaxes["BenchPress"];
            OverheadPressMax = OneRepMaxes["OverheadPress"];
        }

        public MainMover GetMainMover(Movement movement, Intensity intensity)
        {
            var mainMover = new MainMover(intensity, movement);

            return mainMover;
        }

    }

    
    public interface Excercise
    {
        int Rep { get; }
        Intensity Intensity { get; }
        decimal PercentageOf1RM { get; }
        Movement Movement { get; }
    }

    public class MainMover : Excercise
    {
        public Movement Movement { get => _movement;  }
        public int Rep { get => _rep; }
        Intensity Excercise.Intensity { get => _intensity; }
        decimal Excercise.PercentageOf1RM { get => _percentageOf1RM; }

        private int _rep;
        private Intensity _intensity;
        private decimal _percentageOf1RM;
        private Movement _movement;

        public MainMover(Intensity intensity, Movement movement)
        {

            _intensity = intensity;
            _movement = movement;
            switch (_intensity)
            {
                case Intensity.Brutal:
                    _percentageOf1RM = 0.85M;
                    _rep = 5;
                    break;
                case Intensity.Heavy:
                    _percentageOf1RM = 0.75M;
                    _rep = 7;
                    break;
                case Intensity.Medium:
                    _percentageOf1RM = 0.65M;
                    _rep = 9;
                    break;
                case Intensity.Light:
                    _percentageOf1RM = 0.55M;
                    _rep = 11;
                    break;
                default:
                    throw new InvalidOperationException("Invalid Intensity Sent");
            }

        }

    }
}