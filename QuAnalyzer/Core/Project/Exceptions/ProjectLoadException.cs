using System;

namespace QuAnalyzer.Core.Project.Exceptions
{
    [Serializable]
    internal class ProjectLoadException : Exception
    {
        private const string UNABLE_TO_LOAD = "Unable to load the current project.";

        public ProjectLoadException()
        {
        }

        public ProjectLoadException(Exception innerException) : base(UNABLE_TO_LOAD, innerException)
        {
        }
    }
}