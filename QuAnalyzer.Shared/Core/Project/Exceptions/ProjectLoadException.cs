using System;

namespace QuAnalyzer.Core.Project.Exceptions
{
    [Serializable]
    public class ProjectLoadException : Exception
    {
        private const string UNABLE_TO_LOAD = "Unable to load the current project.";

        public ProjectLoadException()
        {
        }

        public ProjectLoadException(Exception innerException) : base(UNABLE_TO_LOAD, innerException)
        {
        }

        public ProjectLoadException(string message) : base(message)
        {
        }

        public ProjectLoadException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ProjectLoadException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {

        }
    }
}