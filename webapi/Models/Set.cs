using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Set
{
    public int Id { get; set; }
    public int FkWorkoutId { get; set; }
    public Workout FkWorkout { get; set; }
    public int FkExerciseId { get; set; }
    public Exercise FkExercise { get; set; }
    public int Reps { get; set; }

    public int Total { get; set; }

}
