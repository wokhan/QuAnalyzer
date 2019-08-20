using System;

namespace QuAnalyzer.Core.Project.Exceptions
{
    [Serializable]
    internal class ProjectSaveException : Exception
    {
        private const string UNABLE_TO_SAVE = "Unable to save the current project.";

        public ProjectSaveException()
        {
        }

        public ProjectSaveException(Exception innerException) : base(UNABLE_TO_SAVE, innerException)
        {
        }
    }
}