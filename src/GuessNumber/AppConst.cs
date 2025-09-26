
namespace GuessNumber
{
    /// <summary>
    /// Константы приложения.
    /// </summary>
    static class AppConst
    {
        /// <summary>
        /// Константы ресурсов приложения.
        /// </summary>
        public static class Resources
        {
            public const string Rules = "GuessNumber.Resources.Rules.txt";
            public const string Bye = "GuessNumber.Resources.Bye.txt";
            public const string ChooseContinueOrExit = "GuessNumber.Resources.ChooseContinueOrExit.txt";
            public const string NumberNeeded = "GuessNumber.Resources.NumberNeeded.txt";
            public const string AnswerIsCorrectTemplate = "GuessNumber.Resources.AnswerIsCorrectTemplate.txt";
            public const string AnswerIsIncorrectTemplate = "GuessNumber.Resources.AnswerIsIncorrectTemplate.txt";
            public const string GameTaskTemplate = "GuessNumber.Resources.GameTaskTemplate.txt";
        }

        /// <summary>
        /// Константы меток в текстовых шаблонах.
        /// </summary>
        public static class Placeholders
        {
            public const string GameTask = "__GAME_TASK__";
            public const string Answer = "__ANSWER__";
        }
    }
}