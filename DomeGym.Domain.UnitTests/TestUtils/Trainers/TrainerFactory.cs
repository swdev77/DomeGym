using DomeGym.Domain.Trainers;

namespace DomeGym.Domain.UnitTests.TestUtils.Trainers;

public class TrainerFactory
{
    public static Trainer CreateTrainer()
    {
        return new Trainer();
    }
}