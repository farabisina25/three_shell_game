namespace DefaultNamespace
{
    public enum PhaseType
    {
        Preparing,
        Mixing,
        Select
    }

    public static class PhaseManager
    {
        private static PhaseType _phaseType;

        public static PhaseType PhaseType => _phaseType;

        public static void ChangePhase(PhaseType phaseType)
        {
            _phaseType = phaseType;
        }
    }
}