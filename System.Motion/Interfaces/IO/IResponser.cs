namespace System.Interfaces
{
    /// <summary>
    ///     ��ʾһ����Ӧ����
    /// </summary>
    public interface IResponser<T> : IAutomatic where T : struct
    {
        bool Value { set; }
    }
}