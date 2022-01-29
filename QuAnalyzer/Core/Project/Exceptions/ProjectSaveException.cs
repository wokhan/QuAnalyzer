namespace QuAnalyzer.Core.Project.Exceptions;

[Serializable]
public class ProjectSaveException : Exception
{
    private const string UNABLE_TO_SAVE = "Unable to save the current project.";

    public ProjectSaveException()
    {
    }

    public ProjectSaveException(Exception innerException) : base(UNABLE_TO_SAVE, innerException)
    {
    }

    protected ProjectSaveException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext) : base(serializationInfo, streamingContext)
    {

    }

    public ProjectSaveException(string message) : base(message)
    {
    }

    public ProjectSaveException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
